using NetRom.Weather.Application.Models;

namespace NetRom.Weather.Application.Services;

public class CityService : ICityService
{
    public Task<Guid> CreateAsync(CityModelForCreation cityModelForCreation)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(Guid cityId)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<CityModel>> GetAllAsync()
    {
        return await Task.FromResult(new List<CityModel>());
    }

    public Task<CityModel> GetByIdAsync(Guid cityId)
    {
        throw new NotImplementedException();
    }

    public Task<CityModel> UpdateAsync(CityModel cityModel)
    {
        throw new NotImplementedException();
    }
}
