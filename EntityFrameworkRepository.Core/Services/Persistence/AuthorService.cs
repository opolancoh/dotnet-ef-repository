using EntityFrameworkRepository.Core.Contracts.Repositories;
using EntityFrameworkRepository.Core.Contracts.Services;
using EntityFrameworkRepository.Service.Contracts;

namespace EntityFrameworkRepository.Core.Services.Persistence;

internal sealed class AuthorService : IAuthorService
{
    private readonly IRepositoryManager _repository;
    private readonly ILoggerService _logger;

    public AuthorService(IRepositoryManager repository, ILoggerService
        logger)
    {
        _repository = repository;
        _logger = logger;
    }
}