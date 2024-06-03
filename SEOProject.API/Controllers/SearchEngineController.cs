using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SEOProject.API.DTO.Responses;
using SEOProject.DAL.Entities;
using SEOProject.DAL.Interfaces;

namespace SEOProject.API.Controllers;

[ApiController]
[Route("[controller]")]
public class SearchEngineController : ControllerBase
{
    private readonly IApplicationDataService _appDataService;
    private readonly IMapper _mapper;

    public SearchEngineController(IApplicationDataService appDataService, IMapper mapper)
    {
        _appDataService = appDataService;
        _mapper = mapper;
    }

    [ProducesResponseType(typeof(SearchEngineNamesResponseDto), 200)]
    [HttpGet("Names")]
    public IActionResult Get()
    {
        IEnumerable<SearchEngineEntity> searchEngineEntities = _appDataService.SearchEngineGateway.GetSearchEngines();
        return Ok(new SearchEngineNamesResponseDto() { SearchEngineNames = searchEngineEntities.Select(e => e.Name) });
    }
}
