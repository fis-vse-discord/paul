using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using PaulBot.Discord.Verification.Contracts;

namespace PaulBot.Discord.Verification.Controllers;

[Route("/verification")]
public class MemberVerificationController : Controller
{
    private readonly IMemberVerificationService _service;

    public MemberVerificationController(IMemberVerificationService service)
    {
        _service = service;
    }

    [Authorize]
    [HttpGet("/{id}")]
    public ActionResult ProcessVerification(ulong id)
    {
        return NotFound();
    }
}