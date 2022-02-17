using PaulBot.Discord.Roles.Models;

namespace PaulBot.Discord.Roles.Contract;

public interface ISelfAssignableRolesService
{
    /// <summary>
    /// Create a new self-assignable role menu
    /// </summary>
    /// <param name="title">Title of the created role menu</param>
    /// <param name="channelId">ID of the Discord channel that this role menu embed should be created in</param>
    Task<SelfAssignableRolesMenu> CreateRoleMenu(string title, ulong channelId);

    /// <summary>
    /// Remove self-assignable role menu and unbind all previously bound roles
    /// </summary>
    /// <param name="menuId"></param>
    Task<SelfAssignableRolesMenu> DeleteRoleMenu(int menuId);
    
    /// <summary>
    /// Bind a self assignable role to the specified role menu
    /// </summary>
    /// <param name="menuId">ID of the menu that this role should be bound to</param>
    /// <param name="discordRoleId">Id of the Discord role that should be bound</param>
    Task<SelfAssignableRole> BindRoleToMenu(int menuId, ulong discordRoleId);

    
    /// <summary>
    /// Remove previously bound role from a role menu
    /// </summary>
    /// <param name="roleId">Id of the role that should be removed from the menu</param>
    Task RemoveBoundRoleFromMenu(int roleId);
}