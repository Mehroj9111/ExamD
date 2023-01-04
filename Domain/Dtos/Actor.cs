using Domain.Entities;
namespace Domain.Dtos;
public class AddActor
{
    public int ActorId { get; set; }
    public string FullName { get; set; }
    public Gender Gender { get; set; }
    public string BirthYear { get; set; }
    public string DeathYear { get; set; }
}
public class GetActor
{
    public int ActorId { get; set; }
    public string FullName { get; set; }
    public Gender Gender { get; set; }
    public string BirthYear { get; set; }
    public string DeathYear { get; set; }
}