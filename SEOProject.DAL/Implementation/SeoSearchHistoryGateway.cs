using SEOProject.DAL.Entities;
using SEOProject.DAL.Interfaces;
using SEOProject.DAL.SqlServer;

namespace SEOProject.DAL.Implementation;

public class SeoSearchHistoryGateway : ISeoSearchHistoryGateway
{
    private readonly SEOProjectDbContext _dbContext;

    public SeoSearchHistoryGateway(SEOProjectDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public void AddSeoSearchHistory(IEnumerable<SeoSearchHistoryEntity> seoSearchHistoryEntities)
    {
        _dbContext.SearchHistory.AddRange(seoSearchHistoryEntities);
        Save();
    }

    public void AddSeoSearchHistory(SeoSearchHistoryEntity seoSearchHistoryEntity)
    {
        _dbContext.SearchHistory.Add(seoSearchHistoryEntity);
        Save();
    }

    private void Save()
    {
        if (_dbContext.ChangeTracker.HasChanges())
        {
            _dbContext.SaveChanges();
        }
    }
}
