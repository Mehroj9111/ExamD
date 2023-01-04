using Domain.Entities;
using Infrastructure.Context;
namespace Infrastructure.Seeds;
public static class DefaultCategory
{
    public static async Task SeedAsync(DataContext context)
    {
        var categorys = new List<string>()
        {
            "Action",
            "Comedy",
            "Fantasy"
        };
        foreach(var list in categorys)
        {
            var categoryExisting = context.Categories.FirstOrDefault(x => x.Title == list);
            if( categoryExisting == null)
            {
                var newTitle = new Category()
                {
                  Title = list
                };
                context.Categories.Add(newTitle);
            }
        }
        await context.SaveChangesAsync();
    }
}