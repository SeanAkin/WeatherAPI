using AutoMapper;
using Microsoft.Extensions.Configuration;
using System.Net.Http;
using WeatherAPI.Common.Contracts;
using WeatherAPI.Common.Models;

namespace WeatherAPI.Business.Services
{
    public class WeatherService : IWeatherService
    {
        private readonly HttpClient _weatherClient;
        private readonly IConfiguration _config;
        private readonly IMapper _mapper;
        public WeatherService(IHttpClientFactory httpClientFactory, IConfiguration config, IMapper mapper)
        {
            _weatherClient = httpClientFactory.CreateClient("WeatherAPI");
            _config = config;
            _mapper = mapper;
        }
        public async Task<WeatherResponseDTO?> GetForcastByLocation(string location)
        {
            var requestURL = $"/data/2.5/weather?q={location}&appid={_config["Keys:OpenWeatherAPI"]}";
            var response = await _weatherClient.GetAsync(requestURL);
            if (response.IsSuccessStatusCode)
            {
                var responseString = await response.Content.ReadAsStringAsync();
                var deserialized = Newtonsoft.Json.JsonConvert.DeserializeObject<OpenWeatherAPIModel>(responseString);
                return _mapper.Map<WeatherResponseDTO>(deserialized);
            }

            return null;
        }
    }
}
