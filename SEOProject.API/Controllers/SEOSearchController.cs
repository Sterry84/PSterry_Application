using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SEOProject.API.DTO.Responses;
using SEOProject.BLL.Interfaces;
using SEOProject.BLL.Models;
using SEOProject.BLL.Models.Implementation;
using SEOProject.DAL.Entities;
using SEOProject.DAL.Interfaces;

namespace SEOProject.API.Controllers;

[ApiController]
[Route("[controller]")]
public class SEOSearchController : ControllerBase
{
    private readonly IApplicationDataService _appDataService;
    private readonly IWebSearchService _webSearchService;
    private readonly IMapper _mapper;
    private readonly ISearchEngineFactory _searchEngineFactory;

    public SEOSearchController(
        IApplicationDataService appDataService
        ,IWebSearchService webSearchService
        ,IMapper mapper
        ,ISearchEngineFactory searchEngineFactory)
    {
        _appDataService = appDataService;
        _webSearchService = webSearchService;
        _mapper = mapper;
        _searchEngineFactory = searchEngineFactory;
    }

    [ProducesResponseType(typeof(SeoSearchResponseDto), 200)]
    [HttpGet]
    public async Task<IActionResult> Get([FromQuery] string? searchEngineName, [FromQuery] string searchText, [FromQuery] string targetUrl)
    {
        // Get search engine data from storage and use AutoMapper to populate values into SearchEngine business objects
        IEnumerable<SearchEngineEntity> searchEngineEntities = _appDataService.SearchEngineGateway.GetSearchEngines(searchEngineName);
        IEnumerable<SearchEngine> searchEngines = _mapper.Map<IEnumerable<SearchEngine>>(searchEngineEntities);

        // Use a Factory to create strongly-typed SearchEngine objects and execute the request
        IEnumerable<SeoSearchResult> seoSearchResults = await _webSearchService.FindUrlRanks(_searchEngineFactory.Create(searchEngines), searchText, targetUrl);

        // Create a record of the activity and pass to the DAL for storage
        IEnumerable<SeoSearchHistoryEntity> seoSearchHistoryEntities = seoSearchResults.Select(seoSearchResult =>
        {
            SeoSearchHistoryEntity searchHistoryEntity = new SeoSearchHistoryEntity()
            {
                SeoSearchDate = DateTime.UtcNow,
                SearchEngine = searchEngineEntities.Single(e => e.Name == seoSearchResult.SearchEngineName),
                SeoSearchText = searchText,
                TargetUrl = targetUrl,
                Results = seoSearchResult.Ranks.Select(i => new SeoSearchHistoryResultEntity() { SeoSearchResultRank = i }).ToList()
            };
            searchHistoryEntity.Results.ToList().ForEach(result => result.SeoSearchHistory = searchHistoryEntity);

            return searchHistoryEntity;
        });
        _appDataService.SeoSearchHistoryGateway.AddSeoSearchHistory(seoSearchHistoryEntities);

        // Format result as a DTO and return
        SeoSearchResponseDto seoSearchResponse = new() { SearchResults = _mapper.Map<IEnumerable<SeoSearchResultDto>>(seoSearchResults) };
        return Ok(seoSearchResponse);
    }
}
