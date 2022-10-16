namespace EntityFrameworkRepository.Service.Contracts;

public interface IServiceManager
{
    IBookService BookService { get; }
    IReviewService ReviewService { get; }
    IAuthorService AuthorService { get; }
}