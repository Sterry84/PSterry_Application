namespace SEOProject.BLL.Models;

public class SeoSearchResult
{
    public string SearchEngineName { get; set; } = string.Empty;

    public IEnumerable<int> Ranks { get; set; } = new List<int>();
}
