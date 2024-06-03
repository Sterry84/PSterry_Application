using AutoMapper;
using SEOProject.DAL.Entities;
using SEOProject.BLL.Models.Implementation;
using SEOProject.BLL.Models;
using SEOProject.API.DTO.Responses;

namespace SEOProject.API.Configuration;

public static class AutoMapperConfiguration
{
    public static IMapper Create()
    {
        return new MapperConfiguration(config =>
        {
            config.CreateMap<SearchEngine, GoogleSearchEngine>();
            config.CreateMap<SearchEngine, BingSearchEngine>();
            config.CreateMap<SearchEngineEntity, SearchEngine>();
            config.CreateMap<SeoSearchResult, SeoSearchResultDto>();
        }).CreateMapper();
    }
}
