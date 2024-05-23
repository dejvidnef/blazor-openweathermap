namespace BlazorApp1.Services

{
    using BlazorApp1.Shared;
    using System.Net.Http;
    using System.Net.Http.Json;
    using System.Runtime.InteropServices;
    using System.Security.Principal;
    using System.Threading.Tasks;
    public class WeatherService
    {
        private readonly HttpClient _httpClient;
        private const string ApiKey = "27d70a8ce5c8c5c271a498277e332f44";
        private const string BaseUrl = "https://api.openweathermap.org/data/2.5/weather";

        public WeatherService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<WeatherResponse> GetWeatherAsync(string city)
        {
            var url = $"{BaseUrl}?q={city}&appid={ApiKey}&units=metric";
            return await
                _httpClient.GetFromJsonAsync<WeatherResponse>(url);
        }
    }
        public class WeatherResponse
        {
            public Main Main { get; set; }
            public Weather[] Weather { get; set; }
            public Wind Wind { get; set; }

        }
        public class Main
        {
            public float Temp { get; set; }
            public int Humidity { get; set; }
        }
        public class Wind
        {
            public float Speed { get; set; }
        }
        public class Weather
        {
            public string Description { get; set; }
        }
    }
