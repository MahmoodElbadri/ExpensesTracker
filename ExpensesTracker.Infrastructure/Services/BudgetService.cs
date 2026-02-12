using AutoMapper;
using ExpensesTracker.Application.Dtos;
using ExpensesTracker.Application.Interfaces;
using ExpensesTracker.Core.Entities;
using ExpensesTracker.Core.Enums;

namespace ExpensesTracker.Infrastructure.Services;

public class BudgetService(IUnitOfWork uow, IMapper mapper, ICurrentUserService currentUser) : IBudgetService
{
    public async Task<bool> CreateBudgetAsync(AddBudgetDto budgetDto)
    {
        var userId = await currentUser.GetUserIdAsync();
        if (string.IsNullOrEmpty(userId)) throw new Exception("User not found");

        var isExist = await uow.Budgets.FindAsync(tmp=>tmp.UserId == userId &&
        tmp.CategoryId == budgetDto.CategoryId &&
        tmp.StartDate == budgetDto.StartDate &&
        tmp.EndDate == budgetDto.EndDate);

        if (isExist.Any()) throw new Exception("Budget already exist");

        var budget = mapper.Map<AddBudgetDto, Budget>(budgetDto);
        budget.UserId = userId;
        await uow.Budgets.AddAsync(budget);
        return await uow.CompleteAsync() > 0;
    }

    public async Task<List<BudgetStatusDto>> GetBudgetStatusAsync()
    {
        var userId = await currentUser.GetUserIdAsync(); 

        if (string.IsNullOrEmpty(userId)) throw new Exception("User not found");

        var now = DateTime.UtcNow;

        var budgets = await uow.Budgets.FindWithIncludeAsync(
            b => b.UserId == userId && b.StartDate <= now && b.EndDate >= now,
            b => b.Category 
        );

        var result = new List<BudgetStatusDto>();

        foreach (var budget in budgets)
        {
            var spent = await uow.Transactions.GetSumAsync(
                t => t.UserId == userId
                     && t.CategoryId == budget.CategoryId
                     && t.Date >= budget.StartDate
                     && t.Date <= budget.EndDate
                     && t.Type == TRANSACTION_TYPES.EXPENSE,
                t => t.Amount
            );

            result.Add(new BudgetStatusDto
            {
                CategoryName = budget.Category?.Name ?? "Unknown", 
                Limit = budget.Limit,
                Spent = spent
            });
        }

        return result;
    }
}
