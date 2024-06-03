using Microsoft.AspNetCore.Mvc;
using SEOProject.API.Connector.Interfaces;
using SEOProject.Models;
using SEOProject.MVC.Models;
using System.Diagnostics;
using SEOProject.API.DTO.Responses;

namespace SEOProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ISEOProjectApiConnector _seoProjectApiConnector;

        public HomeController(ILogger<HomeController> logger, ISEOProjectApiConnector seoProjectApiConnector)
        {
            _logger = logger;
            _seoProjectApiConnector = seoProjectApiConnector;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> SeoSearch()
        {
            return View(new SeoSearchViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> SeoSearch(SeoSearchViewModel seoSearchViewModel)
        {
            string searchEngine = seoSearchViewModel.SelectedSearchEngine == SearchEngine.All ? string.Empty : seoSearchViewModel.SelectedSearchEngine.ToString();
            SeoSearchResponseDto seoSearchResponseDto = await _seoProjectApiConnector.SeoSearch(searchEngine, seoSearchViewModel.SearchText, seoSearchViewModel.TargetUrl);

            string result = string.Empty;
            foreach (SeoSearchResultDto seoSearchResult in seoSearchResponseDto.SearchResults)
            {
                result += $"{seoSearchResult.SearchEngineName}: {string.Join(',', seoSearchResult.Ranks)}. ";
            }
            seoSearchViewModel.SearchResponse = result;

            return View(seoSearchViewModel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
