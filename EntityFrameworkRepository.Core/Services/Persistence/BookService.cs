using EntityFrameworkRepository.Core.Contracts.Repositories;
using EntityFrameworkRepository.Core.Contracts.Services;
using EntityFrameworkRepository.Core.Entities;
using EntityFrameworkRepository.Service.Contracts;
using EntityFrameworkRepository.Shared.DTOs;

namespace EntityFrameworkRepository.Core.Services.Persistence;

internal sealed class BookService : IBookService
{
    private readonly IRepositoryManager _repository;
    private readonly ILoggerService _logger;

    public BookService(IRepositoryManager repository, ILoggerService
        logger)
    {
        _repository = repository;
        _logger = logger;
    }

    public async Task<IEnumerable<BookDetailDto>> GetAll()
    {
        return await _repository.Book.GetAll();
    }

    public async Task<BookDetailDto> GetById(Guid id, bool trackChanges)
    {
        return await _repository.Book.GetById(id, trackChanges);
    }

    public async Task<BookAddUpdateOutputDto> Add(BookAddUpdateInputDto item)
    {
        var newItem = new Book()
        {
            Id = new Guid(),
            Title = item.Title,
            PublishedOn = item.PublishedOn,
            Image = new BookImage
            {
                Url = item.Image.Url,
                Alt = item.Image.Alt
            }
        };

        foreach (var authorId in item.Authors)
        {
            newItem.AuthorsLink.Add(new BookAuthor {BookId = newItem.Id, AuthorId = authorId});
        }

        await _repository.Book.Add(newItem);
        
        var dto = new BookAddUpdateOutputDto
        {
            Id = newItem.Id,
            Title = newItem.Title,
            PublishedOn = newItem.PublishedOn,
            Image = new BookImageDto
            {
                Url = newItem.Image.Url,
                Alt = newItem.Image.Alt
            },
            Authors = newItem.AuthorsLink.Select(x => x.AuthorId)
        };

        return dto;
    }

    public async Task Update(Guid id, BookAddUpdateInputDto item)
    {
        await _repository.Book.Update(id, item);
    }
    
    public async Task Remove(Guid id)
    {
        await _repository.Book.Remove(id);
    }
}