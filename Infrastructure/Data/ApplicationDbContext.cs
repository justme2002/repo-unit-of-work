using Microsoft.EntityFrameworkCore;
using App.Infrastructure.Entity;

namespace App.Infrastructure.Data;

public class ApplicationDbContext : DbContext
{
  public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
  {

  }

  public DbSet<User> Users { get; set; }
}