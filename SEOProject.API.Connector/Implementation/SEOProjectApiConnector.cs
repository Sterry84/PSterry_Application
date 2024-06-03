using SEOProject.API.Connector.Interfaces;
using SEOProject.API.DTO.Responses;
using SEOProject.API.DTO.Serialisation;
using System.Text.Encodings.Web;
using System.Text.Json;

namespace SEOProject.API.Connector.Implementation;

public class SEOProjectApiConnector : ISEOProjectApiConnector
{
    private readonly HttpClient _httpClient;
    private readonly string _baseUrl = "https://localhost:44372/";

    public SEOProjectApiConnector(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<SeoSearchResponseDto> SeoSearch(string searchEngineName, string searchText, string targetUrl)
    {
        string queryString = $"seosearch?searchEngineName={UrlEncoder.Default.Encode(searchEngineName)}&searchText={UrlEncoder.Default.Encode(searchText)}&targetUrl={UrlEncoder.Default.Encode(targetUrl)}";
        string url = $"{_baseUrl}{queryString}";

        HttpRequestMessage httpRequest = new HttpRequestMessage(HttpMethod.Get, url);
        HttpResponseMessage httpResponse = await _httpClient.SendAsync(httpRequest);

        return JsonSerializer.Deserialize<SeoSearchResponseDto>(await httpResponse.Content.ReadAsStringAsync(), SeoProjectJsonSerialiserOptions.StandardOptions) ?? new();
    }

    public async Task<SearchEngineNamesResponseDto> GetSearchEngines()
    {
        HttpRequestMessage httpRequest = new HttpRequestMessage(HttpMethod.Get, $"{_baseUrl}searchengine/names");
        HttpResponseMessage httpResponse = await _httpClient.SendAsync(httpRequest);

        return JsonSerializer.Deserialize<SearchEngineNamesResponseDto>(await httpResponse.Content.ReadAsStringAsync(), SeoProjectJsonSerialiserOptions.StandardOptions) ?? new();
    }
}
