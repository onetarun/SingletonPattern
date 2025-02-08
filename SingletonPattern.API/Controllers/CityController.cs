using Microsoft.AspNetCore.Mvc;
using SingletonPattern.Domain.Entities;
using SingletonPattern.Domain.Interfaces;

namespace SingletonPattern.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private readonly ICityRepository _cityService;

        public CityController(ICityRepository cityService)
        {
            _cityService = cityService;
        }

        [HttpGet]
        public IActionResult GetAllCities()
        {
            return Ok(_cityService.GetAll());
        }
        [HttpGet("[action]/{stateId}")]
        public IActionResult GetCitiesByState(int stateId)
        {
            var cities = _cityService.GetStatesByCountry(stateId); // Fetch states from DB or service
            if (cities == null || !cities.Any())
            {
                return NotFound(new { message = "No cities found for the given country ID." });
            }

            return Ok(cities);
        }

        [HttpGet("{id}")]
        public IActionResult GetCityById(int id)
        {
            var city = _cityService.GetById(id);
            if (city == null) return NotFound();
            return Ok(city);
        }

        [HttpPost]
        public IActionResult AddCity(City city)
        {
            var result = _cityService.Add(city);
            return CreatedAtAction(nameof(GetCityById), new { id = result }, city);
        }

        [HttpPut]
        public IActionResult UpdateCity(City city)
        {
            var result = _cityService.Update(city);
            if (result == 0) return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCity(int id)
        {
            var result = _cityService.Delete(id);
            if (result == 0) return NotFound();
            return NoContent();
        }
    }
}
