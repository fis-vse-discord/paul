using Discord;
using Discord.WebSocket;
using Microsoft.Extensions.Options;
using PaulBot.Configuration;

namespace PaulBot.Discord;

public class DiscordBotService : BackgroundService
{
    private readonly ILogger<DiscordBotService> _logger;
    
    private readonly DiscordSocketClient _client;
    
    private readonly DiscordConfiguration _configuration;

    public DiscordBotService(ILogger<DiscordBotService> logger, DiscordSocketClient client, IOptions<DiscordConfiguration> configuration)
    {
        _logger = logger;
        _client = client;
        _configuration = configuration.Value;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        _client.Log += LogMessageAsync;
        
        await _client.LoginAsync(TokenType.Bot, _configuration.Token);
        await _client.StartAsync();
        await Task.Delay(-1, stoppingToken);
    }

    private Task LogMessageAsync(LogMessage message)
    {
        _logger.LogInformation("[Discord]: {message}", message.ToString());
        return Task.CompletedTask;
    }
}