using Microsoft.AspNetCore.Mvc;
using Domain.Entities;
using Infrastructure.Services;
using Domain.PaginationFilter;
using Domain.Wrapper;
using Domain.Dtos;

namespace WebApi.Controllers;
[ApiController]
[Route("[controller]")]

public class CategoryController
{
    public readonly CategoryService _categoryService;
    public CategoryController(CategoryService categoryService)
    {
        _categoryService = categoryService;
    }
    [HttpGet("GetCategory")]
    public async Task<Response<List<GetCategory>>> GetCategory()
    {
        return await _categoryService.GetCategory();
    }
     [HttpGet("GetCategoryWithFilter")]
    public async Task<PaginationResponse<List<GetCategory>>> GetMoviesWithFilter([FromQuery] MovieFilter filter)
    {
        return await _categoryService.GetMovies(filter);
    }
     [HttpPost("AddActor")]
    public async Task<Response<AddCategory>> AddActor(AddCategory category)
    {
        return await _categoryService.AddACategory(category);
    }
    
     [HttpDelete("Delete")]
    public async Task<Response<string>> Delete(int Id)
    {
        return await _categoryService.Delete(Id);
    }
}