using EntityFrameworkRepository.Core.Contracts.Repositories;
using EntityFrameworkRepository.Service.Contracts;
using EntityFrameworkRepository.Service.Persistence;

namespace EntityFrameworkRepository.Service;

public sealed class ServiceManager : IServiceManager
{
    private readonly Lazy<IBookService> _bookService;
    private readonly Lazy<IReviewService> _reviewService;
    private readonly Lazy<IAuthorService> _authorService;

    public ServiceManager(IRepositoryManager repositoryManager, ILoggerManager
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