namespace PaulBot.Discord.Verification.Exceptions;

public class BlockedRoleMembershipException : ApplicationException
{
    public BlockedRoleMembershipException() : base("The user has active membership in one of the blocked groups")
    {
    }
}