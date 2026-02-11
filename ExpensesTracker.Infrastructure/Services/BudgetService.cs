using AutoMapper;
using ExpensesTracker.Application.Dtos;
using ExpensesTracker.Application.Interfaces;

namespace ExpensesTracker.Infrastructure.Services;

public class BudgetService(IUnitOfWork uow, IMapper mapper, ICurrentUserService currentUser) : IBudgetService
{
    public async Task<List<BudgetStatusDto>> GetBudgetStatusAsync()
    {
        var userId = await currentUser.GetUserIdAsync();
        if(userId == null)
        {
            throw new Exception("User not found");
        }

        //var budgets = await uow.
        throw new NotImplementedException();
        //TODO tomorrow i need ti add the uow -add the budget- and the mapper
    }
}
