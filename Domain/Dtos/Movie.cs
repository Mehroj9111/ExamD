using Domain.Entities;
namespace Domain.Dtos;
public class AddMovie
{
    public int MovieId { get; set; }
    public string Title { get; set; }
    public string MovieYear { get; set; }
    public int CategoriyId { get; set; }
}
public class GetMovie
{
    public int MovieId { get; set; }
    public string Title { get; set; }
    public int MovieYear { get; set; }
    public int CategoriyId { get; set; }
}