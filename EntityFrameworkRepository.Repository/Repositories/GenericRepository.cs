using System.Linq.Expressions;
using EntityFrameworkRepository.Core.Contracts.Repositories;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkRepository.Repository.Repositories;

public abstract class GenericRepository<T> : IGenericRepository<T> where T : class
{
    private readonly ApplicationDbContext _ctx;

    public GenericRepository(ApplicationDbContext context)
    {
        _ctx = context;
    }

    public IQueryable<T> GetAll(bool trackChanges)
    {
        return trackChanges ? _ctx.Set<T>() : _ctx.Set<T>().AsNoTracking();
    }

    public IQueryable<T> GetByCondition(Expression<Func<T, bool>> expression, bool trackChanges)
    {
        if (trackChanges)
            return _ctx.Set<T>()
                .Where(expression);

        return _ctx.Set<T>()
            .Where(expression)
            .AsNoTracking();
    }

    public void Add(T entity)
    {
        _ctx.Set<T>().Add(entity);
    }

    public void Update(T entity)
    {
        _ctx.Set<T>().Update(entity);
    }

    public void Remove(T entity)
    {
        _ctx.Set<T>().Remove(entity);
    }
}