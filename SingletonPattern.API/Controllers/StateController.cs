using Microsoft.AspNetCore.Mvc;
using SingletonPattern.Domain.Entities;
using SingletonPattern.Domain.Interfaces;

namespace SingletonPattern.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StateController : ControllerBase
    {
        private readonly IStateRepository _stateService;

        public StateController(IStateRepository cityService)
        {
            _stateService = cityService;
        }

        [HttpGet]
        public IActionResult GetAllStates()
        {
            return Ok(_stateService.GetAll());
        }

        [HttpGet("[action]/{countryId}")]
        public IActionResult GetStatesByCountry(int countryId)
        {
            var states = _stateService.GetStatesByCountry(countryId); // Fetch states from DB or service
            if (states == null || !states.Any())
            {
                return NotFound(new { message = "No states found for the given country ID." });
            }

            return Ok(states);
        }



        [HttpGet("{id}")]
        public IActionResult GetStateById(int id)
        {
            var state = _stateService.GetById(id);
            if (state == null) return NotFound();
            return Ok(state);
        }

        [HttpPost]
        public IActionResult AddState(State state)
        {
            var result = _stateService.Add(state);
            return CreatedAtAction(nameof(GetStateById), new { id = result }, state);
        }

        [HttpPut]
        public IActionResult UpdateState(State state)
        {
            var result = _stateService.Update(state);
            if (result == 0) return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteState(int id)
        {
            var result = _stateService.Delete(id);
            if (result == 0) return NotFound();
            return NoContent();
        }
    }
}
