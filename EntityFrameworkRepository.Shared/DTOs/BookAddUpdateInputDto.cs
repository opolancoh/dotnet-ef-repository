namespace EntityFrameworkRepository.Shared.DTOs;

public record BookAddUpdateInputDto : BookBaseDto
{
    public IEnumerable<Guid> Authors { get; set; }
}