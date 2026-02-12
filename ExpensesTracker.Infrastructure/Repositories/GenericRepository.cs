using ExpensesTracker.Application.Interfaces;
using ExpensesTracker.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Transactions;

namespace ExpensesTracker.Infrastructure.Repositories;

public class GenericRepository<T>(ExpenseDbContext db) : IGenericRepository<T> where T : class
{
    public async Task AddAsync(T entity)
    {
        await db.Set<T>().AddAsync(entity);
    }

    public void Delete(T entity)
    {
        db.Set<T>().Remove(entity);
    }

    public async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> expression)
    {
        return await db.Set<T>().Where(expression).ToListAsync();
    }

    public async Task<IEnumerable<T>> GetAllAsync()
    {
        return await db.Set<T>().ToListAsync();
    }

    public async Task<T?> GetByIdAsync(int id)
    {
        return await db.Set<T>().FindAsync(id);
    }

    public void Update(T entity)
    {
        db.Set<T>().Update(entity);
    }

    public async Task<decimal> GetSumAsync(Expression<Func<T, bool>> predicate, Expression<Func<T, decimal>> selector)
    {
        return await db.Set<T>().Where(predicate).SumAsync(selector);
    }

    public async Task<IEnumerable<T>> FindWithIncludeAsync(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes)
    {
        IQueryable<T> query = db.Set<T>();

        foreach (var include in includes)
        {
            query = query.Include(include);
        }

        return await query.Where(predicate).ToListAsync();
    }
}
