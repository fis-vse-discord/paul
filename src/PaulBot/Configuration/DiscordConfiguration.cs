namespace PaulBot.Configuration;

public class DiscordConfiguration
{
    public const string Section = "Discord";
    
    /// <summary>
    /// Token used for the Discord gateway authentication
    /// </summary>
    public string Token { get; init; } = null!;

    /// <summary>
    /// ID of the guild to which the slash commands should be registered
    /// </summary>
    public ulong GuildId { get; init; }
}