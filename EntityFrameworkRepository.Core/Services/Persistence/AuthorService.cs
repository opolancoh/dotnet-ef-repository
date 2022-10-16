using EntityFrameworkRepository.Core.Contracts.Repositories;
using EntityFrameworkRepository.Core.Contracts.Services;
using EntityFrameworkRepository.Core.Contracts.Services.Persistence;
using EntityFrameworkRepository.Core.Entities;
using EntityFrameworkRepository.Shared.DTOs;

namespace EntityFrameworkRepository.Core.Services.Persistence;

internal sealed class AuthorService : IAuthorService
{
    private readonly IRepositoryManager _repository;
    private readonly ILoggerService _logger;

    public AuthorService(IRepositoryManager repository, ILoggerService
        logger)
    {
        _repository = repository;
        _logger = logger;
    }

    public async Task<IEnumerable<AuthorDto>> GetAll()
    {
        var itemsFromDb = await _repository.Author.GetAll();

        return itemsFromDb.Select(x => new AuthorDto
        {
            Id = x.Id,
            Name = x.Name,
            Email = x.Email
        });
    }

    public async Task<AuthorDto?> GetById(Guid id)
    {
        var item = await _repository.Author.GetById(id);

        if (item != null)
            return new AuthorDto
            {
                Id = item.Id,
                Name = item.Name,
                Email = item.Name
            };

        return null;
    }

    public async Task<AuthorDto> Add(AuthorAddUpdateInputDto item)
    {
        var newItem = new Author()
        {
            Id = new Guid(),
            Name = item.Name,
            Email = item.Email
        };

        _repository.Author.Add(newItem);
        await _repository.CommitChanges();

        var dto = new AuthorDto
        {
            Id = newItem.Id,
            Name = newItem.Name,
            Email = newItem.Email
        };

        return dto;
    }

    public async Task Update(Guid id, AuthorAddUpdateInputDto item)
    {
        var itemToUpdate = new Author()
        {
            Id = id,
            Name = item.Name,
            Email = item.Email
        };

        _repository.Author.Update(itemToUpdate);
        await _repository.CommitChanges();
    }

    public async Task Remove(Guid id)
    {
        var itemToRemove = new Author {Id = id};

        _repository.Author.Remove(itemToRemove);
        await _repository.CommitChanges();
    }
}