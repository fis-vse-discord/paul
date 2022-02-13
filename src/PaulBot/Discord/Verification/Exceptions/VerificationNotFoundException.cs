namespace PaulBot.Discord.Verification.Exceptions;

public class VerificationNotFoundException : ApplicationException
{
    public VerificationNotFoundException() : base("Verification with the specified ID could not be found.")
    {
    }
}