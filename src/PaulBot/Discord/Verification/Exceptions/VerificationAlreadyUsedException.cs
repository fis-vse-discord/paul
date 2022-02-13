namespace PaulBot.Discord.Verification.Exceptions;

public class VerificationAlreadyUsedException : ApplicationException
{
    public VerificationAlreadyUsedException() : base("This verification was already used by another member.")
    {
    }
}