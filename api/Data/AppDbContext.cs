using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions options) : base(options) { }

    public DbSet<Quote> Quotes { get; set; }
    public DbSet<Coverage> Coverages { get; set; }




    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Coverage>()
        .Property(c => c.Limit)
        .HasPrecision(18,2);

        modelBuilder.Entity<Quote>()
        .Property(q => q.TotalPremium)
        .HasPrecision(18,2);

        base.OnModelCreating(modelBuilder);
    }



}
