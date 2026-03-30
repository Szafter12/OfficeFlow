public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // AUTOMATYKA: Ładuje wszystkie klasy z folderu Configurations/
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(HRDbContext).Assembly);

        // SEED: Dodaje dane testowe
        modelBuilder.Seed();
    }
}
