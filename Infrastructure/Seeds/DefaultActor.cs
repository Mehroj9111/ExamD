using Domain.Entities;
using Infrastructure.Context;
namespace Infrastructure.Seeds;
public static class DefaultActor
{
    public static async Task SeedAsync(DataContext context)
    {
        var actors = new List<string>()
        {
            "Selena Gomez",
            "Scarlett Johansson",
            "Leonardo DiCaprio",
        };
        foreach(var list in actors)
        {
            var actorExisting = context.Actors.FirstOrDefault(x => x.FullName == list);
            if( actorExisting == null)
            {
                var newActor = new Actor()
                {
                    FullName = list,
                    Gender = Gender.Female,
                    BirthYear = "June 1, 1926",
                    DeathYear = "August 5, 1962",
                };
                context.Actors.Add(newActor);
            }
        }
        await context.SaveChangesAsync();
    }
}