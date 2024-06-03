using SEOProject.DAL.Interfaces;

namespace SEOProject.DAL.Implementation;

public class ApplicationDataService : IApplicationDataService
{
    public ISearchEngineGateway SearchEngineGateway { get; }
    public ISeoSearchHistoryGateway SeoSearchHistoryGateway { get; }

    public ApplicationDataService(ISearchEngineGateway searchEngineGateway, ISeoSearchHistoryGateway seoSearchHistoryGateway)
    {
        SearchEngineGateway = searchEngineGateway;
        SeoSearchHistoryGateway = seoSearchHistoryGateway;
    }
}
