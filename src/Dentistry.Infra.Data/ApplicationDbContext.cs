namespace Dentistry.Infra.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
        
    }

    #region Tables

    

    #endregion

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.HasDefaultSchema("ray");

        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}