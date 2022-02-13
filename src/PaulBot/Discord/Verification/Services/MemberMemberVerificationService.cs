using Discord;
using PaulBot.Discord.Verification.Contracts;

namespace PaulBot.Discord.Verification.Services;

public class MemberMemberVerificationService : IMemberVerificationService
{
    public Task<IMessage> CreateVerificationMessageAsync()
    {
        throw new NotImplementedException();
    }
}