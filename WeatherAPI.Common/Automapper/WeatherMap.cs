using AutoMapper;
using WeatherAPI.Common.Extensions;
using WeatherAPI.Common.Models;

namespace WeatherAPI.Common.Automapper
{
    public class WeatherMap : Profile
    {
        public WeatherMap()
        {
            CreateMap<OpenWeatherAPIModel, WeatherResponseDTO>()
                .ForMember(dest => dest.Location, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.MaxTemp, opt => opt.MapFrom(src => Math.Round(src.Main.TempMax - 273.15, 2)))
                .ForMember(dest => dest.MinTemp, opt => opt.MapFrom(src => Math.Round(src.Main.TempMin - 273.15, 2)))
                .ForMember(dest => dest.Temperature, opt => opt.MapFrom(src => Math.Round(src.Main.Temp - 273.15, 2)))
                .ForMember(dest => dest.Pressure, opt => opt.MapFrom(src => src.Main.Pressure))
                .ForMember(dest => dest.Humidity, opt => opt.MapFrom(src => src.Main.Humidity))
                .ForMember(dest => dest.Sunrise, opt => opt.MapFrom(src => src.Sys.Sunrise.ConverToDateTimeString()))
                .ForMember(dest => dest.Sunset, opt => opt.MapFrom(src => src.Sys.Sunset.ConverToDateTimeString()));
        }
    }
}
