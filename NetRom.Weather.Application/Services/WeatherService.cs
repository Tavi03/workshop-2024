using Microsoft.Extensions.Options;
using NetRom.Weather.Application.Models;
using NetRom.Weather.Application.Options;
using Newtonsoft.Json;
using System.Net.Http;


namespace NetRom.Weather.Application.Services;
public class WeatherService : IWeatherServices
{
    private readonly WeatherApiOptions _options;
    private readonly IHttpClientFactory _httpClientFactory;
    
    public WeatherService(IOptions<WeatherApiOptions> options, IHttpClientFactory httpClientFactory)
    { 
        _options = options.Value;
        _httpClientFactory = httpClientFactory;
    }

    public async Task<WeatherModel> GetWeatherAsync(double lat, double lon, CancellationToken cancellationToken)
    {
        var client = _httpClientFactory.CreateClient("weather");
        var queryString = $"?lat={lat}&lon={lon}&units=metric&appid={_options.ApiKey}";

        // Cum sa folosim un try catch in acest punct. Aruncati un custom exception.
        var response = await client.GetAsync(queryString, cancellationToken);

        if (!response.IsSuccessStatusCode)
        {
            // Ce tip de exceptie ar putea arunca din acest punct.
        }

        var body = await response.Content.ReadAsStringAsync();

        if (string.IsNullOrEmpty(body))
        {
            throw new InvalidDataException("Empty response");
        }
        else
        {
            return JsonConvert.DeserializeObject<WeatherModel>(body);
        }
    }
}
