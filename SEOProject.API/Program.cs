using Microsoft.EntityFrameworkCore;
using SEOProject.API.Configuration;
using SEOProject.BLL.Implementation;
using SEOProject.BLL.Interfaces;
using SEOProject.DAL.Implementation;
using SEOProject.DAL.Interfaces;
using SEOProject.DAL.SqlServer;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddHttpClient<ISearchEngineFactory>();
builder.Services.AddSingleton(AutoMapperConfiguration.Create());

builder.Services.AddScoped<ISearchEngineFactory, SearchEngineFactory>();
builder.Services.AddScoped<IWebSearchService, WebSearchService>();
builder.Services.AddScoped<ISearchEngineGateway, SearchEngineGateway>();
builder.Services.AddScoped<ISeoSearchHistoryGateway, SeoSearchHistoryGateway>();
builder.Services.AddScoped<IApplicationDataService, ApplicationDataService>();
builder.Services.AddDbContext<SEOProjectDbContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("SEOProject_PSterry")));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
