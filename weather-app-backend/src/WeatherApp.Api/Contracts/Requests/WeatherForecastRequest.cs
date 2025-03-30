using FastEndpoints;

namespace WeatherApp.Api.Contracts.Requests
{
    public class WeatherForecastRequest
    {
        [QueryParam]
        [BindFrom("city")]
        public string? City { get; set; }

        [QueryParam]
        [BindFrom("lat")]
        public string? Latitude { get; set; }

        [QueryParam]
        [BindFrom("lon")]
        public string? Longitude { get; set; }
    }
}
