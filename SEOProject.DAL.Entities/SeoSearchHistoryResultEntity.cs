using System.ComponentModel.DataAnnotations.Schema;

namespace SEOProject.DAL.Entities;

[Table("SeoSearchHistoryResults")]
public class SeoSearchHistoryResultEntity
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("SeoSearchHistoryResultId")]
    public Guid Id { get; set; }

    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("SeoSearchHistoryResultClusteredId")]
    public int ClusteredId { get; set; }

    public int SeoSearchResultRank { get; set; }

    public SeoSearchHistoryEntity SeoSearchHistory { get; set; }
}
