using Domain.Entities;
using Microsoft.EntityFrameworkCore;
namespace Infrastructure.Context;



public class DataContext:DbContext
{
    public DataContext(DbContextOptions<DataContext> options):base(options)
    {

    }
protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
         modelBuilder.Entity<Cast>()
             .HasOne<Actor>(s => s.Actors)
            .WithMany(g => g.Casts)
            .HasForeignKey(s => s.ActorId);

        modelBuilder.Entity<Cast>()
            .HasOne<Movie>(s => s.Movies)
            .WithMany(g => g.Casts)
            .HasForeignKey(s => s.MovieId); 
    }
    public DbSet<Actor> Actors { get; set; }
    public DbSet<Cast> Casts { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Movie> Movies { get; set; }
}