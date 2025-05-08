using Microsoft.Extensions.Caching.Memory;
using WeatherApp.Models;

namespace WeatherApp.Clients;

public static class WeatherClient
{
    
    private static string WeatherAPIKey = "6NRGHP3EHP5Q2GEBJ2WLT39J2";
    
    private static readonly HttpClient _httpClient = new()
    {
        BaseAddress = new Uri("https://weather.visualcrossing.com/VisualCrossingWebServices/rest/services/timeline/")
    };

    private static readonly IMemoryCache _memoryCache = new MemoryCache(new MemoryCacheOptions());
    
    private static MemoryCacheEntryOptions cacheOptions = new MemoryCacheEntryOptions()
        .SetAbsoluteExpiration(TimeSpan.FromMinutes(30))
        .SetSize(20)
        .SetSlidingExpiration(TimeSpan.FromMinutes(5));
    

    public static void AddWeatherEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapGet("WeatherForecast15Days", async (string location) =>
        {
            if (_memoryCache.TryGetValue(location, out WeatherResponse? weatherResponse))
            {
                Console.WriteLine("Cache accessed.");
                return Results.Ok(weatherResponse);
            }
            
            var response = await _httpClient.GetFromJsonAsync<WeatherResponse?>($"{location}?key={WeatherAPIKey}");

            if (response is null)
            {
                return Results.NotFound("Weather request could not be retrieved.");
            }
            
            _memoryCache.Set($"{location}15", response, cacheOptions);
            
            return Results.Ok(response);

        });

        app.MapGet("WeatherForecastToday", async (string location) =>
        {
            if (_memoryCache.TryGetValue(location, out WeatherResponse? weatherResponse))
            {
                Console.WriteLine("Cache accessed.");
                return Results.Ok(weatherResponse);
            }
            
            DateTime dateTime = DateTime.Today;
            string date = dateTime.ToString("yyyy-MM-dd");
            var response = await _httpClient.GetFromJsonAsync<WeatherResponse>($"{location}/{date}?key={WeatherAPIKey}");
            
            if (response is null)
            {
                return Results.NotFound("Weather request could not be retrieved.");
            }
            
            _memoryCache.Set($"{location}Today", response, cacheOptions);
            
            return Results.Ok(response);
        });
        
        app.MapGet("WeatherForecastFromTill", async (string location, string date1, string date2) =>
        {
            if (_memoryCache.TryGetValue(location, out WeatherResponse? weatherResponse))
            {
                Console.WriteLine("Cache accessed.");
                return Results.Ok(weatherResponse);
            }
            
            var response = await _httpClient.GetFromJsonAsync<WeatherResponse?>($"{location}/{date1}/{date2}?key={WeatherAPIKey}");
            
            if (response is null)
            {
                return Results.NotFound("Weather request could not be retrieved.");
            }
            
            _memoryCache.Set(location, response, cacheOptions);
            
            return Results.Ok(response);

        });
    }
}