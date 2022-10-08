using EntityFrameworkRepository.Core.Contracts.Repositories;
using EntityFrameworkRepository.Core.Entities;

namespace EntityFrameworkRepository.Repository.Repositories;

public class BookRepository : GenericRepository<Book>, IBookRepository
{
    public BookRepository(ApplicationDbContext context)
        : base(context)
    {
    }
}