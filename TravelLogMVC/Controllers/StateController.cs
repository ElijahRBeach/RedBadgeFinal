using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TravelLog.Models.State;
using TravelLog.Services.State;

namespace TravelLogMVC.Controllers
{
    public class StateController : Controller
    {
        private readonly IStateService _stateService;
        public StateController(IStateService stateService)
        {
            _stateService = stateService;
        }


        public IActionResult Create()
        {
            return View();
        }
        //CreateState endpoint
        [HttpPost]
        public async Task<IActionResult> Create(StateCreate request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (await _stateService.CreateStateAsync(request) == false)
                return BadRequest("State could not be created.");

            return Redirect("/state");
        }

        //GetAllStates endpoint
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var states = await _stateService.GetAllStatesAsync();
            return View(states);
        }

        //GetStateById endpoint
        [HttpGet]
        public async Task<IActionResult> Details([FromRoute] int id)
        {
            var detail = await _stateService.GetStateByIdAsync(id);

            return detail is not null
            ? View(detail)
            : NotFound();
        }

        //UpdateState endpint
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var detail = await _stateService.GetStateByIdAsync(id);

            if(detail is null)
                return NotFound();

            var model = new StateUpdate
            {
                StateId = detail.StateId,
                Name = detail.Name
            };

            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(StateUpdate request)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            if(await _stateService.UpdateStateAsync(request) == false)
                return BadRequest("State could not be updated.");

            return Redirect("/state");
        }

        //DeleteState endpoint
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var detail = await _stateService.GetStateByIdAsync(id);

            if (detail is null)
                return NotFound();

            return View(detail);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(int id, StateDetail model)
        {
            return await _stateService.DeleteStateAsync(id)
            ? Redirect("/state")
            : BadRequest($"State {id} could not be deleted");
        }
    }
}