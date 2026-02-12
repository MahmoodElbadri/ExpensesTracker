using ExpensesTracker.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ExpensesTracker.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BudgetController(IBudgetService _uow):ControllerBase
{
    [HttpGet("status")]
    [Authorize]
    public async Task<IActionResult> GetStatus()
    {
        var status = await _uow.GetBudgetStatusAsync();
        return Ok(status);
    }
}
