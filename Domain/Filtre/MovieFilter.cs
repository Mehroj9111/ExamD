namespace Domain.PaginationFilter;

public class MovieFilter: PaginationFilter
{

    public string? Name { get; set; }
    public int CategoryId { get; set; }

    public MovieFilter():base()
    {
        
    }
    public MovieFilter( string name, int pageNumber, int pageSize) :base(pageNumber,pageSize)
    {
        Name = name;
    }
}