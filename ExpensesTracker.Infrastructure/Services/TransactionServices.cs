using AutoMapper;
using ExpensesTracker.Application.Dtos;
using ExpensesTracker.Application.Interfaces;
using ExpensesTracker.Application.ServiceContracts;
using ExpensesTracker.Core.Entities;

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

    public Task<TransactionDto?> GetTransactionByIdAsync(int transactionId)
    {
        throw new NotImplementedException();
    }

    public Task UpdateTransactionAsync(AddTransactionDto transaction)
    {
        throw new NotImplementedException();
    }
}