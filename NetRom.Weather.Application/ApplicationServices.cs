using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using NetRom.Weather.Application.Options;
using NetRom.Weather.Application.Services;

namespace NetRom.Weather.Application;

public static class ApplicationServices
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddHttpClient("weather",
            (serviceProvider, client) =>
            {
                var options = serviceProvider.GetRequiredService<IOptions<WeatherApiOptions>>()?.Value;
                client.BaseAddress = new Uri(options.Url);
            });
        services
            .AddSingleton<ICityService, CityService>()
            .AddSingleton<IWeatherServices, WeatherService>();
        services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        return services;
    }
}
