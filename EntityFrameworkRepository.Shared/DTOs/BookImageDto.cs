namespace EntityFrameworkRepository.Shared.DTOs;

public record BookImageDto
{
    public string Url { get; set; }
    public string Alt { get; set; }
}