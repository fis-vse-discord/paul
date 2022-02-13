using Discord;
using PaulBot.Discord.Verification.Contracts;
using PaulBot.Discord.Verification.Models;

namespace PaulBot.Discord.Verification.Services;

public class MemberMemberVerificationService : IMemberVerificationService
{
    public Task<MemberVerification> CreateMemberVerification(ulong memberId)
    {
        throw new NotImplementedException();
    }

    public Task<MemberVerification> CompleteVerification(ulong memberId, string azureId)
    {
        throw new NotImplementedException();
    }
}