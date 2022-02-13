using PaulBot.Data;
using PaulBot.Discord.Verification.Configuration;
using PaulBot.Discord.Verification.Contracts;
using PaulBot.Discord.Verification.Models;

namespace PaulBot.Discord.Verification.Services;

public class MemberMemberVerificationService : IMemberVerificationService
{
    private readonly PaulBotDbContext _context;

    private readonly VerificationConfiguration _configuration;

    public MemberMemberVerificationService(PaulBotDbContext context, VerificationConfiguration configuration)
    {
        _context = context;
        _configuration = configuration;
    }

    public Task<MemberVerification> CreateMemberVerification(ulong memberId)
    {
        throw new NotImplementedException();
    }

    public Task<MemberVerification> CompleteVerification(ulong memberId, string azureId)
    {
        throw new NotImplementedException();
    }
}