namespace EntityFrameworkRepository.Shared.DTOs;

public record BookDetailDto : BookBaseDto
{
    public Guid Id { get; set; }
    public IEnumerable<AuthorListDto> Authors { get; set; }
}