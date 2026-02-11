using ExpensesTracker.Application.Dtos;

namespace ExpensesTracker.Application.Interfaces;

public interface IBudgetService
{
    Task<List<BudgetStatusDto>> GetBudgetStatusAsync();
}
