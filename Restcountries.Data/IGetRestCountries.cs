using Refit;
using Restcountries.Classes.Classes;

namespace Restcountries.Integration
{
    public interface IGetRestCountries
    {
        [Get("/v3.1/region/europe")]
        Task<IEnumerable<Country>> GetAllCountriesInEurope();

        // End point to search all countries by name!
        [Get("/v3.1/name/{name}")]
        Task<IEnumerable<Country>> GetCountryByName(string name);
    }
}
