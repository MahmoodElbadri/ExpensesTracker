using ExpensesTracker.Application.Dtos;
using ExpensesTracker.Application.ServiceContracts;
using Microsoft.AspNetCore.Mvc;

namespace ExpensesTracker.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController:ControllerBase
{
    private readonly IAuthService _authService;
    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginDto dto)
    {
        var token = await _authService.LoginUserAsync(dto);
        return Ok(token);
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterDto dto)
    {
        var token = await _authService.RegisterUserAsync(dto);
        return Ok(token);
    }
}
