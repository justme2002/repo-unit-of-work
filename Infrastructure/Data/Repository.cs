using System.Linq.Expressions;
using App.Infrastructure.Interface;
using Microsoft.EntityFrameworkCore;

namespace App.Infrastructure;

public class Repository<T> : IRepository<T> where T : class
{
  private readonly DBFactory dbContext;

  public Repository(DBFactory dBFactory)
  {
    this.dbContext = dBFactory;
  }

  public async Task<bool> Add(T Entity)
  {
    await this.dbContext.ApplicationDbContext.AddAsync(Entity);
    return true;
  }

  public Task<IEnumerable<T>> All()
  {
    throw new NotImplementedException();
  }

  public Task<bool> Delete(Guid Id)
  {
    throw new NotImplementedException();
  }

  public async Task<IEnumerable<T>> Find(Expression<Func<T, bool>> Predicate)
  {
    return await dbContext.ApplicationDbContext.Set<T>().Where(Predicate).ToListAsync();
  }

  public Task<T> GetById(Guid Id)
  {
    throw new NotImplementedException();
  }

  public Task<bool> Update(T entity)
  {
    throw new NotImplementedException();
  }
}
