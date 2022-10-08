using EntityFrameworkRepository.Core.Contracts.Repositories;

namespace EntityFrameworkRepository.Repository.Repositories;

public sealed class RepositoryManager : IRepositoryManager
{
    private readonly ApplicationDbContext _ctx;
    private readonly Lazy<IBookRepository> _bookRepository;
    private readonly Lazy<IReviewRepository> _reviewRepository;
    private readonly Lazy<IAuthorRepository> _authorRepository;

    public RepositoryManager(ApplicationDbContext context)
    {
        _ctx = context;
        _bookRepository = new Lazy<IBookRepository>(() => new BookRepository(context));
        _reviewRepository = new Lazy<IReviewRepository>(() => new ReviewRepository(context));
        _authorRepository = new Lazy<IAuthorRepository>(() => new AuthorRepository(context));
    }

    public IBookRepository Book => _bookRepository.Value;
    public IReviewRepository Review => _reviewRepository.Value;
    public IAuthorRepository Author => _authorRepository.Value;
    public void CommitChanges() => _ctx.SaveChanges();
}