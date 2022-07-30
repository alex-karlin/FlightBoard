using System.Linq.Expressions;

namespace Domain.Abstractions;

public interface IRepository<T>
{
    IQueryable<T> GetAll();
    IQueryable<T> Get(Expression<Func<T, bool>> predicate);
    void Create(T entity);
    void Update(T entity);
    void Delete(T entity);
}