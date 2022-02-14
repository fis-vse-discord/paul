using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PaulBot.Discord.Verification.Contracts;

namespace PaulBot.Discord.Verification.Controllers;

public class MemberVerificationController : Controller
{
    private readonly IMemberVerificationService _service;

    public MemberVerificationController(IMemberVerificationService service)
    {
        _service = service;
    }

    [Authorize]
    [HttpGet("/verification/{id}")]
    public ActionResult ProcessVerification(ulong id)
    {
        return Accepted();
    }
}