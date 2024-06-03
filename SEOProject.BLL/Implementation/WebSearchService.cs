using SEOProject.BLL.Interfaces;
using SEOProject.BLL.Models;
using SEOProject.BLL.Models.Interfaces;

namespace SEOProject.BLL.Implementation;

public class WebSearchService : IWebSearchService
{   
    public async Task<IEnumerable<SeoSearchResult>> FindUrlRanks(IEnumerable<ISearchEngine> searchEngines, string searchText, string targetUrl)
    {
        List<SeoSearchResult> seoSearchResults = new List<SeoSearchResult>();

        List<int> ranks = new();
        string searchResultText = string.Empty;

        foreach (ISearchEngine searchEngine in searchEngines)
        {
            searchResultText = await searchEngine.Search(searchText);
            IList<string> urls = searchEngine.ExtractUrls(searchResultText);

            ranks = new List<int>();
            int rank = 1;
            foreach (string url in urls)
            {
                if (url.Contains(targetUrl))
                {
                    ranks.Add(rank);
                }
                rank++;
            }

            if (ranks.Count == 0)
            {
                // Google's "cookie acceptance" screen was scraped - A rank of -1 makes this explicit
                if (searchResultText.Contains("Before you continue to Google", StringComparison.OrdinalIgnoreCase))
                {
                    ranks.Add(-1);
                }
                else // No matches were found - A rank of 0 makes this explicit
                {
                    ranks.Add(0);
                }
            }

            seoSearchResults.Add(new() { SearchEngineName = searchEngine.Name, Ranks = ranks });
        }

        return seoSearchResults;
    }
}
