using AutoMapper;
using SEOProject.BLL.Interfaces;
using SEOProject.BLL.Models.Implementation;
using SEOProject.BLL.Models.Interfaces;

namespace SEOProject.BLL.Implementation;

public class SearchEngineFactory : ISearchEngineFactory
{
    private const string GOOGLE_NAME = "google";
    private const string BING_NAME = "bing";

    private readonly IMapper _mapper;
    private readonly HttpClient _httpClient = new();

    public SearchEngineFactory(IMapper mapper, HttpClient httpClient)
    {
        _mapper = mapper;
        _httpClient = httpClient;
    }

    public IEnumerable<ISearchEngine> Create(IEnumerable<ISearchEngine> searchEngines)
    {
        List<ISearchEngine> typedSearchEngines = new();

        foreach (ISearchEngine searchEngine in searchEngines)
        {
            typedSearchEngines.Add(Create(searchEngine));
        }

        return typedSearchEngines;
    }

    public ISearchEngine Create(ISearchEngine searchEngine)
    {
        switch (searchEngine.Name?.ToLower())
        {
            case GOOGLE_NAME:
                {
                    GoogleSearchEngine google = new GoogleSearchEngine(_httpClient);
                    return _mapper.Map<ISearchEngine, GoogleSearchEngine>(searchEngine, google);
                }
            case BING_NAME: 
                {
                    BingSearchEngine bing = new BingSearchEngine(_httpClient);
                    return _mapper.Map< ISearchEngine, BingSearchEngine >(searchEngine, bing);
                }
            default:
                {
                    SearchEngine defaultSearchEngine = new SearchEngine(_httpClient);
                    return _mapper.Map<ISearchEngine, SearchEngine>(searchEngine, defaultSearchEngine);
                }
        }
    }
}
