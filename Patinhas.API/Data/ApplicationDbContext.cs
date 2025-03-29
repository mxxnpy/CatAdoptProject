using Microsoft.EntityFrameworkCore;
using Patinhas.Common.Models;

namespace Patinhas.API.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options) { }

    public DbSet<Cat> Cats { get; set; } = null!;
    public DbSet<AdoptionRecord> AdoptionRecords { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cat>()
            .HasMany(c => c.AdoptionRecords)
            .WithOne(r => r.Cat)
            .HasForeignKey(r => r.CatId);
    }
}