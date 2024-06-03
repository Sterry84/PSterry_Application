namespace SEOProject.BLL.Models.Implementation;

public class BingSearchEngine : SearchEngine
{
    public BingSearchEngine() : base()
    {
        /* no op */
    }

    public BingSearchEngine(HttpClient httpClient) : base(httpClient)
    {
        /* no op */
    }

    protected override IList<string> ProcessUrls(IList<string> urls)
    {
        return urls.Select(url => url.Replace("<span class=\"b_agspsc\">", string.Empty)
                .Replace("</span>", string.Empty)
                .Replace("<span class=\"b_agspdm\">", string.Empty)
                .Replace("<span class=\"b_agsppt\">", string.Empty))
            .ToList();
    }
}
