namespace EntityFrameworkRepository.Shared.DTOs;

public abstract record BookBaseDto
{
    public string Title { get; set; }
    public DateTime PublishedOn { get; set; }
    public BookImageDto Image { get; set; }
}