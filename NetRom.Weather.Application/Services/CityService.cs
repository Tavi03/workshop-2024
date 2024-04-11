using NetRom.Weather.Application.Models;

namespace NetRom.Weather.Application.Services;

public class CityService : ICityService
{
    private readonly IList<CityModel> _cityModels;

    public CityService()
    {
        _cityModels = new List<CityModel>()
        {
            new()
            {
                Id = Guid.NewGuid(),
                Name = "Craiova",
                Latitude = 1,
                Longitude = 21,
                Temperature = 43
            },
            new()
            {
                Id = Guid.NewGuid(),
                Name = "Rm Valcea",
                Latitude = 1,
                Longitude = 34,
                Temperature = 12
            },
            new()
            {
                Id = Guid.NewGuid(),
                Name = "Bucuresti",
                Latitude = 21,
                Longitude = 211,
                Temperature = 2
            },
        };
    }

    public Task<Guid> CreateAsync(CityModelForCreation cityModelForCreation)
    {
        var newCity = new CityModel()
        {
            Id = Guid.NewGuid(),
            Latitude = cityModelForCreation.Latitude,
            Longitude = cityModelForCreation.Longitude,
            Name = cityModelForCreation.Name,
        };
        _cityModels.Add(newCity);
        return Task.FromResult(newCity.Id);
    }

    public Task DeleteAsync(Guid cityId)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<CityModel>> GetAllAsync()
    {
        return await Task.FromResult(_cityModels);
    }

    //Note (Practice): Trebuie sa cautam in colectia din memorie entitate de tip City folosind id-ul primit de la caller
    //Note (Practice): Apoi sa facem update la editatea gasita.
    //Note (Practice): Nu uitati de async
    public Task<CityModel> GetByIdAsync(Guid cityId)
    {
        throw new NotImplementedException();
    }

    public Task<CityModel> UpdateAsync(CityModel cityModel)
    {
        throw new NotImplementedException();
    }
}
