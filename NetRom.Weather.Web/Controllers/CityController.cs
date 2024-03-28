using Microsoft.AspNetCore.Mvc;
using NetRom.Weather.Application.Models;
using NetRom.Weather.Application.Services;

namespace NetRom.Weather.Web.Controllers
{
    public class CityController : Controller
    {
        private ICityService _cityService = new CityService();

        private readonly ILogger<CityController> _logger;

        public CityController(ILogger<CityController> logger)
        {
            _logger = logger;
        }

        //Note: Enpoint pentru a afisa lista cu toate orasele
        public async Task<IActionResult> Index()
        {
            var result = await _cityService.GetAllAsync();
            return View(result);
        }

        //Note: Enpoint pentru a creea un nou oras
        [HttpPost]
        public async Task<IActionResult> Create(CityModelForCreation cityModelForCreation)
        {
            await _cityService.CreateAsync(cityModelForCreation);

            return RedirectToAction(nameof(Index));
        }

        //Note: Enpoint pentru a creea un oras nou
        [HttpDelete]
        public async Task Delete(Guid cityId)
        {
            await _cityService.DeleteAsync(cityId);
        }

        //Note: Endpoint pentru a updata un oras existent
        [HttpPut]
        public async Task<IActionResult> Update(CityModel cityModel)
        {   
            //if(ModelState.IsValid) 
            //{
            //    return View(cityModel);
            //}

            var result = await _cityService.UpdateAsync(cityModel);

            return RedirectToAction(nameof(Index));
        }

        //Note: Enpoint pentru a obtine pagina de Create
        //Note: Va puteti gandi cum am putea obtine view-ul de Create

        //Note: Endpoint pentru a obtine view-ul pentru edit si a-l popula cu datele currente
        //Note: Va puteti gandi cum am putea sa facem sa obtinem datele si a redirectiona catre view-ul necesar
    }
}
