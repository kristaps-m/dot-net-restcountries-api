using FluentAssertions;
using Restcountries.Classes.Classes;
using Restcountries.Services.Filters;
using static Restcountries.Classes.Classes.TheName;

namespace RestcountriesServices.Tests
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
                Name = new TheName{Official = "Federal Republic of Germany", Common = "Germany",
                NativeName = new Dictionary<string, NativeNameObject>() { {"deu", new NativeNameObject{ Official = "Bundesrepublik Deutschland",
                Common = "Deutschland"} } } },
                Area = 1000,
                Population = 80000,
                TopLevelDomain = new List<string> { ".de" },
                Capital = new List<string> {"Berlin"},
            },
        };

        private readonly List<CapitalCity> _europeanUnionCapitals = new()
        {
            new CapitalCity{Capital = "Berlin"}, new CapitalCity{Capital = "Paris"},new CapitalCity{Capital = "Rome"},
            new CapitalCity{Capital = "Madrid"},new CapitalCity{Capital = "Warsaw"},new CapitalCity{Capital = "Lisbon"},
            new CapitalCity{Capital = "Bucharest"},new CapitalCity{Capital = "Bratislava"}
        };
        
        [Fact]
        public void GetTopTenCountriesByPopulation_TestFilter_ShouldReturnListInCorrectOrder()
        {
            // Arrange
            var expectedResult = new List<Country> 
            {
                new Country
                {
                    Name = new TheName{Official = "Federal Republic of Germany", Common = "Germany",
                    NativeName = new Dictionary<string, NativeNameObject>() { {"deu", new NativeNameObject{ Official = "Bundesrepublik Deutschland",
                    Common = "Deutschland"} } } },
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
            var countriesByPopulation = RestCountriesFilter.GetTopTenCountriesByPopulation(_countries);
            // Assert
            expectedResult.Should().BeEquivalentTo(countriesByPopulation);
        }

        [Fact]
        public void GetTopTenCountriesByPopulationDensity_TestFilter_ShouldReturnListInCorrectOrderByDensity()
        {
            // Arrange
            var expectedResult = new List<Country>
            {
                new Country
                {
                    Name = new TheName{Official = "Federal Republic of Germany", Common = "Germany",
                    NativeName = new Dictionary<string, NativeNameObject>() { {"deu", new NativeNameObject{ Official = "Bundesrepublik Deutschland",
                    Common = "Deutschland"} } } },
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
            var countriesByPopulationDensity = RestCountriesFilter.GetTopTenCountriesByPopulationDensity(_countries);
            // Assert
            expectedResult.Should().BeEquivalentTo(countriesByPopulationDensity);
        }

        [Fact]
        public void FilterEuropeanUnionCountriesByCapitalCity_TestFilter_ShouldReturnListOfEUCountries()
        {
            // Arrange
            var expectedResult = new List<Country>
            {
                new Country
                {
                    Name = new TheName{Official = "Federal Republic of Germany", Common = "Germany",
                    NativeName = new Dictionary<string, NativeNameObject>() { {"deu", new NativeNameObject{ Official = "Bundesrepublik Deutschland",
                    Common = "Deutschland"} } } },
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
            };
            var countriesOneNotEU = new List<Country>
            {
                new Country
                {
                    Name = new TheName{Official = "Federal Republic of Germany", Common = "Germany",
                    NativeName = new Dictionary<string, NativeNameObject>() { {"deu", new NativeNameObject{ Official = "Bundesrepublik Deutschland",
                    Common = "Deutschland"} } } },
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
                    Name = new TheName{Official = "United States Of America", Common = "America"},
                    Area = 10000,
                    Population = 600000,
                    TopLevelDomain = new List<string> { ".com" },
                    Capital = new List<string> {"Vasington"},
                },
            };
            // Act
            var filterByCapitalCity = RestCountriesFilter.FilterEuropeanUnionCountriesByCapitalCity(countriesOneNotEU, _europeanUnionCapitals);
            // Assert
            filterByCapitalCity.Should().BeEquivalentTo(expectedResult);
        }

        [Fact]
        public void ReturnOneCountryWithOutName_TestFilter_ShouldReturnOneCountryWithOutItsName()
        {
            // Arrange
            var expectedResult = new CountryExceptName
            {
                Area = 1000,
                Population = 80000,
                TopLevelDomain = new List<string> { ".de" },
                Capital = new List<string> { "Berlin" },
                CommonNativeName = "Deutschland"
            };
            // Act
            var result = RestCountriesFilter.ReturnOneCountryWithOutName(_countries, "Germany");
            // Assert
            result.Should().BeEquivalentTo(expectedResult);
        }

        [Fact]
        public void ReturnOneCountryWithOutName_TestFilter_ShouldReturnOneNullIfCountryDoesNotExist()
        {
            // Act
            var resultNotCorrectName = RestCountriesFilter.ReturnOneCountryWithOutName(_countries, "Garmani");
            var resultCorrect = RestCountriesFilter.ReturnOneCountryWithOutName(_countries, "Germany");
            // Assert
            Assert.Null(resultNotCorrectName);
            Assert.NotNull(resultCorrect);
        }
    }
}