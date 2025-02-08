using Microsoft.AspNetCore.Mvc;
using SingletonPattern.Domain.Entities;
using SingletonPattern.Domain.Interfaces;

namespace SingletonPattern.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly ICountryRepository _countryService;

        public CountryController(ICountryRepository cityService)
        {
            _countryService = cityService;
        }

        [HttpGet]
        public IActionResult GetAllCountries()
        {
            return Ok(_countryService.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult GetCountryById(int id)
        {
            var country = _countryService.GetById(id);
            if (country == null) return NotFound();
            return Ok(country);
        }

        [HttpPost]
        public IActionResult AddCity(Country country)
        {
            var result = _countryService.Add(country);
            return CreatedAtAction(nameof(GetCountryById), new { id = result }, country);
        }

        [HttpPut]
        public IActionResult UpdateCountry(Country country)
        {
            var result = _countryService.Update(country);
            if (result == 0) return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCountry(int id)
        {
            var result = _countryService.Delete(id);
            if (result == 0) return NotFound();
            return NoContent();
        }
    }
}
