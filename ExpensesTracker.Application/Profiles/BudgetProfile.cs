using AutoMapper;
using ExpensesTracker.Application.Dtos;
using ExpensesTracker.Core.Entities;

namespace ExpensesTracker.Application.Profiles;

public class BudgetProfile: Profile
{
    public BudgetProfile()
    {
        CreateMap<AddBudgetDto, Budget>();
    }
}
