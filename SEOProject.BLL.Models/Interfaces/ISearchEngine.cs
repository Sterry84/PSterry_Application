namespace SEOProject.BLL.Models.Interfaces;

public interface ISearchEngine
{
    Guid Id { get; set; }

    int ClusteredId { get; set; }

    string Name { get; set; }

    string BaseUrl { get; set; }

    string SearchQueryStringTemplate { get; set; }

    string ResultUrlExtractionRegEx { get; set; }

    Task<string> Search(string searchText);

    IList<string> ExtractUrls(string searchResultText);
}
