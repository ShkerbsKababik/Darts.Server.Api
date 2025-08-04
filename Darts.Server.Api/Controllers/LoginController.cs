using Darts.Server.Application.DTO;
using Darts.Server.Infrastructure.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Darts.Server.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LoginController : ControllerBase
{
    private readonly ISecurityService _securityService;

    public LoginController(ISecurityService securityService)
    {
        _securityService = securityService;
    }

    [HttpPost("/auth")]
    public string GetJwtToken(LoginDTO loginDTO)
    {
        return _securityService.GenerateToken(
            login: loginDTO.Login, 
            password: loginDTO.Password);
    }

    [HttpGet("/auth/check")]
    [Authorize]
    public IActionResult CheackAuthorization()
    {
        return Ok("authorized");
    }
}
