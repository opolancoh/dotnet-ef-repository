using EntityFrameworkRepository.Core.Contracts.Repositories;
using EntityFrameworkRepository.Core.Contracts.Services;
using EntityFrameworkRepository.Service.Contracts;

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
}