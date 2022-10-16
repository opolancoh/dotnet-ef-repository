using EntityFrameworkRepository.Core.Contracts.Repositories;
using EntityFrameworkRepository.Core.Contracts.Services;
using EntityFrameworkRepository.Core.Contracts.Services.Persistence;
using EntityFrameworkRepository.Service.Contracts;

namespace EntityFrameworkRepository.Core.Services.Persistence;

public sealed class ServiceManager : IServiceManager
{
    private readonly Lazy<IBookService> _bookService;
    private readonly Lazy<IReviewService> _reviewService;
    private readonly Lazy<IAuthorService> _authorService;

    public ServiceManager(IRepositoryManager repositoryManager, ILoggerService
        logger)
    {
        _bookService = new Lazy<IBookService>(() => new BookService(repositoryManager, logger));
        _reviewService = new Lazy<IReviewService>(() => new ReviewService(repositoryManager, logger));
        _authorService = new Lazy<IAuthorService>(() => new AuthorService(repositoryManager, logger));
    }

    public IBookService BookService => _bookService.Value;
    public IReviewService ReviewService => _reviewService.Value;
    public IAuthorService AuthorService => _authorService.Value;
}