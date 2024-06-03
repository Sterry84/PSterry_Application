using SEOProject.BLL.Models.Interfaces;
using System.Text.RegularExpressions;
using System.Web;

namespace SEOProject.BLL.Models.Implementation;

public class SearchEngine : ISearchEngine, IDisposable
{
    public Guid Id { get; set; }

    public int ClusteredId { get; set; }

    public string Name { get; set; } = string.Empty;

    public string BaseUrl { get; set; } = string.Empty;

    public string SearchQueryStringTemplate { get; set; } = string.Empty;

    public string ResultUrlExtractionRegEx { get; set; } = string.Empty;

    private HttpClient? _httpClient;

    public SearchEngine()
    {
        // Default constructor to support AutoMapper
    }

    public SearchEngine(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public virtual async Task<string> Search(string searchText)
    {
        if (_httpClient != null)
        {
            SearchEngineRequest searchEngineRequest = new SearchEngineRequest() { SearchText = searchText, MaxResults = 100 };
            string searchUrl = $"{BaseUrl}{GetQueryString(searchEngineRequest)}";

            HttpRequestMessage httpRequest = new(HttpMethod.Get, searchUrl);
            HttpResponseMessage httpResponse = await _httpClient.SendAsync(httpRequest);
            
            return HttpUtility.HtmlDecode(await httpResponse.Content.ReadAsStringAsync());
        }
        else
        {
            throw new Exception($"Member {nameof(_httpClient)} must not be NULL when calling {GetType().Name}.{nameof(Search)}");
        }
    }

    public virtual IList<string> ExtractUrls(string searchResultText)
    {
        MatchCollection matches = Regex.Matches(searchResultText, ResultUrlExtractionRegEx, RegexOptions.None, TimeSpan.FromSeconds(10));
        return ProcessUrls(matches.Select(m => m.Groups[1].Value).ToList());
    }

    protected virtual string GetQueryString(SearchEngineRequest searchEngineRequest)
    {
        return SearchQueryStringTemplate
            .Replace("[searchtext]", searchEngineRequest.SearchText);
    }

    protected virtual IList<string> ProcessUrls(IList<string> urls)
    {
        return urls;
    }

    public void Dispose() => _httpClient?.Dispose();
}