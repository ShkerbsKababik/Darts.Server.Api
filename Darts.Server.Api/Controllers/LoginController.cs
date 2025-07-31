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

    [HttpPost("/login")]
    public string Login(LoginDTO loginDTO)
    {
        return _securityService.GenerateToken(
            login: loginDTO.Login, 
            password: loginDTO.Password);
    }

    [HttpGet("/login/check")]
    [Authorize]
    public IActionResult CheckLogin()
    {
        return Ok("authorized");
    }
}
