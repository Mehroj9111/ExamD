using Microsoft.AspNetCore.Mvc;
using Domain.Entities;
using Infrastructure.Services;
using Domain.PaginationFilter;
using Domain.Wrapper;
using Domain.Dtos;

namespace WebApi.Controllers;
[ApiController]
[Route("[controller]")]

public class MovieController
{
    public readonly MovieService _movieService;
    public MovieController (MovieService movieService)
    {
        _movieService = movieService;
    }
    [HttpGet("GetMovies")]
    public async Task<Response<List<GetMovie>>> GetMovies()
    {
        return await _movieService.GetMovie();
    }
    [HttpGet("GetMoviesWithFilter")]
    public async Task<PaginationResponse<List<GetMovie>>> GetMoviesWithFilter([FromQuery] MovieFilter filter)
    {
        return await _movieService.GetMovies(filter);
    }
     [HttpPost("AddActor")]
    public async Task<Response<AddMovie>> AddActor(AddMovie movie)
    {
        return await _movieService.AddMovie(movie);
    }
    
     [HttpDelete("Delete")]
    public async Task<Response<string>> Delete(int Id)
    {
        return await _movieService.Delete(Id);
    }

}