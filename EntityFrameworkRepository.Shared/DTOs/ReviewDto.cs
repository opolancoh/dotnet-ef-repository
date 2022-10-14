namespace EntityFrameworkRepository.Shared.DTOs;

public class ReviewDto
{
    public Guid Id { get; set; }
    public string Comment { get; set; }
    public int Rating { get; set; }
}