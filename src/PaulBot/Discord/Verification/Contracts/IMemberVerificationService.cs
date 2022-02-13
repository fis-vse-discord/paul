using Discord;
using Discord.WebSocket;
using PaulBot.Discord.Verification.Models;

namespace PaulBot.Discord.Verification.Contracts;

public interface IMemberVerificationService
{
    Task<MemberVerification> CreateMemberVerification(ulong memberId);

    Task<MemberVerification> CompleteVerification(ulong memberId, string azureId, IEnumerable<string> azureGroups);
}