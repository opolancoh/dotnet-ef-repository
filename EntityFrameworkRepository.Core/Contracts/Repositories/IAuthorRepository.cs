using EntityFrameworkRepository.Core.Entities;

namespace EntityFrameworkRepository.Core.Contracts.Repositories;

public interface IAuthorRepository
{
    Task<IEnumerable<Author>> GetAll();
    Task<Author?> GetById(Guid id);
    void Add(Author item);
    void Update(Author item);
    void Remove(Author item);
}