using AutoMapper;
using ExpensesTracker.Application.Dtos;
using ExpensesTracker.Application.Interfaces;
using ExpensesTracker.Application.ServiceContracts;
using ExpensesTracker.Core.Entities;
using ExpensesTracker.Core.Enums;

namespace ExpensesTracker.Infrastructure.Services;

public class TransactionServices(IMapper mapper, IUnitOfWork uow) : ITransactionService
{
    public async Task<bool> CreateTransactionAsync(AddTransactionDto dto)
    {
        var transaction = mapper.Map<AddTransactionDto, Transaction>(dto);
        await uow.Transactions.AddAsync(transaction);
        return await uow.CompleteAsync() > 0;
    }

    public Task<bool> DeleteTransactionAsync(int transactionId)
    {
        throw new NotImplementedException();
    }

    public async Task<List<TransactionDto>> GetAllTransactionsAsync()
    {
        var transactions = await uow.Transactions.GetAllAsync();
        var dtos = mapper.Map<List<TransactionDto>>(transactions);
        return dtos;
    }

    public async Task<DashboardDto> GetDashboardAsync()
    {
        var transactions = await uow.Transactions.GetAllAsync();
        //getting dashboard items which are total income and total expense and balance based on amound and type

        var TotalExpense = transactions.Where(tmp => tmp.Type == TRANSACTION_TYPES.EXPENSE).Sum(tmp => tmp.Amount);
        var TotalIncome = transactions.Where(tmp => tmp.Type == TRANSACTION_TYPES.INCOME).Sum(tmp => tmp.Amount);
        var Balance = TotalIncome - TotalExpense;

        var dashboard = new DashboardDto()
        {
            TotalExpense = TotalExpense,
            TotalIncome = TotalIncome,
            Balance = Balance
        };
        
        return dashboard;
    }

    public Task<TransactionDto?> GetTransactionByIdAsync(int transactionId)
    {
        throw new NotImplementedException();
    }

    public Task UpdateTransactionAsync(AddTransactionDto transaction)
    {
        throw new NotImplementedException();
    }
}