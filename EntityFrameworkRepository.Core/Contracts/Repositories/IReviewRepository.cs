using EntityFrameworkRepository.Core.Entities;
using EntityFrameworkRepository.Shared.DTOs;

namespace EntityFrameworkRepository.Core.Contracts.Repositories;

public interface IReviewRepository
{
    Task<IEnumerable<ReviewDto>> GetAll();
    Task<ReviewDto?> GetById(Guid id);
    void Add(Review item);
    void Update(Guid id, ReviewAddUpdateInputDto item);
    void Remove(Guid id);
    bool ItemExists(Guid id);
}