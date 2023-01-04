namespace Domain.Entities;
public class Cast
{
    public int CastId { get; set; }
    public int ActorId { get; set; }
    public Actor Actors { get; set; }
    public int MovieId { get; set; }
    public Movie Movies { get; set; }
}