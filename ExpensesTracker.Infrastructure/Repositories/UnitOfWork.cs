using ExpensesTracker.Application.Interfaces;
using ExpensesTracker.Core.Entities;
using ExpensesTracker.Infrastructure.Data;

namespace ExpensesTracker.Infrastructure.Repositories;

public class UnitOfWork : IUnitOfWork
{
    public IGenericRepository<Transaction> Transactions { get; private set; }
    private readonly ExpenseDbContext db;

    public UnitOfWork(ExpenseDbContext db)
    {
        this.db = db;
        Transactions = new GenericRepository<Transaction>(db);
    }

    public async Task<int> CompleteAsync()
    {
        return await db.SaveChangesAsync();
    }

    public void Dispose()
    {
        db.Dispose();
    }
}
