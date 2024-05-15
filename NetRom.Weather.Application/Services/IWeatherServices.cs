using NetRom.Weather.Application.Models;

namespace NetRom.Weather.Application.Services;
public interface IWeatherServices
{
    // Fa un call la webservice, paseaza lat si ling si parseaza raspunsul
    Task<WeatherModel> GetWeatherAsync(double lat, double lon, CancellationToken cancellationToken = default);
}

