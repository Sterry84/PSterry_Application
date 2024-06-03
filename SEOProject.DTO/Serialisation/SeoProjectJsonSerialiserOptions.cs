using System.Text.Json;

namespace SEOProject.API.DTO.Serialisation;

public static class SeoProjectJsonSerialiserOptions
{
    public static JsonSerializerOptions StandardOptions => new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };
}