using SEOProject.BLL.Models;
using SEOProject.BLL.Models.Interfaces;

namespace SEOProject.BLL.Interfaces;

public interface IWebSearchService
{
    Task<IEnumerable<SeoSearchResult>> FindUrlRanks(IEnumerable<ISearchEngine> searchEngines, string searchText, string targetUrl);
}
