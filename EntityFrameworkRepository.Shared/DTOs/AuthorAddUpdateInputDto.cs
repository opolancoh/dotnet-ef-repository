namespace EntityFrameworkRepository.Shared.DTOs;

public record AuthorAddUpdateInputDto
{
    public string Name { get; set; }
    public string Email { get; set; }
}