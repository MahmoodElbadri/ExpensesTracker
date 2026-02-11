using ExpensesTracker.Application.Dtos;
using ExpensesTracker.Application.Interfaces;
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
        return CreatedAtAction(nameof(GetCategoryById), new { id = catDto.Id }, catDto);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetCategoryById(int id)
    {
        return Ok(await _catService.GetCategoryByIdAsync(id));
    }

    [HttpGet]
    public async Task<IActionResult> GetAllCategories()
    {
        return Ok(await _catService.GetAllCategoriesAsync());
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> UpdateCategory(int id, [FromBody] AddCategoryDto dto)
    {
        await _catService.UpdateCategoryAsync(dto, id);
        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteCategory(int id)
    {
        await _catService.DeleteCategoryAsync(id);
        return NoContent();
    }

}
