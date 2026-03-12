using Microsoft.EntityFrameworkCore;
using System.Net;

namespace EnumsIssues.Entities
{
  public partial class UnumsContext : DbContext
  {
    public virtual DbSet<User> User { get; set; }

    public  UnumsContext(DbContextOptions<UnumContext> options)
        : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      if (!optionsBuilder.IsConfigured)
      {
        throw new InvalidOperationException("Should not be using this configuration ever.");
      }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder
         .HasPostgresEnum("public", "status_enum", new[] { "none", "active", "inactive", "deleted", "pending_of_approval" });

      modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
    }
  }
    
}
