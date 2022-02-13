namespace PaulBot.Discord.Verification.Exceptions;

public class VerificationRevokedException : ApplicationException
{
    public VerificationRevokedException() : base("This verification was revoked by the administrators")
    {
    }
}