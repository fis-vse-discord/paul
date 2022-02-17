namespace PaulBot.Discord.Roles.Models;

public class SelfAssignableRolesMenu
{
    /// <summary>
    /// Unique id of the self-assignable roles menu
    /// </summary>
    public int Id { get; set; }
    
    /// <summary>
    /// ID of the channel that the embed is posted in
    /// </summary>
    public ulong ChannelId { get; set; }
    
    /// <summary>
    /// ID of the message with the role menu selection embed
    /// </summary>
    public ulong MessageId { get; set; }
    
    /// <summary>
    /// Title of the role menu
    /// </summary>
    public string Title { get; set; } = null!;

    /// <summary>
    /// Roles mapped to this self assignable role menu
    /// </summary>
    public List<SelfAssignableRole> Roles { get; set; } = new();
}