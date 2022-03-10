using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TravelLog.Models.Country;
using TravelLog.Services.Country;

namespace TravelLogMVC.Controllers
{
    public class CountryController : Controller
    {
        private readonly ICountryService _countryService;
        public CountryController(ICountryService countryService)
        {
            _countryService = countryService;
        }

        public IActionResult Create()
        {
            return View();
        }
        //CreateCountry endpoint
        [HttpPost]
        public async Task<IActionResult> Create(CountryCreate request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (await _countryService.CreateCountryAsync(request) == false)
                return BadRequest("Country could not be created.");

            return Redirect("/country");
        }

        //GetCountryById endpoint
        [HttpGet]
        public async Task<IActionResult> Details([FromRoute] int id)
        {
            var detail = await _countryService.GetCountryByIdAsync(id);

            return detail is not null ? View(detail) : NotFound();
        }

        //GetAllCountries endpoint
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var countries = await _countryService.GetAllCountriesAsync();
            return View(countries);
        }

        //UpdateCountry endpoint
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var detail = await _countryService.GetCountryByIdAsync(id);

            if(detail is null)
                return NotFound();

            var model = new CountryUpdate
            {
                CountryId = detail.CountryId,
                Name = detail.Name
            };

            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(CountryUpdate request)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            if(await _countryService.UpdateCountryAsync(request) == false)
                return BadRequest("Country could not be updated.");

            return Redirect("/country");
        }

        //DeleteCountry endpoint
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var detail = await _countryService.GetCountryByIdAsync(id);

            if (detail is null)
                return NotFound();

            return View(detail);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(int id, CountryDetail model)
        {
            return await _countryService.DeleteCountryAsync(id)
            ? Redirect("/country")
            : BadRequest($"Country {id} could not be deleted");
        }
    }
}