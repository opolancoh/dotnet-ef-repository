namespace EntityFrameworkRepository.Core.Contracts.Repositories;

public interface IRepositoryManager
{
    IBookRepository Book { get; }
    IReviewRepository Review { get; }
    IAuthorRepository Author { get; }
    void CommitChanges();
}