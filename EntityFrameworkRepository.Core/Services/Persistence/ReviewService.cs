using EntityFrameworkRepository.Core.Contracts.Repositories;
using EntityFrameworkRepository.Core.Contracts.Services;
using EntityFrameworkRepository.Core.Contracts.Services.Persistence;
using EntityFrameworkRepository.Core.Entities;
using EntityFrameworkRepository.Shared.DTOs;

namespace EntityFrameworkRepository.Core.Services.Persistence;

internal sealed class ReviewService : IReviewService
{
    private readonly IRepositoryManager _repository;
    private readonly ILoggerService _logger;

    public ReviewService(IRepositoryManager repository, ILoggerService
        logger)
    {
        _repository = repository;
        _logger = logger;
    }

    public async Task<IEnumerable<ReviewDto>> GetAll()
    {
        return await _repository.Review.GetAll();
    }

    public async Task<ReviewDto?> GetById(Guid id)
    {
        return await _repository.Review.GetById(id);
    }

    public async Task<ReviewDto> Add(ReviewAddUpdateInputDto item)
    {
        var newItem = new Review()
        {
            Id = new Guid(),
            Comment = item.Comment,
            Rating = item.Rating,
            BookId = item.BookId
        };

        _repository.Review.Add(newItem);
        await _repository.CommitChanges();

        var dto = new ReviewDto
        {
            Id = newItem.Id,
            Comment = newItem.Comment,
            Rating = newItem.Rating
        };

        return dto;
    }

    public async Task Update(Guid id, ReviewAddUpdateInputDto item)
    {
        _repository.Review.Update(id, item);
        await _repository.CommitChanges();
    }

    public async Task Remove(Guid id)
    {
        _repository.Review.Remove(id);
        await _repository.CommitChanges();
    }
}