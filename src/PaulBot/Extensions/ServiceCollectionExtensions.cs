using Discord;
using Discord.Commands;
using Discord.WebSocket;
using PaulBot.Discord;

namespace PaulBot.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddDiscordBot(this IServiceCollection services)
    {
        const GatewayIntents intents = GatewayIntents.AllUnprivileged
                                       | GatewayIntents.GuildMembers
                                       & ~GatewayIntents.GuildScheduledEvents
                                       & ~GatewayIntents.GuildInvites;
                                       
        var configuration = new DiscordSocketConfig
        {
            LogLevel = LogSeverity.Info,
            LogGatewayIntentWarnings = true,
            GatewayIntents = intents,
        };
        
        services.AddSingleton<CommandService>();
        services.AddSingleton(new DiscordSocketClient(configuration));
        services.AddHostedService<DiscordBotService>();

        return services;
    }
}