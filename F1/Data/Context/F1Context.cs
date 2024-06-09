using Microsoft.EntityFrameworkCore;
using F1.Constants;

public partial class F1Context : DbContext
{
    public DbSet<Pilots> Pilots { get; set; }
    public DbSet<Countries> Countries { get; set; }
    public DbSet<Seasons> Seasons { get; set; }
    public DbSet<PilotsSeasons> PilotsSeasons { get; set; }

    public F1Context()
    {
    }

    public F1Context(DbContextOptions<F1Context> options)
        : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer(Private.SQL_CONNECTION);
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}