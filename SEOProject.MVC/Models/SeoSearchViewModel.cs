namespace SEOProject.MVC.Models;

public class SeoSearchViewModel
{
    public string SearchText { get; set; } = "land registry search";

    public string TargetUrl { get; set; } = "https://www.infotrack.co.uk";

    public string SearchResponse { get; set; } = string.Empty;

    public SearchEngine SelectedSearchEngine { get; set; } = SearchEngine.All;
}

public enum SearchEngine
{
    All,
    Google,
    Bing
}