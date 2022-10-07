using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityFrameworkRepository.Core.Entities;

public class BookImage
{
    public string Url { get; set; }
    public string Alt { get; set; }
    
    // One-to-one relationship (Book)
    [Key, ForeignKey("Book")]
    public Guid BookId { get; set; }
    public Book Book { get; set; }
}