using App.Infrastructure.Entity;
using App.Infrastructure.Interface;

namespace App.Infrastructure.Repositories;

public class UserRepository : Repository<User>, IUserRepository
{
  public UserRepository(DBFactory dBFactory) : base(dBFactory)
  {

  }
}