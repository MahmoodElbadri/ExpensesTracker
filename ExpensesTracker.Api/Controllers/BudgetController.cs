using ExpensesTracker.Application.Dtos;
using ExpensesTracker.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ExpensesTracker.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class BudgetController(IBudgetService _budgetService) : ControllerBase
{
    [HttpGet("status")]
    public async Task<IActionResult> GetStatus()
    {
        var status = await _budgetService.GetBudgetStatusAsync();
        return (status != null) ? Ok(status) : NotFound("No budget found");
    }

    [HttpPost]
    public async Task<IActionResult> CreateBudget(AddBudgetDto dto)
    {
        var budget = await _budgetService.CreateBudgetAsync(dto);
        return (budget) ? Ok(new { message = "Budget created successfully" }) : BadRequest("Failed to create budget");
    }
}
