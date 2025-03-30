using FastEndpoints;

namespace WeatherApp.Api.Contracts.Requests
{
    public class GeoLocationRequest
    {
        [QueryParam]
        [BindFrom("city")]
        public string? City { get; set; }
    }
}
