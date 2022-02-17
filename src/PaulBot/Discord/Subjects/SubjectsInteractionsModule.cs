using Discord;
using Discord.Interactions;
using PaulBot.Discord.Subjects.Contracts;
using PaulBot.Extensions;

namespace PaulBot.Discord.Subjects;

public class SubjectsInteractionsModule : InteractionModuleBase<SocketInteractionContext>
{
    private readonly ISubjectsService _service;

    public SubjectsInteractionsModule(ISubjectsService service)
    {
        _service = service;
    }

    [RequireUserPermission(GuildPermission.ManageGuild)]
    [RequireBotPermission(GuildPermission.ManageChannels | GuildPermission.ManageRoles)]
    [SlashCommand("create-subject", "Creates a new subject with associated role and channel")]
    public async Task CreateSubjectAsync(
        [Summary("code", "Code of the subject (4IZ101)")] string code, 
        [Summary("name", "Name of the subject (Programování v Javě)")] string name
    )
    {
        await DeferAsync();

        var subject = await _service.CreateSubject(code, name);
        var embed = new EmbedBuilder()
            .WithColor(DiscordColor.Green)
            .WithTitle("Subject created")
            .AddField("Code", subject.Code, true)
            .AddField("Name", subject.Name, true)
            .AddField("Channel", subject.ChannelId.AsChannelMention())
            .AddField("Role", subject.RoleId.AsRoleMention())
            .WithCurrentTimestamp()
            .Build();

        await FollowupAsync(embed: embed);
    }
}