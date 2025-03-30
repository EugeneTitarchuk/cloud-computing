using Microsoft.Extensions.Options;
using System.Text.Json;
using WeatherApp.Api.Contracts.Responses;
using WeatherApp.Api.Models;

namespace WeatherApp.Api.Services
{
    public interface IWeatherForecastService
    {
        Task<WeatherForecastResponse?> GetForecastAsync(string city);
        Task<WeatherForecastResponse?> GetForecastAsync(string? lat, string? lon);
    }

    public class WeatherForecastService : IWeatherForecastService
    {
        private readonly IOptions<ApplicationOptions> _options;

        public WeatherForecastService(IOptions<ApplicationOptions> options)
        {
            _options = options;
        }

        public async Task<WeatherForecastResponse?> GetForecastAsync(string city)
        {
            var weatherApiOptions = _options.Value.PublicApi.OpenWeather;

            using var client = new HttpClient();
            client.BaseAddress = new Uri(weatherApiOptions.BaseUrl);

            var response = await client.GetAsync($"?q={city}&units=metric&APPID={weatherApiOptions.ApiKey}");
            response.EnsureSuccessStatusCode();

            var responseContent = await response.Content.ReadAsStreamAsync();

            var forecast = await JsonSerializer.DeserializeAsync<WeatherForecastResponse>(responseContent);

            return forecast;
        }

        public async Task<WeatherForecastResponse?> GetForecastAsync(string? lat, string? lon)
        {
            var weatherApiOptions = _options.Value.PublicApi.OpenWeather;

            using var client = new HttpClient();
            client.BaseAddress = new Uri(weatherApiOptions.BaseUrl);

            var response = await client.GetAsync($"?lat={lat}&lon={lon}&units=metric&APPID={weatherApiOptions.ApiKey}");
            response.EnsureSuccessStatusCode();

            var responseContent = await response.Content.ReadAsStreamAsync();

            var forecast = await JsonSerializer.DeserializeAsync<WeatherForecastResponse>(responseContent);

            return forecast;
        }
    }
}
