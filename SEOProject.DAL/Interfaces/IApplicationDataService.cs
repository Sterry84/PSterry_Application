namespace SEOProject.DAL.Interfaces;

public interface IApplicationDataService
{
    ISearchEngineGateway SearchEngineGateway { get; }
    ISeoSearchHistoryGateway SeoSearchHistoryGateway { get; }
}
