using EntityFrameworkRepository.Core.Contracts.Repositories;
using EntityFrameworkRepository.Core.Entities;
using EntityFrameworkRepository.Core.Exceptions;
using EntityFrameworkRepository.Shared.DTOs;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkRepository.Repository.Repositories;

public class AuthorRepository : RepositoryBase<Author>, IAuthorRepository
{
    private readonly DbSet<Author> _entityItems;

    public AuthorRepository(ApplicationDbContext context) : base(context)
    {
        _entityItems = context.Authors;
    }

    public async Task<IEnumerable<AuthorDto>> GetAll()
    {
        var query = GetAuthorDtoQuery();

        return await query.ToListAsync();
    }

    public async Task<AuthorDto?> GetById(Guid id)
    {
        var query = GetAuthorDtoQuery();

        return await query.SingleOrDefaultAsync(x => x.Id == id);
    }

    public void Add(Author item)
    {
        AddOne(item);
    }

    public void Update(AuthorAddUpdateInputDto item)
    {
        throw new NotImplementedException();
    }

    public void Update(Guid id, AuthorAddUpdateInputDto item)
    {
        var currentItem = _entityItems
            .FirstOrDefault(x => x.Id == id);

        if (currentItem == null)
        {
            throw new EntityNotFoundException(id);
        }

        // Main update
        currentItem.Name = item.Name;
        currentItem.Email = item.Email;

        UpdateOne(currentItem);
    }

    public void Remove(Guid id)
    {
        var itemExists = ItemExists(id);

        if (!itemExists)
        {
            throw new EntityNotFoundException(id);
        }

        RemoveOne(new Author {Id = id});
    }

    public bool ItemExists(Guid id)
    {
        return _entityItems.Any(e => e.Id == id);
    }

    private IQueryable<AuthorDto> GetAuthorDtoQuery()
    {
        return _entityItems
            .AsNoTracking()
            .Select(x => new AuthorDto
            {
                Id = x.Id,
                Name = x.Name,
                Email = x.Email
            });
    }
}