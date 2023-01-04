using AutoMapper;
using Domain.Dtos;
using Domain.Entities;

namespace Infrastructure.Mapper;

public class ServiceProfile:Profile
{
     public ServiceProfile()
     {
         CreateMap<Actor, AddActor>().ReverseMap();
         CreateMap<Actor, GetActor>().ReverseMap();
         CreateMap<GetActor, AddActor>().ReverseMap();

         CreateMap<Cast, AddCast>().ReverseMap();
         CreateMap<Cast, GetCast>().ReverseMap();
         CreateMap<GetCast, AddCast>().ReverseMap();

         CreateMap<Category, AddCategory>().ReverseMap();
         CreateMap<Category, GetCategory>().ReverseMap();
         CreateMap<GetCategory, AddCategory>().ReverseMap();

         CreateMap<Movie, AddMovie>().ReverseMap();
         CreateMap<Movie, GetMovie>().ReverseMap();
         CreateMap<GetMovie, AddMovie>().ReverseMap();
     }
}
