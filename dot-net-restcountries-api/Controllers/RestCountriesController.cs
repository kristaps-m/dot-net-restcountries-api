using Microsoft.AspNetCore.Mvc;
using Restcountries.Integration;
using Restcountries.Services.Filters;

namespace dot_net_restcountries_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestCountriesController : ControllerBase
    {
        private readonly IGetRestCountries _countries;

        public RestCountriesController(IGetRestCountries countries)
        {
            _countries = countries;
        }

        [HttpGet]
        [Route("europe-Population/top10")]
        public async Task<IActionResult> GetTopTenByPopulationInEurope()
        {
            var allCountriesInEurope = await _countries.GetAllCountriesInEurope();
            var allEUCapitalCities = await _countries.GetAllCapitalCitiesFromEU();
            var allEuropeanUnionCountries = RestCountriesFilter.FilterEuropeanUnionCountriesByCapitalCity(allCountriesInEurope,allEUCapitalCities);
            var topTenPopulation = RestCountriesFilter.GetTopTenCountriesByPopulation(allEuropeanUnionCountries);

            return Ok(topTenPopulation);
        }

        [HttpGet]
        [Route("europe-Population-Density/top10")]
        public async Task<IActionResult> GetTopTenByPopulationDensityInEurope()
        {
            var allCountriesInEurope = await _countries.GetAllCountriesInEurope();
            var allEUCapitalCities = await _countries.GetAllCapitalCitiesFromEU();
            var allEuropeanUnionCountries = RestCountriesFilter.FilterEuropeanUnionCountriesByCapitalCity(allCountriesInEurope,allEUCapitalCities);
            var topTenPopulationDensity = RestCountriesFilter.GetTopTenCountriesByPopulationDensity(allEuropeanUnionCountries);

            return Ok(topTenPopulationDensity);
        }

        [HttpGet]
        [Route("{name}")]
        public async Task<IActionResult> GetOneCountryByName(string name)
        {
            var allCountriesInEurope = await _countries.GetAllCountriesInEurope();
            var allEUCapitalCities = await _countries.GetAllCapitalCitiesFromEU();
            var allEuropeanUnionCountries = RestCountriesFilter.FilterEuropeanUnionCountriesByCapitalCity(allCountriesInEurope,allEUCapitalCities);            
            var oneCountryExceptName = RestCountriesFilter.ReturnOneCountryWithOutName(allEuropeanUnionCountries, name);

            if (oneCountryExceptName != null)
            {
                return Ok(oneCountryExceptName);
            }

            return BadRequest($"There is no such European Union country '{name}' or make sure you spelled it correctly!");            
        }
    }
}
