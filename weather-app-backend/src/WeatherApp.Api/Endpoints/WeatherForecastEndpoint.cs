using FastEndpoints;
using WeatherApp.Api.Contracts.Requests;
using WeatherApp.Api.Contracts.Responses;
using WeatherApp.Api.Services;

namespace WeatherApp.Api.Endpoints
{
    public class WeatherForecastEndpoint : Endpoint<WeatherForecastRequest, WeatherForecastResponse>
    {
        private readonly IWeatherForecastService _weatherForecastService;

        public WeatherForecastEndpoint(IWeatherForecastService weatherForecastService)
        {
            _weatherForecastService = weatherForecastService;
        }

        public override void Configure()
        {
            Get("/api/weatherforecast");
            AllowAnonymous();
            DontCatchExceptions();
        }

        public override async Task HandleAsync(WeatherForecastRequest req, CancellationToken ct)
        {
            var weatherForecast = req.City is not null ?
                await _weatherForecastService.GetForecastAsync(req.City) :
                await _weatherForecastService.GetForecastAsync(req.Latitude, req.Longitude);

            if (weatherForecast is null) {
                await SendResultAsync(TypedResults.NotFound());
                return;
            }

            await SendAsync(weatherForecast);
        }
    }
}
