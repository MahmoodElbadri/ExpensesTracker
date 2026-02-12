using ExpensesTracker.Application.Dtos;
using ExpensesTracker.Application.Interfaces;
using ExpensesTracker.Core.Response;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ExpensesTracker.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class CategoryController(ICategoryService _catService) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateCategory([FromBody] AddCategoryDto dto)
    {
        var catDto = await _catService.CreateCategoryAsync(dto);
        return CreatedAtAction(nameof(GetCategoryById), new { id = catDto.Id }, new ApiResponse<CategoryDto>(catDto));
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetCategoryById(int id)
    {
        var catDto = await _catService.GetCategoryByIdAsync(id);
        return Ok(new ApiResponse<CategoryDto>(catDto));
    }

    [HttpGet]
    public async Task<IActionResult> GetAllCategories()
    {
        var cats = await _catService.GetAllCategoriesAsync();
        return Ok(new ApiResponse<IEnumerable<CategoryDto>>(cats));
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> UpdateCategory(int id, [FromBody] AddCategoryDto dto)
    {
        await _catService.UpdateCategoryAsync(dto, id);
        return Ok(new ApiResponse<bool>(true));
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteCategory(int id)
    {
        await _catService.DeleteCategoryAsync(id);
        return Ok(new ApiResponse<bool>(true));
    }

}
