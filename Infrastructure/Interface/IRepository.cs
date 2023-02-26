using System.Linq.Expressions;

namespace App.Infrastructure.Interface;

public interface IRepository<T>
{
  public Task<IEnumerable<T>> All();
  public Task<T> GetById(Guid Id);
  public Task<bool> Add(T Entity);
  public Task<bool> Delete(Guid Id);
  public Task<bool> Update(T entity);
  public Task<IEnumerable<T>> Find(Expression<Func<T, bool>> Predicate);
}