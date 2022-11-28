using Restcountries.Classes.Classes;

namespace Restcountries.Services.Filters
{
    public static class RestCountriesFilter
    {
        public static IEnumerable<Country> GetTopTenCountriesByPopulation(IEnumerable<Country> countries)
        {
            return countries.OrderByDescending(country => country.Population).Take(10);
        }

        public static IEnumerable<Country> GetTopTenCountriesByPopulationDensity(IEnumerable<Country> countries)
        {
            return countries.OrderByDescending(country => country.Population / country.Area).Take(10);
        }

        public static IEnumerable<Country> FilterEuropeanUnionCountriesByCapitalCity(IEnumerable<Country> countries,
            IEnumerable<CapitalCity> capitalCities)
        {
            var europeanUnionCountries = new List<Country>();
            var listOfCapitalCities = new List<string>();
            
            foreach (var capitalCity in capitalCities)
            {
                listOfCapitalCities.Add(capitalCity.Capital);
            }
            
            foreach (var c in countries)
            {
                if (c.Capital != null)
                {
                    if (listOfCapitalCities.Contains(c.Capital[0]))
                    {
                        europeanUnionCountries.Add(c);
                    }
                }
            }

            return europeanUnionCountries;
        }

        public static CountryExceptName ReturnOneCountryWithOutName(IEnumerable<Country> countries, string name)
        {
            var countryNoName = new CountryExceptName();
            foreach (var c in countries)
            {
                if (name.ToLower().Trim() == c?.Name?.Common?.ToLower().Trim())
                {
                    countryNoName.Area = c.Area;
                    countryNoName.TopLevelDomain = c.TopLevelDomain;
                    countryNoName.Population = c.Population;
                    countryNoName.Capital = c.Capital;
                    countryNoName.CommonNativeName = c.Name?.NativeName?.ElementAt(0).Value.Common;
                }
            }

            if (countryNoName.Area == 0 && countryNoName.Population == 0
                && countryNoName.TopLevelDomain == null
                && countryNoName.Capital == null
                && countryNoName.CommonNativeName == null)
            {
                countryNoName = null;
            }

            return countryNoName;
        }
    }
}
