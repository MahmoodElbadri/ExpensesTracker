using ExpensesTracker.Core.Entities;

namespace ExpensesTracker.Application.Interfaces;

public interface IUnitOfWork : IDisposable
{
    public IGenericRepository<Transaction> Transactions { get; }
    public IGenericRepository<Category> Categories { get; }
    public Task<int> CompleteAsync();
}
