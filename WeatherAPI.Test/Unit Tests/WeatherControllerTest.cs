using Bogus;
using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using WeatherAPI.Common.Contracts;
using WeatherAPI.Common.Models;
using WeatherAPI.Controllers;

namespace WeatherAPI.Test
{
    public class WeatherControllerTest
    {
        [Test]
        public async Task GetByLocationShouldCallService()
        {
            //Arrange
            string location = "London";
            var weatherResponse = new Faker<WeatherResponseDTO>()
                .RuleFor(x => x.Location, location)
                .Generate();

            var mock = new Mock<IWeatherService>();
            mock.Setup(x => x.GetForcastByLocation(location))
                .Returns(Task.FromResult(weatherResponse));

            var controller = new WeatherForecastController(null, mock.Object);

            //Act
            var result = controller.GetByLocation(location);
            var actual = (result.Result as OkObjectResult).Value as WeatherResponseDTO;

            // Fluent Assert
            actual.Should().Be(weatherResponse);
        }
    }
}