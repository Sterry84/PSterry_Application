using SEOProject.DAL.Entities;
using SEOProject.DAL.Interfaces;
using SEOProject.DAL.SqlServer;

namespace SEOProject.DAL.Implementation;

public class SearchEngineGateway : ISearchEngineGateway
{
    private readonly SEOProjectDbContext _dbContext;

    public SearchEngineGateway(SEOProjectDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public IEnumerable<SearchEngineEntity> GetSearchEngines()
    {
        return _dbContext.SearchEngines.ToList();
    }

    public IEnumerable<SearchEngineEntity> GetSearchEngines(string? searchEngineName)
    {
        if (string.IsNullOrEmpty(searchEngineName))
        {
            return GetSearchEngines();
        }
        else
        {
            return _dbContext.SearchEngines.Where(searchEngine => searchEngine.Name == searchEngineName);
        }
    }
}
