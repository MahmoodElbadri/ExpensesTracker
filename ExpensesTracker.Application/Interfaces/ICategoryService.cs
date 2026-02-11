using ExpensesTracker.Application.Dtos;
using ExpensesTracker.Core.Entities;

namespace ExpensesTracker.Application.Interfaces;

public interface ICategoryService
{
    Task<List<CategoryDto>> GetAllCategoriesAsync();
    Task<CategoryDto> GetCategoryByIdAsync(int id);
    Task<CategoryDto> CreateCategoryAsync(AddCategoryDto category);
    Task UpdateCategoryAsync(AddCategoryDto category, int categoryId);
    Task DeleteCategoryAsync(int id);
}
