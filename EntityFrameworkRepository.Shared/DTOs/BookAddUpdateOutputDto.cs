namespace EntityFrameworkRepository.Shared.DTOs;

public record BookAddUpdateOutputDto : BookBaseDto
{
    public Guid Id { get; set; }
    public IEnumerable<Guid> Authors { get; set; }
}