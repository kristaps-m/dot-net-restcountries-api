using dot_net_restcountries_api.Classes;
using dot_net_restcountries_api.Filters;
using System.Text.Json;

namespace Restcountries.Tests
{
    public class RestcountriesServicesTests
    {
        private readonly List<Country> _countries = new() 
        {
            new Country
            {
                Name = new TheName{Official = "Kingdom of Spain", Common = "Spain"},
                Area = 1000,
                Population = 40000,
                TopLevelDomain = new List<string> { ".es" },
                Capital = new List<string> {"Madrid"},
            },
            new Country
            {
                Name = new TheName{Official = "Italian Republic", Common = "Italy"},
                Area = 1000,
                Population = 50000,
                TopLevelDomain = new List<string> { ".it" },
                Capital = new List<string> {"Rome"},
            },
            new Country
            {
                Name = new TheName{Official = "French Republic", Common = "France"},
                Area = 1000,
                Population = 60000,
                TopLevelDomain = new List<string> { ".fr" },
                Capital = new List<string> {"Paris"},
            },
            new Country
            {
                Name = new TheName{Official = "Federal Republic of Germany", Common = "Germany"},
                Area = 1000,
                Population = 80000,
                TopLevelDomain = new List<string> { ".de" },
                Capital = new List<string> {"Berlin"},
            },
        };

        
        [Fact]
        public void GetTopTenCountriesByPopulation_TestFilter_ShouldReturnListInCorrectOrder()
        {
            // Arrange
            var expectedResult = new List<Country> 
            {
                new Country
                {
                    Name = new TheName{Official = "Federal Republic of Germany", Common = "Germany"},
                    Area = 1000,
                    Population = 80000,
                    TopLevelDomain = new List<string> { ".de" },
                    Capital = new List<string> {"Berlin"},
                },
                new Country
                {
                    Name = new TheName{Official = "French Republic", Common = "France"},
                    Area = 1000,
                    Population = 60000,
                    TopLevelDomain = new List<string> { ".fr" },
                    Capital = new List<string> {"Paris"},
                },
                new Country
                {
                    Name = new TheName{Official = "Italian Republic", Common = "Italy"},
                    Area = 1000,
                    Population = 50000,
                    TopLevelDomain = new List<string> { ".it" },
                    Capital = new List<string> {"Rome"},
                },
                new Country
                {
                    Name = new TheName{Official = "Kingdom of Spain", Common = "Spain"},
                    Area = 1000,
                    Population = 40000,
                    TopLevelDomain = new List<string> { ".es" },
                    Capital = new List<string> {"Madrid"},
                },

            };
            // Act
            var result = RestCountriesFilter.GetTopTenCountriesByPopulation(_countries);
            var expectedJsonObject = JsonSerializer.Serialize(expectedResult);
            var resultJsonObject = JsonSerializer.Serialize(result);
            // Assert
            Assert.Equal(expectedJsonObject, resultJsonObject);
        }
    }
}