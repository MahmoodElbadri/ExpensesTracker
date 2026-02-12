using AutoMapper;
using ExpensesTracker.Application.Dtos;
using ExpensesTracker.Application.Interfaces;
using ExpensesTracker.Application.ServiceContracts;
using ExpensesTracker.Core.Entities;
using ExpensesTracker.Core.Response;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ExpensesTracker.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class ExpenseController : ControllerBase
{
    private readonly ITransactionService _transactionService;

    public ExpenseController(ITransactionService service)
    {
        _transactionService = service;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<TransactionDto>>> GetTransactions()
    {
        var transactions = await _transactionService.GetAllTransactionsAsync();
        return Ok(new ApiResponse<IEnumerable<TransactionDto>>(transactions));
    }

    [HttpPost]
    public async Task<IActionResult> AddExpense([FromBody] AddTransactionDto dto)
    {
       var transaction = await _transactionService.CreateTransactionAsync(dto);
        return Ok(new ApiResponse<bool>(true));
    }

    [HttpGet("dashboard")]
    public async Task<ActionResult<DashboardDto>> GetDashboard()
    {
        var dashboard = await _transactionService.GetDashboardAsync();
        return Ok(new ApiResponse<DashboardDto>(dashboard));
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteTransaction(int id)
    {
        await _transactionService.DeleteTransactionAsync(id);
        return NoContent();
    }

    [HttpPut("{id:int}")] 
    public async Task<IActionResult> UpdateTransaction(int id, [FromBody] AddTransactionDto dto)
    {
        await _transactionService.UpdateTransactionAsync(dto, id);
        return NoContent();
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<TransactionDto>> GetTransactionById(int id)
    {
        var transaction = await _transactionService.GetTransactionByIdAsync(id);
        return Ok(new ApiResponse<TransactionDto>(transaction));
    }

}
