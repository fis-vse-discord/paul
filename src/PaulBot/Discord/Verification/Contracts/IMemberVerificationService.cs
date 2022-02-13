using Discord;

namespace PaulBot.Discord.Verification.Contracts;

public interface IMemberVerificationService
{
    Task<IMessage> CreateVerificationMessageAsync();
}