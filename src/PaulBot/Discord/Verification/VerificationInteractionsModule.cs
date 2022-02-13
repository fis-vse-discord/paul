using Discord;
using Discord.Interactions;
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
    public async Task CreateVerificationMessage()
    {
        var message = await _service.CreateVerificationMessageAsync();
        
        var embed = EmbedBuilders.Success("Verification message created");
        var components = new ComponentBuilder()
            .WithButton(ButtonBuilder.CreateLinkButton("View", message.GetJumpUrl()))
            .Build();

        await Context.Interaction.RespondAsync(ephemeral: true, embed: embed, components: components);
    }
}