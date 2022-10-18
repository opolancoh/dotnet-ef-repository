using EntityFrameworkRepository.Core.Contracts.Repositories;
using EntityFrameworkRepository.Core.Entities;
using EntityFrameworkRepository.Core.Exceptions;
using EntityFrameworkRepository.Shared.DTOs;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkRepository.Repository.Repositories;

public class ReviewRepository : RepositoryBase<Review>, IReviewRepository
{
    private readonly DbSet<Review> _entityItems;

    public ReviewRepository(ApplicationDbContext context) : base(context)
    {
        _entityItems = context.Reviews;
    }

    public async Task<IEnumerable<ReviewDto>> GetAll()
    {
        var query = GetReviewDtoQuery();

        return await query.ToListAsync();
    }

    public async Task<ReviewDto?> GetById(Guid id)
    {
        var query = GetReviewDtoQuery();

        return await query.SingleOrDefaultAsync(x => x.Id == id);
    }

    public void Add(Review item)
    {
        AddOne(item);
    }

    public void Update(Guid id, ReviewAddUpdateInputDto item)
    {
        var currentItem = _entityItems
            .FirstOrDefault(x => x.Id == id);

        if (currentItem == null)
        {
            throw new EntityNotFoundException(id);
        }

        // Main update
        currentItem.Comment = item.Comment;
        currentItem.Rating = item.Rating;

        UpdateOne(currentItem);
    }

    public void Remove(Guid id)
    {
        var itemExists = ItemExists(id);

        if (!itemExists)
        {
            throw new EntityNotFoundException(id);
        }

        RemoveOne(new Review {Id = id});
    }

    public bool ItemExists(Guid id)
    {
        return _entityItems.Any(e => e.Id == id);
    }

    private IQueryable<ReviewDto> GetReviewDtoQuery()
    {
        return _entityItems
            .AsNoTracking()
            .Select(x => new ReviewDto
            {
                Id = x.Id,
                Comment = x.Comment,
                Rating = x.Rating
            });
    }
}