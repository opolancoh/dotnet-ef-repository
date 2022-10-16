using System.Linq.Expressions;

namespace EntityFrameworkRepository.Repository.Contracts;

public interface IRepositoryBase<T>
{
    IQueryable<T> GetMany(bool trackChanges);
    IQueryable<T> GetByCondition(Expression<Func<T, bool>> predicate, bool trackChanges);
    void AddOne(T entity);
    void UpdateOne(T entity);
    void RemoveOne(T entity);
}