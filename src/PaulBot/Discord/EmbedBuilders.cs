using Discord;

namespace PaulBot.Discord;

public class EmbedBuilders
{
    public static Embed Error(string title, string? description = "") => 
        new EmbedBuilder()
            .WithColor(DiscordColor.Red) 
            .WithTitle(title)
            .WithDescription(description)
            .WithCurrentTimestamp()
            .Build();
    
    public static Embed Success(string title, string? description = "") => 
        new EmbedBuilder()
            .WithColor(DiscordColor.Green) 
            .WithTitle(title)
            .WithDescription(description)
            .WithCurrentTimestamp()
            .Build();
}