namespace WeatherAPI.Common.Models
{
    public record WeatherResponseDTO
    {
        public string Location { get; init; }
        public double MaxTemp { get; init; }
        public double MinTemp { get; init; }
        public double Temperature { get; init; }
        public long Pressure { get; init; }
        public long Humidity { get; init; }
        public string Sunrise { get; init; }
        public string Sunset { get; init; }
    }
}
