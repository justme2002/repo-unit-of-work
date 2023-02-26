using Microsoft.EntityFrameworkCore;
using App.Infrastructure.Data;

namespace App.Infrastructure;

public class DBFactory
{
  public ApplicationDbContext ApplicationDbContext;

  public DBFactory(ApplicationDbContext applicationDbContext)
  {
    this.ApplicationDbContext = applicationDbContext;
  }
}