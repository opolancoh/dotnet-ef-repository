using EntityFrameworkRepository.Shared.DTOs;

namespace EntityFrameworkRepository.Core.Contracts.Services.Persistence;

public interface IReviewService
{
    Task<IEnumerable<ReviewDto>> GetAll();
    Task<ReviewDto?> GetById(Guid id);
    Task<ReviewDto> Add(ReviewAddUpdateInputDto item);
    Task Update(Guid id, ReviewAddUpdateInputDto item);
    Task Remove(Guid id);
}