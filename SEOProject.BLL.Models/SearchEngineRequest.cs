namespace SEOProject.BLL.Models
{
    public class SearchEngineRequest
    {
        public string SearchText { get; set; } = string.Empty;

        public int MaxResults {  get; set; }
    }
}
