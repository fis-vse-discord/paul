using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PaulBot.Discord.Verification.Contracts;
using PaulBot.Discord.Verification.Exceptions;

namespace PaulBot.Discord.Verification.Controllers;

public class MemberVerificationController : Controller
{
    private readonly IMemberVerificationService _service;

    public MemberVerificationController(IMemberVerificationService service)
    {
        _service = service;
    }

    [Authorize]
    [HttpGet("/verification/{id:guid}")]
    public async Task<ActionResult> ProcessVerification(Guid id)
    {
        try
        {
            var verification = await _service.GetMemberVerificationAsync(id);
            // TODO: Complete member verification
        }
        catch (VerificationNotFoundException)
        {
            return NotFound();
        }
        
        return Accepted();
    }
}