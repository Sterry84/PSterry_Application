namespace SEOProject.BLL.Models.Implementation
{
    public class GoogleSearchEngine : SearchEngine
    {
        public GoogleSearchEngine() : base()
        {
            /* no op */
        }

        public GoogleSearchEngine(HttpClient httpClient) : base(httpClient)
        {
            /* no op */
        }

        protected override string GetQueryString(SearchEngineRequest searchEngineRequest)
        {
            return SearchQueryStringTemplate
                .Replace("[maxresults]", searchEngineRequest.MaxResults.ToString())
                .Replace("[searchtext]", searchEngineRequest.SearchText);
        }
    }
}
