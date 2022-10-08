using EntityFrameworkRepository.Core.Contracts.Repositories;
using EntityFrameworkRepository.Service.Contracts;

namespace EntityFrameworkRepository.Service.Persistence;

internal sealed class AuthorService : IAuthorService
{
    private readonly IRepositoryManager _repository;
    private readonly ILoggerManager _logger;

    public AuthorService(IRepositoryManager repository, ILoggerManager
        logger)
    {
        _repository = repository;
        _logger = logger;
    }
}