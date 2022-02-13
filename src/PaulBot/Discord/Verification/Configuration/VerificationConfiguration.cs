namespace PaulBot.Discord.Verification.Configuration;

public class VerificationConfiguration
{
    public const string Section = "Verification";
    
    public ulong VerificationRoleId { get; set; }
    
    public IEnumerable<string> BlacklistedGroups { get; set; } = null!;
}