using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using WeatherAPI.Common.Contracts;
using WeatherAPI.Common.Models;

namespace WeatherAPI.Test.Integration_Tests
{
    internal class WeatherTests : TestBase
    {
        [Test]
        public async Task GetWeatherByLocation()
        {
            // Arrange
            var getUrl = "api/WeatherForecast/GetByLocation?location=London";
            var scope = _application.Services.CreateScope();
            var weatherService = scope.ServiceProvider.GetRequiredService<IWeatherService>();
            var serviceDto = await weatherService.GetForcastByLocation("London");

            // Act
            var response = await _weatherApiClient.GetAsync(getUrl);
            var responseString = await response.Content.ReadAsStringAsync();
            var responseDto = JsonConvert.DeserializeObject<WeatherResponseDTO>(responseString);

            // Assert
            responseDto.Should().BeEquivalentTo(serviceDto);
        }
    }
}
