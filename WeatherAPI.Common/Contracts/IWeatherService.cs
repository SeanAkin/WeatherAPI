using WeatherAPI.Common.Models;

namespace WeatherAPI.Common.Contracts
{
    public interface IWeatherService
    {
        Task<WeatherResponseDTO?> GetForcastByLocation(string location);
    }
}
