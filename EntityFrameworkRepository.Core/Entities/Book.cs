namespace EntityFrameworkRepository.Core.Entities;

public class Book
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public DateTime PublishedOn { get; set; }

    // One-to-one relationship (BookImage)
    public BookImage Image { get; set; }
    
    // One-to-many relationship (Review)
    public ICollection<Review> Reviews { get; set; }
    
    // Many-to-many link relationship (Author)
    public ICollection<BookAuthor> AuthorsLink { get; } = new List<BookAuthor>();
}