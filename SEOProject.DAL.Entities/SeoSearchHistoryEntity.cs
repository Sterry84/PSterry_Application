using System.ComponentModel.DataAnnotations.Schema;

namespace SEOProject.DAL.Entities;

[Table("SeoSearchHistory")]
public class SeoSearchHistoryEntity
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("SeoSearchHistoryId")]
    public Guid Id { get; set; }

    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("SeoSearchHistoryClusteredId")]
    public int ClusteredId { get; set; }
    
    public SearchEngineEntity SearchEngine { get; set; }

    public string SeoSearchText {  get; set; }

    public string TargetUrl { get; set; }
    
    public DateTime SeoSearchDate { get; set; }

    public IList<SeoSearchHistoryResultEntity> Results { get; set; }
}
