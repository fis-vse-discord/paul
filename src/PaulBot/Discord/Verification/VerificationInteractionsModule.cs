using Discord.Interactions;
using PaulBot.Discord.Verification.Contracts;

namespace PaulBot.Discord.Verification;

public class VerificationInteractionsModule : InteractionModuleBase<SocketInteractionContext>
{

    [ComponentInteraction("verification")]
    public async Task VerificationButtonInteraction(IMemberVerificationService service)
    {
        await Context.Interaction.RespondAsync("Verification...");
    }
}