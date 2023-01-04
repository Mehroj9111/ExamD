namespace Infrastructure.Services;
using Domain.Entities;
using Domain.Dtos;
using AutoMapper;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Domain.PaginationFilter;
using System.Net;
using Domain.Wrapper;

public class MovieService
{
   public readonly DataContext _context;
   public readonly IMapper _mapper;
   public MovieService(DataContext context , IMapper mapper)
   {
        _context = context;
        _mapper =mapper;
   } 
    // _ _ _ _ _ _ _ _ _ _ _GetAllMovie_ _ _ _ _ _ _ _ _ _ _ _ _ _ 
   public async Task<Response<List<GetMovie>>> GetMovie()
   {
    try
    {
    var list = _mapper.Map<List<GetMovie>>(await _context.Movies.ToListAsync());
    return new Response<List<GetMovie>>(list);
   }
    catch
    {
         return new Response<List<GetMovie>>(System.Net.HttpStatusCode.InternalServerError, "YOU WERE WRONG");
    }
    }
       // _ _ _ _ _ _ _ _ _ _ _GetAllMovieWithFilter_ _ _ _ _ _ _ _ _ _ _ _ _ _ 
   public async Task<PaginationResponse<List<GetMovie>>> GetMovies(MovieFilter filter)
   {
     var query = _context.Movies.AsQueryable();

     if(filter.Name == null) query = query.Where(x=>x.Title != null);
     if(filter.Name != null) query = query.Where(x=>x.Title.Contains(filter.Name));
     if (filter.CategoryId != null) query = query.Where(x => x.CategoryId == filter.CategoryId);
     var fil = query.Skip((filter.PageNumber - 1) * filter.PageSize).Take(filter.PageSize).ToList();
     var var =  _mapper.Map<List<GetMovie>>(fil);
     var totalRecords = await _context.Movies.CountAsync();
      return new PaginationResponse<List<GetMovie>>(var, totalRecords, filter.PageSize, filter.PageNumber);
    }
     // _ _ _ _ _ _ _ _ _ _ _AddMovie_ _ _ _ _ _ _ _ _ _ _ _ _ _ 
    public async Task<Response<AddMovie>> AddMovie(AddMovie addMovie)
    {
     try
     {
         var newMovie= new Movie()
        {
            Title = addMovie.Title,
            MovieYear = addMovie.MovieYear,
            CategoryId = addMovie.CategoriyId
        };
        _context.Movies.Add(newMovie);
        await _context.SaveChangesAsync();
        return new Response<AddMovie>(_mapper.Map<AddMovie>(newMovie));
     }
     catch (System.Exception)
     {
       return  new Response<AddMovie>(System.Net.HttpStatusCode.InternalServerError, "YOU WERE WRONG");
     }
    }

    // _ _ _ _ _ _ _ _ _ _ _DeletedMovie_ _ _ _ _ _ _ _ _ _ _ _ _ _
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