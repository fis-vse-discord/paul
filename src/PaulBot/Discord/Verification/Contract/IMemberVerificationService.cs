using PaulBot.Discord.Verification.Models;

namespace PaulBot.Discord.Verification.Contract;

public interface IMemberVerificationService
{
    Task<MemberVerification> CreateMemberVerificationAsync(ulong memberId);

    Task<MemberVerification> CompleteVerificationAsync(Guid id, string azureId, IEnumerable<string> azureGroups);
}