using SEOProject.BLL.Models.Interfaces;

namespace SEOProject.BLL.Interfaces;

public interface ISearchEngineFactory
{
    IEnumerable<ISearchEngine> Create(IEnumerable<ISearchEngine> searchEngines);

    ISearchEngine Create(ISearchEngine searchEngine);
}
