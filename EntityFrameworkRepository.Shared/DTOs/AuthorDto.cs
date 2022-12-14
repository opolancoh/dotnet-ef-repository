namespace EntityFrameworkRepository.Shared.DTOs;

public record AuthorDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
}