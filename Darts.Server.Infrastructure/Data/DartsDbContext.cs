using Darts.Server.Domain.Enatities;
using Microsoft.EntityFrameworkCore;

namespace Darts.Server.Infrastructure.Data;

public class DartsDbContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Role> Roles { get; set; }

    public DartsDbContext(DbContextOptions<DartsDbContext> options) 
        : base(options)
    {
        Database.EnsureCreated();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>()
            .HasMany(u => u.Roles)
            .WithMany();
    }
}
