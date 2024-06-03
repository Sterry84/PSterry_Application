using Microsoft.EntityFrameworkCore;
using SEOProject.DAL.Entities;

namespace SEOProject.DAL.SqlServer;

public class SEOProjectDbContext : DbContext
{
    public SEOProjectDbContext(DbContextOptions<SEOProjectDbContext> options)
            : base(options)
    {
        /* no op */
    }

    public DbSet<SearchEngineEntity> SearchEngines { get; set; }
    public DbSet<SeoSearchHistoryEntity> SearchHistory { get; set; }
    public DbSet<SeoSearchHistoryResultEntity> SearchHistoryResults { get; set; }
}
