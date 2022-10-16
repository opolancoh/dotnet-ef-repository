using EntityFrameworkRepository.Shared.DTOs;

namespace EntityFrameworkRepository.Core.Contracts.Services.Persistence;

public interface IAuthorService
{
    Task<IEnumerable<AuthorDto>> GetAll();
    Task<AuthorDto?> GetById(Guid id);
    Task<AuthorDto> Add(AuthorAddUpdateInputDto item);
    Task Update(Guid id, AuthorAddUpdateInputDto item);
    Task Remove(Guid id);
}