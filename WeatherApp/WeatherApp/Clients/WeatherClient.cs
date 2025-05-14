using AutoMapper;
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
        .SetSize(50)
        .SetSlidingExpiration(TimeSpan.FromMinutes(5));
    
    
    

    public static void AddWeatherEndpoints(this IEndpointRouteBuilder app)
    {
        var config = new MapperConfiguration(cfg => 
        {
            cfg.CreateMap<WeatherResponse, WeatherModel>();
            cfg.CreateMap<Days, WeatherDays>();
            cfg.CreateMap<CurrentConditions, WeatherCurrentConditions>();
            cfg.CreateMap<Hours, WeatherHours>();
        });
        
        IMapper mapper = config.CreateMapper();

        
        app.MapGet("WeatherForecast15Days", async (string location) =>
        {
            
            if (_memoryCache.TryGetValue(location, out WeatherResponse? weatherResponse))
            {
                WeatherModel cacheModel = mapper.Map<WeatherModel>(weatherResponse);
                cacheModel.City = location;
                Console.WriteLine("Cache accessed.");
                return Results.Ok(cacheModel);
            }
            var response = await _httpClient.GetFromJsonAsync<WeatherResponse?>($"{location}?unitGroup=metric&key={WeatherAPIKey}");
            

            if (response is null)
            {
                return Results.NotFound("Weather request could not be retrieved.");
            }
            
            WeatherModel model = mapper.Map<WeatherModel>(response);
            model.City = location;
            
            _memoryCache.Set($"{location}15", response, cacheOptions);
            
            return Results.Ok(model);

        });

        app.MapGet("WeatherForecastToday", async (string location) =>
        {
            
            if (_memoryCache.TryGetValue(location, out WeatherResponse? weatherResponse))
            {
                WeatherModel cacheModel = mapper.Map<WeatherModel>(weatherResponse);
                cacheModel.City = location;
                Console.WriteLine("Cache accessed.");
                return Results.Ok(cacheModel);
            }
            
            DateTime dateTime = DateTime.Today;
            string date = dateTime.ToString("yyyy-MM-dd");
            
            var response = await _httpClient.GetFromJsonAsync<WeatherResponse>($"{location}/{date}?unitGroup=metric&key={WeatherAPIKey}");
            
            if (response is null)
            {
                return Results.NotFound("Weather request could not be retrieved.");
            }
            
            WeatherModel model = mapper.Map<WeatherModel>(response);
            model.City = location;
            
            _memoryCache.Set($"{location}Today", response, cacheOptions);
            
            return Results.Ok(model);
        });
        
        app.MapGet("WeatherForecastFromTill", async (string location, string date1, string date2) =>
        {
            
            if (_memoryCache.TryGetValue(location, out WeatherResponse? weatherResponse))
            {
                WeatherModel cacheModel = mapper.Map<WeatherModel>(weatherResponse);
                cacheModel.City = location;
                Console.WriteLine("Cache accessed.");
                return Results.Ok(cacheModel);
            }
            
            var response = await _httpClient.GetFromJsonAsync<WeatherResponse?>($"{location}/{date1}/{date2}?unitGroup=metric&key={WeatherAPIKey}");
            
            if (response is null)
            {
                return Results.NotFound("Weather request could not be retrieved.");
            }
            
            WeatherModel model = mapper.Map<WeatherModel>(response);
            model.City = location;
            
            _memoryCache.Set(location, response, cacheOptions);
            
            return Results.Ok(model);

        });
    }
}