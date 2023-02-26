using App.Infrastructure.Interface;

public interface IUnitOfWork
{
  public void BeginTransactionAsync();
  public Task CommitTransactionAsync();
}