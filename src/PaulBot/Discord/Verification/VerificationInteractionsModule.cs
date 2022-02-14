using Discord;
using Discord.Interactions;
using Discord.WebSocket;
using PaulBot.Discord.Verification.Contracts;

namespace PaulBot.Discord.Verification;

public class VerificationInteractionsModule : InteractionModuleBase<SocketInteractionContext>
{
    private readonly IMemberVerificationService _service;

    public VerificationInteractionsModule(IMemberVerificationService service)
    {
        _service = service;
    }

    [RequireOwner]
    [SlashCommand("verification-message", "Creates a verification message with all required components")]
    public async Task CreateVerificationMessage(SocketTextChannel channel)
    {
        var embed = new EmbedBuilder()
            .WithColor(DiscordColor.University)
            .WithThumbnailUrl("https://i.imgur.com/ayvk2sf.png")
            .WithTitle("Ověření školního účtu VŠE")
            .WithDescription("Pro získání odkazu s ověřením klikněte na tlačítko pod zprávou.")
            .Build();
        
        var components = new ComponentBuilder()
            .WithButton(ButtonBuilder.CreateSecondaryButton("🔑 Ověření školního účtu VŠE", "verification"))
            .Build();

        var message = await channel.SendMessageAsync(embed: embed, components: components);

        await Context.Interaction.RespondAsync(
            ephemeral: true,
            embed: EmbedBuilders.Success("Verification message created"),
            components: new ComponentBuilder()
                .WithButton(ButtonBuilder.CreateLinkButton("View", message.GetJumpUrl()))
                .Build()
        );
    }

    [ComponentInteraction("verification")]
    public async Task GetVerificationLink()
    {
        var verification = await _service.CreateMemberVerificationAsync(Context.User.Id);
        
        // TODO: Generate verification link dynamically
        var link = $"https://localhost:5001/verification/{verification.Id}";

        var embed = new EmbedBuilder()
            .WithAuthor(Context.User.Username, Context.User.GetAvatarUrl())
            .Build();
            
        var component = new ComponentBuilder()
            .WithButton(ButtonBuilder.CreateLinkButton("Tvůj unikátní odkaz", link))
            .Build();

        await Context.Interaction.RespondAsync(ephemeral: true, embed: embed, components: component);
    }
}