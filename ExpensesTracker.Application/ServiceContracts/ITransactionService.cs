
using ExpensesTracker.Application.Dtos;
using ExpensesTracker.Core.Entities;

namespace ExpensesTracker.Application.ServiceContracts;

public interface ITransactionService
{
    Task<List<TransactionDto>> GetAllTransactionsAsync();
    Task<TransactionDto?> GetTransactionByIdAsync(int transactionId);
    Task<bool> CreateTransactionAsync(AddTransactionDto transaction);
    Task UpdateTransactionAsync(AddTransactionDto transaction);
    Task<bool> DeleteTransactionAsync(int transactionId);
}
