using Microsoft.EntityFrameworkCore;
using OfficeFlow.Data;
using OfficeFlow.Models;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options) { }

    public DbSet<Amenity> Amenities { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Office> Offices { get; set; }
    public DbSet<OfficeAddress> OfficeAddresses { get; set; }
    public DbSet<Desk> Desks { get; set; }
    public DbSet<Reservation> Reservations { get; set; }
    public DbSet<ReservationArchive> ReservationArchives { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        modelBuilder.Seed();
    }
}
