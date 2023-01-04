namespace Domain.Entities;
public class Actor
{
    public int ActorId { get; set; }
    public string FullName { get; set; }
    public Gender Gender { get; set; }
    public string BirthYear { get; set; }
    public string DeathYear { get; set; }
    public List<Cast> Casts { get; set; }
}
public enum Gender
{
    Male = 1,
    Female 
}