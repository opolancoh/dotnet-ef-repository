using System.Linq.Expressions;

namespace EntityFrameworkRepository.Repository.Contracts;

public interface IRepositoryBase<T>
{
    IQueryable<T> GetAll(bool trackChanges);
    IQueryable<T> GetByCondition(Expression<Func<T, bool>> predicate, bool trackChanges);
    void Add(T entity);
    void Update(T entity);
    void Remove(T entity);
}