using Discord;
using Discord.WebSocket;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using PaulBot.Configuration;
using PaulBot.Data;
using PaulBot.Discord.Roles.Contract;
using PaulBot.Discord.Roles.Exceptions;
using PaulBot.Discord.Roles.Models;

namespace PaulBot.Discord.Roles.Services;

public class SelfAssignableRolesService : ISelfAssignableRolesService
{
    private readonly DiscordSocketClient _client;

    private readonly DiscordConfiguration _configuration;

    private readonly PaulBotDbContext _context;

    public SelfAssignableRolesService(DiscordSocketClient client, IOptions<DiscordConfiguration> configuration,
        PaulBotDbContext context)
    {
        _client = client;
        _context = context;
        _configuration = configuration.Value;
    }

    public async Task<SelfAssignableRolesMenu> CreateRoleMenuAsync(string title, ulong channelId)
    {
        var message = await SendRoleMenuMessageAsync(title, channelId);
        var menu = new SelfAssignableRolesMenu
        {
            Title = title,
            ChannelId = channelId,
            MessageId = message.Id
        };

        await _context.SelfRoleMenus.AddAsync(menu);
        await _context.SaveChangesAsync();
        
        await UpdateRoleMenuEmbedAsync(menu);

        return menu;
    }

    public async Task<SelfAssignableRolesMenu> DeleteRoleMenuAsync(int menuId)
    {
        var menu = await _context.SelfRoleMenus
                       .Include(m => m.Roles)
                       .FirstOrDefaultAsync(m => m.Id == menuId)
                   ?? throw new RoleMenuNotFoundException();

        _context.SelfRoles.RemoveRange(menu.Roles);
        _context.SelfRoleMenus.Remove(menu);

        await _context.SaveChangesAsync();
        
        return menu;
    }

    public async Task<SelfAssignableRole> BindRoleToMenuAsync(int menuId, ulong discordRoleId)
    {
        var menu = await _context.SelfRoleMenus
                       .Include(m => m.Roles)
                       .FirstOrDefaultAsync(m => m.Id == menuId)
                   ?? throw new RoleMenuNotFoundException();

        var role = new SelfAssignableRole
        {
            RoleId = discordRoleId,
            RoleMenuId = menu.Id
        };

        menu.Roles.Add(role);
        _context.SelfRoleMenus.Update(menu);

        await _context.SaveChangesAsync();
        await UpdateRoleMenuEmbedAsync(menu);
        
        return role;
    }

    public async Task RemoveBoundRoleFromMenuAsync(int roleId)
    {
        var role = await _context.SelfRoles
                       .Include(m => m.Menu)
                       .FirstOrDefaultAsync(m => m.Id == roleId)
                   ?? throw new RoleMenuNotFoundException();

        role.Menu.Roles.Remove(role);
        
        _context.SelfRoles.Remove(role);

        await _context.SaveChangesAsync();
        await UpdateRoleMenuEmbedAsync(role.Menu);
    }

    private async Task<IMessage> SendRoleMenuMessageAsync(string title, ulong channelId)
    {
        var guild = _client.GetGuild(_configuration.GuildId);
        var channel = guild.GetTextChannel(channelId);

        var embed = new EmbedBuilder()
            .WithTitle(title)
            .WithColor(DiscordColor.Primary)
            .Build();

        return await channel.SendMessageAsync(embed: embed);
    }

    private async Task UpdateRoleMenuEmbedAsync(SelfAssignableRolesMenu menu)
    {
        var guild = _client.GetGuild(_configuration.GuildId);
        var channel = guild.GetTextChannel(menu.ChannelId);
        var message = await channel.GetMessageAsync(menu.MessageId) as IUserMessage;
        
        // Create a component button for every self-assignable role
        var embed = new EmbedBuilder()
            .WithColor(DiscordColor.Primary)
            .WithTitle(menu.Title)
            .WithDescription("Pro získání nebo odebrání role klikni na tlačítko pod zprávou.")
            .WithCurrentTimestamp()
            .WithFooter($"role menu id: {menu.Id}");
        
        var components = menu.Roles
            .Select(s => guild.Roles.First(r => r.Id == s.RoleId))
            .Select(r => (r.Id, r.Name))
            .OrderBy(r => r.Name)
            .Aggregate(new ComponentBuilder(), (builder, role) =>
                builder.WithButton(ButtonBuilder.CreateSecondaryButton(role.Name, $"selfrole:{role.Id}")));

        await message!.ModifyAsync(m =>
        {
            m.Embed = embed.Build();
            m.Components = components.Build();
        });
    }
}