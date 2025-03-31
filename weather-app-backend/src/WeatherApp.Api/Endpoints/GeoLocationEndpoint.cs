using FastEndpoints;
using WeatherApp.Api.Contracts.Requests;
using WeatherApp.Api.Contracts.Responses;
using WeatherApp.Api.Services;

namespace WeatherApp.Api.Endpoints
{
    public class GeoLocationEndpoint : Endpoint<GeoLocationRequest, GeoLocationResponse>
    {
        private readonly IGeoLocationService _geoLocationService;

        public GeoLocationEndpoint(IGeoLocationService geoLocationService)
        {
            _geoLocationService = geoLocationService;
        }

        public override void Configure()
        {
            Get("/api/geolocation");
            AllowAnonymous();
            DontCatchExceptions();
        }

        public override async Task HandleAsync(GeoLocationRequest req, CancellationToken ct)
        {
            var geoLocation = await _geoLocationService.FindCities(req.City);
            if (geoLocation is null) {
                await SendResultAsync(TypedResults.NotFound());
                return;
            }

            await SendAsync(geoLocation);
        }
    }
}
