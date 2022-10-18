using EntityFrameworkRepository.Core.Entities;
using EntityFrameworkRepository.Shared.DTOs;

namespace EntityFrameworkRepository.Core.Contracts.Repositories;

public interface IAuthorRepository
{
    Task<IEnumerable<AuthorDto>> GetAll();
    Task<AuthorDto?> GetById(Guid id);
    void Add(Author item);
    void Update(Guid id, AuthorAddUpdateInputDto item);
    void Remove(Guid id);
    bool ItemExists(Guid id);
}