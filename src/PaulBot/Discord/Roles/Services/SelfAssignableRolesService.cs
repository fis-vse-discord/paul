using Discord;
using Discord.WebSocket;
using Microsoft.Extensions.Options;
using PaulBot.Configuration;
using PaulBot.Data;
using PaulBot.Discord.Roles.Contract;
using PaulBot.Discord.Roles.Models;

namespace PaulBot.Discord.Roles.Services;

public class SelfAssignableRolesService : ISelfAssignableRolesService
{
    private readonly DiscordSocketClient _client;
    
    private readonly DiscordConfiguration _configuration;

    private readonly PaulBotDbContext _context;

    public SelfAssignableRolesService(DiscordSocketClient client, IOptions<DiscordConfiguration> configuration, PaulBotDbContext context)
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

        return menu;
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
}