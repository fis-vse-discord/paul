using Discord;
using Discord.Interactions;
using Discord.WebSocket;
using PaulBot.Discord.Roles.Contract;

namespace PaulBot.Discord.Roles;

public class SelfAssignableRolesModule : InteractionModuleBase<SocketInteractionContext>
{
    private readonly ISelfAssignableRolesService _service;

    public SelfAssignableRolesModule(ISelfAssignableRolesService service)
    {
        _service = service;
    }

    [RequireUserPermission(GuildPermission.ManageGuild)]
    [SlashCommand("create-role-menu", "Create a new self-assignable roles menu")]
    public async Task CreateRoleMenu(
        [Summary("title", "Title displayed in the embed header")] string title,
        [Summary("channel", "Text channel to which the role embed menu should be sent")] SocketTextChannel channel
    )
    {
        await DeferAsync(ephemeral: true);
        await _service.CreateRoleMenuAsync(title, channel.Id);

        await FollowupAsync(ephemeral: true, text: "👌");
    }

    [RequireUserPermission(GuildPermission.ManageGuild)]
    [SlashCommand("bind-role", "Bind a self-assignable role to the specified role menu")]
    public async Task BindRoleToMenu(
        [Summary("menu", "ID of the menu that the role should be bound to")] int menu,
        [Summary("role", "Role that should be bound to the menu")] SocketRole role
    )
    {
        await DeferAsync(ephemeral: true);
        await _service.BindRoleToMenuAsync(menu, role.Id);

        await FollowupAsync(ephemeral: true, text: "👌");
    }
}