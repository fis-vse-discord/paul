using PaulBot.Discord.Roles.Contract;
using PaulBot.Discord.Roles.Models;

namespace PaulBot.Discord.Roles.Services;

public class SelfAssignableRolesService : ISelfAssignableRolesService
{
    public Task<SelfAssignableRolesMenu> CreateRoleMenuAsync(string title, ulong channelId)
    {
        throw new NotImplementedException();
    }

    public Task<SelfAssignableRolesMenu> DeleteRoleMenuAsync(int menuId)
    {
        throw new NotImplementedException();
    }

    public Task<SelfAssignableRole> BindRoleToMenuAsync(int menuId, ulong discordRoleId)
    {
        throw new NotImplementedException();
    }

    public Task RemoveBoundRoleFromMenuAsync(int roleId)
    {
        throw new NotImplementedException();
    }
}