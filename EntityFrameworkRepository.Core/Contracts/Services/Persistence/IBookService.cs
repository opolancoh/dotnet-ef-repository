using EntityFrameworkRepository.Shared.DTOs;

namespace EntityFrameworkRepository.Core.Contracts.Services.Persistence;

public interface IBookService
{
    Task<IEnumerable<BookDetailDto>> GetAll();
    Task<BookDetailDto?> GetById(Guid id);
    Task<BookAddUpdateOutputDto> Add(BookAddUpdateInputDto item);
    Task Update(Guid id, BookAddUpdateInputDto item);
    Task Remove(Guid id);
}