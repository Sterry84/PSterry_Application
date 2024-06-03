namespace SEOProject.API.DTO.Responses;

public class SeoSearchResultDto
{
    public string SearchEngineName { get; set; } = string.Empty;

    public IEnumerable<int> Ranks { get; set; } = new List<int>();
}
