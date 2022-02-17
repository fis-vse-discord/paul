namespace PaulBot.Discord.Roles.Models;

/// <summary>
/// A role that can be self-assigned to users by clicking a button interaction
/// </summary>
public class SelfAssignableRole
{
    /// <summary>
    /// ID of the self-assignable role entity
    /// </summary>
    public int Id { get; set; }    
    
    /// <summary>
    /// ID of the role menu that this role is associated to
    /// </summary>
    public int RoleMenuId { get; set; }
    
    /// <summary>
    /// ID of the Discord role that's mapped
    /// </summary>
    public ulong RoleId { get; set; }

    /// <summary>
    /// Mapped roles menu that this role is self assignable roles menu
    /// </summary>
    public SelfAssignableRolesMenu Menu { get; set; } = null!;
}