using Domain.Enums;

namespace Domain.Entities;

public class Book
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string ISBN { get; set; }
    public string? Description { get; set; }   
    public DateOnly PublishDate { get; set; }
    public ICollection<Author> Authors { get; set; }
    public BookCategory Category { get; set; }

}
