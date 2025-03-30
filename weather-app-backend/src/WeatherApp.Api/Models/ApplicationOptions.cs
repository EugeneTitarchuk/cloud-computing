namespace WeatherApp.Api.Models
{
    public class ApplicationOptions
    {
        public PublicApiOptions PublicApi {  get; set; } = new PublicApiOptions();
    }

    public class PublicApiOptions
    {
        public ApiData OpenWeather { get; set; } = new ApiData();

        public ApiData GeoDb { get; set; } = new ApiData();
    }

    public class ApiData
    {
        public string BaseUrl { get; set; } = "";

        public string ApiKey { get; set; } = "";
    }
}
