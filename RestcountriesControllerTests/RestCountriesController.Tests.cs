using dot_net_restcountries_api.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Moq.AutoMock;
using Restcountries.Integration;

namespace RestcountriesController.Tests
{
    [TestClass]
    public class RestCountriesControllerTests
    {
        private AutoMocker _mocker;
        private Mock<IGetRestCountries> _restCountriesMock;
        private RestCountriesController _controller;

        [TestInitialize]
        public void Setup()
        {
            _mocker = new AutoMocker();
            _restCountriesMock = _mocker.GetMock<IGetRestCountries>();
            _controller = new RestCountriesController(_restCountriesMock.Object);
        }


        [TestMethod]
        public void GetTopTenByPopulationInEurope_TestControllerAbilityToGetResult_ResultIsNotNull()
        {
            // Act
            var result = _controller.GetTopTenByPopulationInEurope();
            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public async Task GetTopTenByPopulationInEurope_GetCountries_ReturnsOkObjectResult()
        {
            // Act
            var actionResult = await _controller.GetTopTenByPopulationInEurope();
            // Assert
            Assert.IsInstanceOfType(actionResult, typeof(OkObjectResult));
        }

        [TestMethod]
        public async Task GetTopTenByPopulationDensityInEurope_GetCountries_ReturnsOkObjectResult()
        {
            // Act
            var actionResult = await _controller.GetTopTenByPopulationDensityInEurope();
            // Assert
            Assert.IsInstanceOfType(actionResult, typeof(OkObjectResult));
        }

        [TestMethod]
        public async Task GetOneCountryByName_GetCountry_ReturnsOkObjectResult()
        {
            // Act
            var actionResult = await _controller.GetOneCountryByName("Latvia");
            // Assert
            Assert.IsNotNull(actionResult);
        }
    }
}