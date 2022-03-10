using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TravelLog.Models.City;
using TravelLog.Services.City;

namespace TravelLogMVC.Controllers
{
    public class CityController : Controller
    {
        private readonly ICityService _cityService;
         public CityController(ICityService cityService)
        {
            _cityService = cityService;
        }

        public IActionResult Create()
        {
            return View();
        }
        //CreateCities
        [HttpPost]
        public async Task<IActionResult> Create(CityCreate request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (await _cityService.CreateCityAsync(request) == false)
                return BadRequest("City could not be created.");

            return Redirect("/city");
        }

        //GetAllCities
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var cities = await _cityService.GetAllCitiesAsync();

            return View(cities);
        }

        //GetCityById
        [HttpGet]
        public async Task<IActionResult> Details([FromRoute] int id)
        {
            var detail = await _cityService.GetCityByIdAsync(id);

            if (detail is null)
                return NotFound();

            return View(detail);
        }

        //UpdateCity
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var detail = await _cityService.GetCityByIdAsync(id);

            if (detail is null)
                return NotFound();

            var model = new CityUpdate
            {
                CityId = detail.CityId,
                Name = detail.Name
            };

            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(CityUpdate request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (await _cityService.UpdateCityAsync(request) == false)
                return BadRequest("City could not be updated.");

            return Redirect("/city");
        }

        //Delete Cities
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var detail = await _cityService.GetCityByIdAsync(id);

            if (detail is null)
                return NotFound();

            return View(detail);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(int id, CityDetail model)
        {
            if (await _cityService.DeleteCityAsync(id) == false)
                return BadRequest($"City {id} could not be deleted.");
            
            return Redirect("/city");
        }
    }
}