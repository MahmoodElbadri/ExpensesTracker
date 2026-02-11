using AutoMapper;
using ExpensesTracker.Application.Dtos;
using ExpensesTracker.Application.Exceptions;
using ExpensesTracker.Application.Interfaces;
using ExpensesTracker.Core.Entities;

namespace ExpensesTracker.Infrastructure.Services;

public class CategoryService(IUnitOfWork uow, IMapper mapper, ICurrentUserService currentUser) : ICategoryService
{
    public async Task<CategoryDto> CreateCategoryAsync(AddCategoryDto dto)
    {
        var user = await currentUser.GetUserIdAsync();
        if (user == null)
        {
            throw new Exception("User not found");
        }
        var category = mapper.Map<AddCategoryDto, Category>(dto);
        category.UserId = user;
        if (string.IsNullOrEmpty(category.Color)) category.Color = "#000000";
        if (string.IsNullOrEmpty(category.Icon)) category.Icon = "fa-tag";
        await uow.Categories.AddAsync(category);
        await uow.CompleteAsync();

        // Map the properties of category to dto
        var dtoResult = mapper.Map<Category, CategoryDto>(category);
        return dtoResult;
    }

    public async Task DeleteCategoryAsync(int id)
    {
        var user = await currentUser.GetUserIdAsync();
        if (user == null)
        {
            throw new Exception("User not found");
        }
        var category = await uow.Categories.FindAsync(tmp => tmp.Id == id && tmp.UserId == user);
        var categoryToDelete = category.FirstOrDefault();
        if (categoryToDelete == null)
        {
            throw new NotFoundException(nameof(Category), id.ToString());
        }
        uow.Categories.Delete(categoryToDelete);
        await uow.CompleteAsync();
    }

    public async Task<List<CategoryDto>> GetAllCategoriesAsync()
    {
        var user = await currentUser.GetUserIdAsync();
        if (user == null)
        {
            throw new Exception("User not found");
        }
        var categories = await uow.Categories.FindAsync(tmp => tmp.UserId == user);
        return mapper.Map<List<Category>, List<CategoryDto>>(categories.ToList());
    }

    public async Task<CategoryDto> GetCategoryByIdAsync(int id)
    {
        var user = await currentUser.GetUserIdAsync();
        if (user == null)
        {
            throw new Exception("User not found");
        }
        var category = await uow.Categories.FindAsync(tmp => tmp.Id == id && tmp.UserId == user);
        if (category == null)
        {
            throw new NotFoundException(nameof(Category), id.ToString());
        }
        return mapper.Map<Category, CategoryDto>(category.First());
    }

    public async Task UpdateCategoryAsync(AddCategoryDto category, int id)
    {
        var user = await currentUser.GetUserIdAsync();
        if (user == null)
        {
            throw new Exception("User not found");
        }
        var cat = await uow.Categories.FindAsync(tmp => tmp.Id == id && tmp.UserId == user);
        if (cat == null)
        {
            throw new NotFoundException(nameof(Category), id.ToString());
        }
        mapper.Map(category, cat.First());
       await uow.CompleteAsync();
    }
}
