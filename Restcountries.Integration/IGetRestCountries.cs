using Refit;
using Restcountries.Classes.Classes;

namespace Restcountries.Integration
{
    public interface IGetRestCountries
    {
        [Get("/v3.1/region/europe")]
        Task<IEnumerable<Country>> GetAllCountriesInEurope();
        
        [Get("/v2/regionalbloc/eu?fields=capital")]
        Task<IEnumerable<CapitalCity>> GetAllCapitalCitiesFromEU();

        // End point to search all countries by name!
        [Get("/v3.1/name/{name}")]
        Task<IEnumerable<Country>> GetCountryByName(string name);
    }
}
