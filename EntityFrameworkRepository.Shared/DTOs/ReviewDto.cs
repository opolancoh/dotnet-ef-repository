namespace EntityFrameworkRepository.Shared.DTOs;

public record ReviewDto
{
    public Guid Id { get; set; }
    public string Comment { get; set; }
    public int Rating { get; set; }
}