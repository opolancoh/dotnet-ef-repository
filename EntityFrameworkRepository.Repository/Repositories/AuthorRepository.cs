using EntityFrameworkRepository.Core.Contracts.Repositories;
using EntityFrameworkRepository.Core.Entities;

namespace EntityFrameworkRepository.Repository.Repositories;

public class AuthorRepository : GenericRepository<Author>, IAuthorRepository
{
    public AuthorRepository(ApplicationDbContext context)
        : base(context)
    {
    }
}