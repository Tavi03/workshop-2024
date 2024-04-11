using Microsoft.AspNetCore.Mvc;
using NetRom.Weather.Application.Models;
using NetRom.Weather.Application.Services;

namespace NetRom.Weather.Web.Controllers
{
    public class CityController : Controller
    {
        private readonly ICityService _cityService;

        private readonly ILogger<CityController> _logger;

        public CityController(ILogger<CityController> logger, ICityService cityService)
        {
            _logger = logger;
            _cityService = cityService;
        }

        //Note: Enpoint pentru a afisa lista cu toate orasele
        public async Task<IActionResult> Index()
        {
            var result = await _cityService.GetAllAsync();
            return View(result);
        }

        //Note: Enpoint pentru a creea un nou oras
        //Note (Practice): Puteti sa adaugati server side validation pentru view model. Vedeti commentul de la Update [HttpPut]
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

        //Note: Endpoint pentru a obtine view-ul de Create
        public IActionResult Create()
        {
            return View();
        }

        //Note (Practice): Endpoint pentru a obtine view-ul pentru edit si a-l popula cu datele currente
        //Note (Practice): Pentru a creea view-ul de Edit. Click dreapta pe folderul Views/City => Add view => Razor view si urmati pasii ca in Workshop.
        //Note (Practice): Va puteti gandi cum am putea sa facem sa obtinem datele si a redirectiona catre view-ul necesar (_cityService.GetByIdAsync) si Create [HttpPost] ca exemplu
        //Note (Practice): Vedeti in Views/City/Index.cshtml <a> tag-ul de Edit si parametrul rutei.
    }
}
