using SEOProject.API.DTO.Responses;

namespace SEOProject.API.Connector.Interfaces;

public interface ISEOProjectApiConnector
{
    Task<SeoSearchResponseDto> SeoSearch(string searchEngineName, string searchText, string targetUrl);

    Task<SearchEngineNamesResponseDto> GetSearchEngines();
}
