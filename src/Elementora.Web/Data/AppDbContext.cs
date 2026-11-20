using Elementora.Web.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Elementora.Web.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {

    }

    public DbSet<Species> Species => Set<Species>();
    public DbSet<Move> Moves => Set<Move>();
    public DbSet<SpeciesMove> SpeciesMoves => Set<SpeciesMove>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Species>(entity =>
        {
            entity.Property(s => s.Name).HasMaxLength(50);
            entity.HasIndex(s => s.Name).IsUnique();
            entity.Property(s => s.Type).HasConversion<string>().HasMaxLength(20);
            entity.Property(s => s.Rarity).HasConversion<string>().HasMaxLength(20);
            entity.Property(s => s.Rarity).HasConversion<string>().HasMaxLength(20);
        });
        modelBuilder.Entity<Move>(entity =>
        {
            entity.Property(m => m.Name).HasMaxLength(50);
            entity.HasIndex(m => m.Name).IsUnique();
            entity.Property(m => m.Type).HasConversion<string>().HasMaxLength(20);
            entity.Property(m => m.Category).HasConversion<string>().HasMaxLength(20);
        });

        modelBuilder.Entity<SpeciesMove>(entity =>
        {
            entity.HasKey(sm => new { sm.SpeciesId, sm.MoveId });

            entity.HasOne(sm => sm.Species).WithMany(s => s.SpeciesMoves).HasForeignKey(sm => sm.SpeciesId);

            entity.HasOne(sm => sm.Move).WithMany(m => m.SpeciesMoves).HasForeignKey(sm => sm.MoveId);
        });
    }
}
