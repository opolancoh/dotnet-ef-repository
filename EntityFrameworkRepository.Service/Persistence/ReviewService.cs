using EntityFrameworkRepository.Core.Contracts.Repositories;
using EntityFrameworkRepository.Service.Contracts;

namespace EntityFrameworkRepository.Service.Persistence;

internal sealed class ReviewService : IReviewService
{
    private readonly IRepositoryManager _repository;
    private readonly ILoggerManager _logger;

    public ReviewService(IRepositoryManager repository, ILoggerManager
        logger)
    {
        _repository = repository;
        _logger = logger;
    }
}