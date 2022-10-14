using EntityFrameworkRepository.Core.Contracts.Repositories;
using EntityFrameworkRepository.Core.Entities;

namespace EntityFrameworkRepository.Repository.Repositories;

// public class ReviewRepository : GenericRepository<Review>, IReviewRepository
public class ReviewRepository : IReviewRepository
{
    /* public ReviewRepository(ApplicationDbContext context)
        : base(context)
    {
    } */
    public ReviewRepository(ApplicationDbContext context)
    {
    }
}