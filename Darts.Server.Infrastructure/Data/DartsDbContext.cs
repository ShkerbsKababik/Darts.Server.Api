using Darts.Server.Domain.Enatities.GameAgregate;
using Darts.Server.Domain.Enatities.UserAgregate;
using Microsoft.EntityFrameworkCore;

namespace Darts.Server.Infrastructure.Data;

public class DartsDbContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Role> Roles { get; set; }

    public DbSet<Game> Games { get; set; }
    public DbSet<Score> Scores { get; set; }

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

        modelBuilder.Entity<Game>()
            .HasOne(g => g.Owner)
            .WithMany();

        modelBuilder.Entity<Game>()
            .HasOne(g => g.CurrentPlayer)
            .WithMany();

        modelBuilder.Entity<Game>()
            .HasMany(g => g.Players)
            .WithMany();

        modelBuilder.Entity<Game>()
            .HasMany(g => g.Scores)
            .WithMany();
    }
}
