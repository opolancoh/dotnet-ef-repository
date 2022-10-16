using EntityFrameworkRepository.Core.Contracts.Repositories;
using EntityFrameworkRepository.Core.Entities;
using EntityFrameworkRepository.Core.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkRepository.Repository.Repositories;

public class AuthorRepository : RepositoryBase<Author>, IAuthorRepository
{
    public AuthorRepository(ApplicationDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Author>> GetAll()
    {
        return await GetMany(trackChanges: false).ToListAsync();
    }

    public async Task<Author?> GetById(Guid id)
    {
        return await GetByCondition(x => x.Id == id, false)
            .SingleOrDefaultAsync();
    }

    public void Add(Author item)
    {
        AddOne(item);
    }

    public void Update(Author item)
    {
        UpdateOne(item);
    }

    public void Remove(Author item)
    {
        RemoveOne(item);
    }
}