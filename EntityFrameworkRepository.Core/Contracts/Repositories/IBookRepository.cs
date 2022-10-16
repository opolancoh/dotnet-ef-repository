using EntityFrameworkRepository.Core.Entities;
using EntityFrameworkRepository.Shared.DTOs;

namespace EntityFrameworkRepository.Core.Contracts.Repositories;

public interface IBookRepository
{
    Task<IEnumerable<BookDetailDto>> GetAll();
    Task<BookDetailDto?> GetById(Guid id);
    Task Add(Book item);
    Task Update(Guid id, BookAddUpdateInputDto item);
    Task Remove(Guid id);
}