using System.Text.Json.Serialization;

namespace WeatherApp.Api.Contracts.Responses
{
    public class GeoLocationResponse
    {
        [JsonPropertyName("data")]
        public GeoLocationResponseData[]? Data { get; set; }
    }

    public class GeoLocationResponseData
    {
        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [JsonPropertyName("country")]
        public string? Country { get; set; }

        [JsonPropertyName("region")]
        public string? Region { get; set; }

        [JsonPropertyName("type")]
        public string? Type { get; set; }
    }
}
