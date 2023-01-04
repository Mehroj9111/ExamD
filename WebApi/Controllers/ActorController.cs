using Microsoft.AspNetCore.Mvc;
using Domain.Entities;
using Infrastructure.Services;
using Domain.PaginationFilter;
using Domain.Wrapper;
using Domain.Dtos;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]

public class ActorController
{
    public readonly ActorService _actorService;
    public ActorController(ActorService actorService)
    {
        _actorService = actorService;
    }
    [HttpGet("Get")]
    public async Task<Response<List<GetActor>>> GetActors()
    {
        return await _actorService.GetActors();
    }
    [HttpPost("AddActor")]
    public async Task<Response<AddActor>> AddActor(AddActor actor)
    {
        return await _actorService.AddActor(actor);
    }
    [HttpDelete("Delete")]
    public async Task<Response<string>> Delete(int Id)
    {
        return await _actorService.Delete(Id);
    }
}
