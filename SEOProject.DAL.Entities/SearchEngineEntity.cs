using System.ComponentModel.DataAnnotations.Schema;

namespace SEOProject.DAL.Entities;

[Table("SearchEngines")]
public class SearchEngineEntity
{
    [Column("SearchEngineId")]
    public Guid Id { get; set; }

    [Column("SearchEngineClusteredId")]
    public int ClusteredId { get; set; }

    [Column("SearchEngineName")]
    public string Name { get; set; } = string.Empty;

    public string BaseUrl { get; set; } = string.Empty;

    public string SearchQueryStringTemplate { get; set; } = string.Empty;

    public string ResultUrlExtractionRegEx { get; set; } = string.Empty;
}
