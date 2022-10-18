namespace EntityFrameworkRepository.Shared.DTOs;

public record ReviewAddUpdateInputDto
{
    public string Comment { get; set; }
    public int Rating { get; set; }
    public Guid BookId { get; set; }
}