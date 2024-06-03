using SEOProject.BLL.Implementation;
using SEOProject.BLL.Models.Implementation;
using SEOProject.BLL.Models.Interfaces;
using Xunit;

namespace SEOProject.BLL.Testing.Implementation;

public class SearchEngineFactoryTests
{
    private readonly SearchEngineFactory _factoryWithAPIAutoMapper;
    private readonly HttpClient _httpClient;

    public SearchEngineFactoryTests()
    {
        _httpClient = new();
        _factoryWithAPIAutoMapper = new SearchEngineFactory(SEOProject.API.Configuration.AutoMapperConfiguration.Create(), _httpClient);
    }

    [InlineData("Google", nameof(GoogleSearchEngine))]
    [InlineData("google", nameof(GoogleSearchEngine))]
    [InlineData("GOOGLE", nameof(GoogleSearchEngine))]
    [InlineData("GoOgLe", nameof(GoogleSearchEngine))]
    [InlineData("Bing", nameof(BingSearchEngine))]
    [InlineData("bing", nameof(BingSearchEngine))]
    [InlineData("BING", nameof(BingSearchEngine))]
    [InlineData("BiNg", nameof(BingSearchEngine))]
    [InlineData("Lycos", nameof(SearchEngine))]
    [InlineData("", nameof(SearchEngine))]
    [InlineData(" ", nameof(SearchEngine))]
    [InlineData(null, nameof(SearchEngine))]
    [Theory]
    public void Create_WithAPIMapper_Valid(string? name, string expectedType)
    {
        // Arrange
        SearchEngine searchEngine = new(_httpClient)
        {
            Name = name
        };

        // Act
        ISearchEngine typedSearchEngine = _factoryWithAPIAutoMapper.Create(searchEngine);

        // Assert
        Assert.Equal(expectedType, typedSearchEngine.GetType().Name);
    }
}
