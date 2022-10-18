using EntityFrameworkRepository.Core.Entities;
using EntityFrameworkRepository.Shared.DTOs;

namespace EntityFrameworkRepository.Core.Contracts.Repositories;

public interface IBookRepository
{
    Task<IEnumerable<BookDetailDto>> GetAll();
    Task<BookDetailDto?> GetById(Guid id);
    void Add(Book item);
    void Update(Guid id, BookAddUpdateInputDto item);
    void Remove(Guid id);
}