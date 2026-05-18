using Microsoft.EntityFrameworkCore;

namespace MediaCatalog.Data;

// Step 2 & 3: Define DbContext
public class MovieContext : DbContext
{
    public DbSet<Movie> Movies => Set<Movie>();

    public MovieContext(DbContextOptions<MovieContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        // Model configuration goes here if complex relationships exist
    }
}
