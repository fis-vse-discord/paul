using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PaulBot.Discord.Verification.Contracts;

namespace PaulBot.Controllers;

public class MemberVerificationsController : Controller
{
    private readonly IMemberVerificationService _service;
    
    private const string IdClaimType = "http://schemas.microsoft.com/identity/claims/objectidentifier";

    private const string GroupsClaimType = "groups";

    public MemberVerificationsController(IMemberVerificationService service)
    {
        _service = service;
    }

    [Authorize]
    [HttpGet("/verification/{id:guid}")]
    public async Task<ActionResult> ProcessVerification(Guid id)
    {
        try
        {
            var azureId = User.Claims.First(c => c.Type == IdClaimType).Value;
            var azureGroups = User.Claims.Where(c => c.Type == GroupsClaimType).Select(c => c.Value);

            await _service.CompleteVerificationAsync(id, azureId, azureGroups);

            return Redirect("/Success.html");
        }
        catch (ApplicationException exception)
        {
            return Redirect("/Failure.html");
        }
    }
}