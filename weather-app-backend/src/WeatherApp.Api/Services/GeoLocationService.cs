using Microsoft.Extensions.Options;
using System.Text.Json;
using WeatherApp.Api.Contracts.Responses;
using WeatherApp.Api.Models;

namespace WeatherApp.Api.Services
{
    public interface IGeoLocationService
    {
        Task<GeoLocationResponse> FindCities(string namePrefix);
    }

    public class GeoLocationService : IGeoLocationService
    {
        private readonly IOptions<ApplicationOptions> _options;

        public GeoLocationService(IOptions<ApplicationOptions> options) 
        {
            _options = options;
        }

        public async Task<GeoLocationResponse> FindCities(string namePrefix)
        {
            var options = _options.Value.PublicApi.GeoDb;

            using var client = new HttpClient();
            client.BaseAddress = new Uri(options.BaseUrl);

            var query = $"?namePrefix={namePrefix}&minPopulation=100000&types=CITY&limit=5&offset=0";
            var response = await client.GetAsync(query);
            response.EnsureSuccessStatusCode();

            var responseContent = await response.Content.ReadAsStreamAsync();

            var location = await JsonSerializer.DeserializeAsync<GeoLocationResponse>(responseContent);

            return location;
        }
    }
}
