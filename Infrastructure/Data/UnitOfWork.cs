namespace App.Infrastructure;

public class UnitOfWork : IUnitOfWork, IDisposable
{
  public DBFactory DBFactory { get; set; }

  public UnitOfWork(DBFactory DBFactory)
  {
    this.DBFactory = DBFactory;
  }
  public void BeginTransactionAsync()
  {
    this.DBFactory.ApplicationDbContext.Database.BeginTransaction();
  }

  public async Task CommitTransactionAsync()
  {
    await this.DBFactory.ApplicationDbContext.SaveChangesAsync();
  }

  public void Dispose()
  {
    this.DBFactory.ApplicationDbContext.Dispose();
  }
}