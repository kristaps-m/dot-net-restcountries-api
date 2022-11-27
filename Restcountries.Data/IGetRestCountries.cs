using dot_net_restcountries_api.Classes;
using Refit;

namespace dot_net_restcountries_api.Data
{
    public interface IGetRestCountries
    {
        [Get("/v3.1/region/europe")]
        Task<IEnumerable<Country>> GetAllCountriesInEurope();

        // End point to search all countries !
        [Get("/v3.1/name/{name}")]
        Task<IEnumerable<Country>> GetCountryByName(string name);
    }
}
