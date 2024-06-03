using SEOProject.BLL.Implementation;
using SEOProject.BLL.Models;
using SEOProject.BLL.Models.Implementation;
using SEOProject.BLL.Models.Interfaces;
using Xunit;

namespace SEOProject.BLL.Testing.Implementation;

public class WebSearchServiceTests
{
    // SUT
    private readonly WebSearchService _sut_WebSearchService = new WebSearchService();

    public WebSearchServiceTests()
    {
        _sut_WebSearchService = new();
    }

    [Fact]
    public async Task WebSearchService_FindUrlRanks_Google_Valid()
    {
        // Arrange
        HttpClient httpClient = Utilities.CreateFakeHttpClient();
        SearchEngineFactory factoryWithAPIAutoMapper = new SearchEngineFactory(SEOProject.API.Configuration.AutoMapperConfiguration.Create(), httpClient);

        ISearchEngine searchEngine = factoryWithAPIAutoMapper.Create(new SearchEngine()
        {
            Name = "Google",
            BaseUrl = "https://www.google.co.uk/",
            SearchQueryStringTemplate = "search?num=[maxresults]&q=[searchtext]",
            ResultUrlExtractionRegEx = "YT\"><a href=\"\\/url\\?q=(.+?)&sa=U"
        });

        // Act
        IEnumerable<SeoSearchResult> seoSearchResults = await _sut_WebSearchService.FindUrlRanks([searchEngine], "land registry search", "https://www.infotrack.co.uk");

        // Assert
        Assert.Single(seoSearchResults);
        Assert.Equal(searchEngine.Name, seoSearchResults.Single().SearchEngineName);
        Assert.Single(seoSearchResults.Single().Ranks);
        Assert.Equal(32, seoSearchResults.Single().Ranks.Single());
        Assert.Collection(seoSearchResults.Single().Ranks,
            r =>
            {
                Assert.Equal(32, r);
            });
    }

    [Fact]
    public async Task WebSearchService_FindUrlRanks_Bing_Valid()
    {
        // Arrange
        HttpClient httpClient = Utilities.CreateFakeHttpClient();
        SearchEngineFactory factoryWithAPIAutoMapper = new SearchEngineFactory(SEOProject.API.Configuration.AutoMapperConfiguration.Create(), httpClient);

        ISearchEngine searchEngine = factoryWithAPIAutoMapper.Create(new SearchEngine()
        {
            Name = "Bing",
            BaseUrl = "https://www.bing.com/",
            SearchQueryStringTemplate = "search?q=[searchtext]",
            ResultUrlExtractionRegEx = "<cite>(.+?)</cite>"
        });

        // Act
        IEnumerable<SeoSearchResult> seoSearchResults = await _sut_WebSearchService.FindUrlRanks([searchEngine], "land registry search", "landregistry.gov.uk");

        // Assert
        Assert.Single(seoSearchResults);
        Assert.Equal(searchEngine.Name, seoSearchResults.Single().SearchEngineName);
        Assert.Collection(seoSearchResults.Single().Ranks,
            r =>
            {
                Assert.Equal(9, r);
            },
            r =>
            {
                Assert.Equal(10, r);
            });
    }
}
