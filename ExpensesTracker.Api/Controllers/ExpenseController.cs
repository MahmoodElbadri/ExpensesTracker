using AutoMapper;
using ExpensesTracker.Application.Dtos;
using ExpensesTracker.Application.Interfaces;
using ExpensesTracker.Application.ServiceContracts;
using ExpensesTracker.Core.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ExpensesTracker.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
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
        return Ok(transactions);
    }

    [HttpPost]
    public async Task<IActionResult> AddExpense([FromBody] AddTransactionDto dto)
    {
       var transaction = await _transactionService.CreateTransactionAsync(dto);
        return Ok();
    }

}
