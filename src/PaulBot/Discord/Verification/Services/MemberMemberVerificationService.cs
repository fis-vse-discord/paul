using Microsoft.Extensions.Options;
using PaulBot.Data;
using PaulBot.Discord.Verification.Configuration;
using PaulBot.Discord.Verification.Contracts;
using PaulBot.Discord.Verification.Models;

namespace PaulBot.Discord.Verification.Services;

public class MemberMemberVerificationService : IMemberVerificationService
{
    private readonly PaulBotDbContext _context;

    private readonly VerificationConfiguration _configuration;

    public MemberMemberVerificationService(PaulBotDbContext context, IOptions<VerificationConfiguration> configuration)
    {
        _context = context;
        _configuration = configuration.Value;
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