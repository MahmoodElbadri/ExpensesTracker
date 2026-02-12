using ExpensesTracker.Application.Dtos;
using ExpensesTracker.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using ExpensesTracker.Core.Response;

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
        return (status != null) ? Ok(new ApiResponse<IEnumerable< BudgetStatusDto>>(status)) : NotFound(new ApiResponse<BudgetStatusDto>("No budget found"));
    }

    [HttpPost]
    public async Task<IActionResult> CreateBudget(AddBudgetDto dto)
    {
        var budget = await _budgetService.CreateBudgetAsync(dto);
        return (budget) ? Ok(new ApiResponse<bool>(budget)) : BadRequest(new ApiResponse<bool>("Failed to create budget"));
    }
}
