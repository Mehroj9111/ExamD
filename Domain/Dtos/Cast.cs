using Domain.Entities;
namespace Domain.Dtos;
public class AddCast
{
    public int CastId { get; set; }
    public int ActorId { get; set; }
    public int MovieId { get; set; }
}
public class GetCast
{
    public int CastId { get; set; }
    public int ActorId { get; set; }
    public int MovieId { get; set; }
}