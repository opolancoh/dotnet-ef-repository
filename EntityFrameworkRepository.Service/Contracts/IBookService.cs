using EntityFrameworkRepository.Core.Entities;
using EntityFrameworkRepository.Shared.DTOs;

namespace EntityFrameworkRepository.Service.Contracts;

public interface IBookService
{
    Task<IEnumerable<BookDetailDto>> GetAll();
    Task<BookDetailDto> GetById(Guid id, bool trackChanges);
    Task<BookAddUpdateOutputDto> Add(BookAddUpdateInputDto item);
    Task Update(Guid id, BookAddUpdateInputDto item);
    Task Remove(Guid id);
}