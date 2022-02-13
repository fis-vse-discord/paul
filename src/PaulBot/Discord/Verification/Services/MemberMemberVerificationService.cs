using Discord.WebSocket;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using PaulBot.Configuration;
using PaulBot.Data;
using PaulBot.Discord.Verification.Configuration;
using PaulBot.Discord.Verification.Contracts;
using PaulBot.Discord.Verification.Exceptions;
using PaulBot.Discord.Verification.Models;

namespace PaulBot.Discord.Verification.Services;

public class MemberMemberVerificationService : IMemberVerificationService
{
    private readonly DiscordSocketClient _client;
    
    private readonly PaulBotDbContext _context;

    private readonly DiscordConfiguration _discordConfiguration;

    private readonly VerificationConfiguration _verificationConfiguration;

    public MemberMemberVerificationService(
        PaulBotDbContext context,
        DiscordSocketClient client,
        IOptions<VerificationConfiguration> configuration,
        IOptions<DiscordConfiguration> discordConfiguration
    )
    {
        _context = context;
        _client = client;
        _verificationConfiguration = configuration.Value;
        _discordConfiguration = discordConfiguration.Value;
    }

    public async Task<MemberVerification> CreateMemberVerification(ulong memberId)
    {
        var verification = await _context.Verifications.FirstOrDefaultAsync(v => v.MemberId == memberId);

        if (verification != null)
        {
            return verification;
        }

        var created = new MemberVerification {MemberId = memberId};

        await _context.Verifications.AddAsync(created);
        await _context.SaveChangesAsync();

        return created;
    }

    public async Task<MemberVerification> CompleteVerification(ulong memberId, string azureId, IEnumerable<string> azureGroups)
    {
        var verification = await _context.Verifications.FirstOrDefaultAsync(v => v.MemberId == memberId)
                           ?? throw new VerificationNotFoundException();
        
        // If any of the user roles is blocked, halt the verification process
        if (azureGroups.Any(g => _verificationConfiguration.BlacklistedGroups.Contains(g)))
        {
            throw new BlockedRoleMembershipException();
        }
        
        // If the verification was already used and it belongs to another account
        if (verification.AzureId != null && verification.AzureId == azureId)
        {
            throw new VerificationAlreadyUsedException();
        }
        
        // If the verification was revoked by one of the bot administrators
        if (verification.IsRevoked)
        {
            throw new VerificationRevokedException();
        }

        // TODO: Use domain exceptions for handling this
        var guild = _client.GetGuild(_discordConfiguration.GuildId) ?? throw new ApplicationException();
        var member = guild.GetUser(memberId) ?? throw new ApplicationException();

        await member.AddRoleAsync(_verificationConfiguration.VerificationRoleId);

        return verification;
    }
}