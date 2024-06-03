using AutoMapper;
using SEOProject.API.DTO.Responses;
using SEOProject.BLL.Models;
using SEOProject.BLL.Models.Implementation;
using SEOProject.BLL.Models.Interfaces;
using SEOProject.DAL.Entities;
using Xunit;

namespace SEOProject.API.Testing.Configuration;

public class AutoMapperConfigurationTests
{
    private const string GOOGLE_NAME = "Google";
    private const string BING_NAME = "Bing";

    private readonly Random _random = new Random();
    private readonly IMapper _apiAutoMapper = SEOProject.API.Configuration.AutoMapperConfiguration.Create();

    [Fact]
    public void SearchEngine_To_GoogleSearchEngine_Valid()
    {
        // Arrange
        ISearchEngine source = CreateSearchEngine(GOOGLE_NAME);

        // Act
        GoogleSearchEngine destination = new GoogleSearchEngine();
        destination = _apiAutoMapper.Map<ISearchEngine, GoogleSearchEngine>(source, destination);

        // Assert
        Assert.True(SearchEnginePropertiesMatch(source, destination));
    }

    [Fact]
    public void SearchEngine_To_BingSearchEngine_Valid()
    {
        // Arrange
        ISearchEngine source = CreateSearchEngine(BING_NAME);

        // Act
        BingSearchEngine destination = new BingSearchEngine();
        destination = _apiAutoMapper.Map<ISearchEngine, BingSearchEngine>(source, destination);

        // Assert
        Assert.True(SearchEnginePropertiesMatch(source, destination));
    }

    [Fact]
    public void SearchEngineEntity_To_SearchEngine_Valid()
    {
        // Arrange
        Guid uniqueId = Guid.NewGuid();
        string name = GOOGLE_NAME;
        ISearchEngine searchEngineRef;

        SearchEngineEntity source = new()
        {
            Id = uniqueId,
            ClusteredId = _random.Next(1, 10),
            Name = name,
            BaseUrl = $"{name}{nameof(searchEngineRef.BaseUrl)}",
            SearchQueryStringTemplate = $"{name}{nameof(searchEngineRef.SearchQueryStringTemplate)}",
            ResultUrlExtractionRegEx = $"{name}{nameof(searchEngineRef.ResultUrlExtractionRegEx)}"
        };

        // Act
        SearchEngine destination = _apiAutoMapper.Map<SearchEngine>(source);

        // Assert
        bool isEqual = source.Id != destination.Id
            || source.ClusteredId != destination.ClusteredId
            || source.Name != destination.Name
            || source.BaseUrl != destination.BaseUrl
            || source.SearchQueryStringTemplate != destination.SearchQueryStringTemplate
            || source.ResultUrlExtractionRegEx != destination.ResultUrlExtractionRegEx ? false : true;

        Assert.True(isEqual);
    }

    [Fact]
    public void SEOSearchResult_To_SeoSearchResultDto_Valid()
    {
        // Arrange
        SeoSearchResult source = new()
        {
            SearchEngineName = GOOGLE_NAME,
            Ranks = [ 4, 36, 72]
        };

        // Act
        SeoSearchResultDto destination = _apiAutoMapper.Map<SeoSearchResultDto>(source);

        // Assert
        Assert.Equal(source.SearchEngineName, destination.SearchEngineName);
        Assert.Equal(source.Ranks, destination.Ranks);
    }

    private bool SearchEnginePropertiesMatch(ISearchEngine source, ISearchEngine destination)
    {
        if (source.Id != destination.Id
            || source.ClusteredId != destination.ClusteredId
            || source.Name != destination.Name
            || source.BaseUrl != destination.BaseUrl
            || source.SearchQueryStringTemplate != destination.SearchQueryStringTemplate
            || source.ResultUrlExtractionRegEx != destination.ResultUrlExtractionRegEx)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    private ISearchEngine CreateSearchEngine(string name)
    {
        Guid uniqueId = Guid.NewGuid();
        ISearchEngine searchEngineRef;

        return new SearchEngine()
        {
            Id = uniqueId,
            ClusteredId = _random.Next(1, 10),
            Name = name,
            BaseUrl = $"{name}{nameof(searchEngineRef.BaseUrl)}",
            SearchQueryStringTemplate = $"{name}{nameof(searchEngineRef.SearchQueryStringTemplate)}",
            ResultUrlExtractionRegEx = $"{name}{nameof(searchEngineRef.ResultUrlExtractionRegEx)}"
        };
    }
}
