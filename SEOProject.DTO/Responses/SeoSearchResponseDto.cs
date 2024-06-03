namespace SEOProject.API.DTO.Responses;

public class SeoSearchResponseDto
{
    public IEnumerable<SeoSearchResultDto> SearchResults { get; set; } = new List<SeoSearchResultDto>();
}
