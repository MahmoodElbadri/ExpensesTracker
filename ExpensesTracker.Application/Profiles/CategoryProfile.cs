using AutoMapper;
using ExpensesTracker.Application.Dtos;
using ExpensesTracker.Core.Entities;

namespace ExpensesTracker.Application.Profiles;

public class CategoryProfile:Profile
{
    public CategoryProfile()
    {
        CreateMap<AddCategoryDto, Category>();
        CreateMap<Category, CategoryDto>();
    }
}
