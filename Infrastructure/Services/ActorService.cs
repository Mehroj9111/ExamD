namespace Infrastructure.Services;
using Domain.Entities;
using Domain.Dtos;
using AutoMapper;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Domain.PaginationFilter;
using System.Net;
using Domain.Wrapper;
public class ActorService
{
    private readonly DataContext _context;
    private readonly IMapper _mapper;

    public ActorService(DataContext context , IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    // _ _ _ _ _ _ _ _ _ _ _GetActor_ _ _ _ _ _ _ _ _ _ _ _ _ _
    public async Task<Response<List<GetActor>>> GetActors()
    {
    try
    {
        var list = _mapper.Map<List<GetActor>>(await _context.Actors.ToListAsync());
        return new Response<List<GetActor>>(list);
    }
    catch
    {
         return new Response<List<GetActor>>(System.Net.HttpStatusCode.InternalServerError, "YOU WERE WRONG");
    }
    }
    // _ _ _ _ _ _ _ _ _ _ _AddActor_ _ _ _ _ _ _ _ _ _ _ _ _ _
    public async Task<Response<AddActor>> AddActor(AddActor actor)
    {
    try
    { 
        var newActor = new Actor()
        {
            FullName = actor.FullName,
            Gender = actor.Gender,
            BirthYear = actor.BirthYear,
            DeathYear = actor.DeathYear
        };
        _context.Actors.Add(newActor);
        await _context.SaveChangesAsync();
        return new Response<AddActor>(_mapper.Map<AddActor>(newActor));
    }
     catch
    {
         return new Response<AddActor>(System.Net.HttpStatusCode.InternalServerError, "YOU WERE WRONG");
    }
    }

    // _ _ _ _ _ _ _ _ _ _ _DeletedActor_ _ _ _ _ _ _ _ _ _ _ _ _ _
    public async Task<Response<string>> Delete(int Id)
    {
    try
    {
        var actor = await _context.Actors.FindAsync(Id);
        _context.Actors.Remove(actor);
        var result = await _context.SaveChangesAsync();
         if (result > 0) {
            return new Response<string>("ACTOR SUCCESSFULLY DELETED");
        }
        else{
            return new Response<string>(HttpStatusCode.BadRequest,"ACTOR NOT FOUND");
        }
    }
     catch
    {
         return new Response<string>(System.Net.HttpStatusCode.InternalServerError, "YOU WERE WRONG");
    }
    }
}