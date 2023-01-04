namespace Infrastructure.Services;
using Domain.Entities;
using Domain.Dtos;
using AutoMapper;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Domain.PaginationFilter;
using System.Net;
using Domain.Wrapper;

public class CategoryService
{
    public readonly DataContext _context;
    public readonly IMapper _mapper;

    public CategoryService(DataContext context , IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    // _ _ _ _ _ _ _ _ _ _ _GetAllCategory_ _ _ _ _ _ _ _ _ _ _ _ _ _ 
    public async Task<Response<List<GetCategory>>> GetCategory()
    {
    try
    {
        var list = _mapper.Map<List<GetCategory>>(await _context.Categories.ToListAsync());
        return new Response<List<GetCategory>>(list);
    }
   catch
    {
            return new Response<List<GetCategory>>(System.Net.HttpStatusCode.InternalServerError, "YOU WERE WRONG");
    }
}
  // _ _ _ _ _ _ _ _ _ _ _GetAllCaategoryWithFilter_ _ _ _ _ _ _ _ _ _ _ _ _ _ 
   public async Task<PaginationResponse<List<GetCategory>>> GetMovies(MovieFilter filter)
   {
     var query = _context.Categories.AsQueryable();

     if(filter.Name == null) query = query.Where(x=>x.Title != null);
     if(filter.Name != null) query = query.Where(x=>x.Title.Contains(filter.Name));
     var fil = query.Skip((filter.PageNumber - 1) * filter.PageSize).Take(filter.PageSize).ToList();
     var var =  _mapper.Map<List<GetCategory>>(fil);
     var totalRecords = await _context.Movies.CountAsync();
      return new PaginationResponse<List<GetCategory>>(var, totalRecords, filter.PageSize, filter.PageNumber);
    }

  // _ _ _ _ _ _ _ _ _ _ _AddCategory_ _ _ _ _ _ _ _ _ _ _ _ _ _ 
  public async Task<Response<AddCategory>> AddACategory(AddCategory category)
    {
    try
    { 
        var newCategory = new Category()
        {
            Title = category.Title
        };
        _context.Categories.Add(newCategory);
        await _context.SaveChangesAsync();
        return new Response<AddCategory>(_mapper.Map<AddCategory>(newCategory));
    }
     catch
    {
         return new Response<AddCategory>(System.Net.HttpStatusCode.InternalServerError, "YOU WERE WRONG");
    }
    }

    // _ _ _ _ _ _ _ _ _ _ _DeletedCategory_ _ _ _ _ _ _ _ _ _ _ _ _ _
    public async Task<Response<string>> Delete(int Id)
    {
    try
    {
        var actor = await _context.Actors.FindAsync(Id);
        _context.Actors.Remove(actor);
        var result = await _context.SaveChangesAsync();
         if (result > 0) {
            return new Response<string>("MOVIE SUCCESSFULLY DELETED");
        }
        else{
            return new Response<string>(HttpStatusCode.BadRequest,"MOVIE NOT FOUND");
        }
    }
     catch
    {
         return new Response<string>(System.Net.HttpStatusCode.InternalServerError, "YOU WERE WRONG");
    }
    }

}