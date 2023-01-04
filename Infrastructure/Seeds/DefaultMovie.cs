using Domain.Entities;
using Infrastructure.Context;
namespace Infrastructure.Seeds;
public static class DefaultMovie
{
    public static async Task SeedAsync(DataContext context)
    {
        var movies = new List<string>()
        {
            "Wednesday",
            "I go looking",
            "The Silence",
        };
        foreach(var list in movies)
        {
            var actorExisting = context.Movies.FirstOrDefault(x => x.Title == list);
            if( actorExisting == null)
            {
                var newActor = new Movie()
                {
                   Title = list,
                   MovieYear = "1960"
                };
                context.Movies.Add(newActor);
            }
        }
        await context.SaveChangesAsync();
    }
}                                                                                                                                                                                                                                                                                                                                                                                                                                   




