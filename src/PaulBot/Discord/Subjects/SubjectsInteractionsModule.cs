using Discord;
using Discord.Interactions;
using PaulBot.Discord.Subjects.Contract;
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

    [RequireUserPermission(GuildPermission.ManageGuild)]
    [RequireBotPermission(GuildPermission.ManageChannels | GuildPermission.ManageRoles)]
    [SlashCommand("delete-subject", "Deleted the specified subject and the associated role (and optionally channel)")]
    public async Task DeleteSubjectAsync(
        [Summary("code", "Code of the subject that should be deleted")] string code,
        [Summary("delete-text-channel", "Set this to true to also delete the associated text channel")] 
        bool deleteTextChannel = false
    )
    {
        await DeferAsync();
        
        var subject = await _service.DeleteSubject(code, deleteTextChannel);
        var embed = new EmbedBuilder()
            .WithColor(DiscordColor.Green)
            .WithTitle($"Subject {subject.Code} deleted")
            .WithCurrentTimestamp()
            .Build();

        await FollowupAsync(embed: embed);
    }
}