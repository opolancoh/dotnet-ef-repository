using System.Linq.Expressions;

namespace EntityFrameworkRepository.Core.Contracts.Repositories;

public interface IRepositoryBase<T>
{
    IQueryable<T> GetAll(bool trackChanges);
    IQueryable<T> GetByCondition(Expression<Func<T, bool>> predicate, bool trackChanges);
    void AddOne(T entity);
    void UpdateOne(T entity);
    void RemoveOne(T entity);
}