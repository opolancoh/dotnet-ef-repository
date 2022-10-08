using System.Linq.Expressions;

namespace EntityFrameworkRepository.Core.Contracts.Repositories;

public interface IGenericRepository<T>
{
    IQueryable<T> GetAll(bool trackChanges);
    IQueryable<T> GetByCondition(Expression<Func<T, bool>> expression, bool trackChanges);
    void Add(T entity);
    void Update(T entity);
    void Remove(T entity);
}