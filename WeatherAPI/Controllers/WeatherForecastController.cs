using Microsoft.AspNetCore.Mvc;
using WeatherAPI.Common.Contracts;
using WeatherAPI.Common.Models;

namespace WeatherAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IWeatherService _weatherService;
        public WeatherForecastController(ILogger<WeatherForecastController> logger, IWeatherService weatherService)
        {
            _logger = logger;
            _weatherService = weatherService;
        }

        [HttpGet("GetByLocation")]
        public async Task<IActionResult> GetByLocation(string location)
        {
            var result = await _weatherService.GetForcastByLocation(location);
            return Ok(result);
        }
    }
}