using SEOProject.DAL.Entities;

namespace SEOProject.DAL.Interfaces;

public interface ISearchEngineGateway
{
    IEnumerable<SearchEngineEntity> GetSearchEngines();

    IEnumerable<SearchEngineEntity> GetSearchEngines(string? searchEngineName);
}
