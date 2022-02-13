using System.Reflection;
using Discord;
using Discord.Interactions;
using Discord.WebSocket;
using Microsoft.Extensions.Options;
using PaulBot.Configuration;

namespace PaulBot.Discord;

public class DiscordBotService : BackgroundService
{
    private readonly ILogger<DiscordBotService> _logger;

    private readonly DiscordSocketClient _client;

    private readonly DiscordConfiguration _configuration;

    private readonly IServiceProvider _services;

    private readonly InteractionService _interactions;

    public DiscordBotService(
        ILogger<DiscordBotService> logger,
        DiscordSocketClient client,
        IOptions<DiscordConfiguration> configuration,
        IServiceProvider services
    )
    {
        _logger = logger;
        _client = client;
        _services = services;
        _configuration = configuration.Value;
        _interactions = new InteractionService(_client);
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        _client.Log += LogMessageAsync;
        _client.Ready += RegisterInteractionsAsync;
        _client.InteractionCreated += HandleSocketInteractionAsync;

        await _client.LoginAsync(TokenType.Bot, _configuration.Token);
        await _client.StartAsync();
        
        await Task.Delay(-1, stoppingToken);
    }

    private async Task RegisterInteractionsAsync()
    {
        await _interactions.AddModulesAsync(Assembly.GetEntryAssembly(), _services);
        await _interactions.RegisterCommandsToGuildAsync(_configuration.GuildId);
    }

    private Task LogMessageAsync(LogMessage message)
    {
        _logger.LogInformation("[Discord]: {message}", message.ToString());
        return Task.CompletedTask;
    }

    private async Task HandleSocketInteractionAsync(SocketInteraction interaction)
    {
        var context = new SocketInteractionContext(_client, interaction);
        var result = await _interactions.ExecuteCommandAsync(context, _services);
    }
}