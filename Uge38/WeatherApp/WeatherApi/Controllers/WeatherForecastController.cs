using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using WeatherLibrary;

namespace WeatherApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }
        [HttpGet(Name ="GetWeatherForecast")]
        public async Task<Root> Get()
        {
            HttpClient client = new HttpClient();
            using HttpResponseMessage response = await client.GetAsync("https://api.openweathermap.org/data/2.5/forecast?lat=55.0443&lon=9.4174&appid=fe5e02383d8389c0ed719c4281aa7994");

            response.EnsureSuccessStatusCode();

            var jsonResponse = await response.Content.ReadAsStringAsync();

            var weatherForecast =
               JsonSerializer.Deserialize<Root>(jsonResponse);
            

            return weatherForecast;
        }
        [HttpGet("{days}", Name = "GetWeatherForecastDays")]
        public async Task<Root> Get(int days)
        {
            HttpClient client = new HttpClient();
            using HttpResponseMessage response = await client.GetAsync("https://api.openweathermap.org/data/2.5/forecast?lat=55.0443&lon=9.4174&cnt="+(days*8)+"&appid=fe5e02383d8389c0ed719c4281aa7994");

            response.EnsureSuccessStatusCode();

            var jsonResponse = await response.Content.ReadAsStringAsync();

            var weatherForecast =
               JsonSerializer.Deserialize<Root>(jsonResponse);
            

            return weatherForecast;
        }
        [HttpGet("{unit}&{days}", Name = "GetWeatherForecastDaysAndUnits")]
        public async Task<Root> Get(int days, string unit)
        {
            string conn = "";
            if(days == 8)
            {
                conn = "https://api.openweathermap.org/data/2.5/forecast?lat=55.0443&lon=9.4174&appid=fe5e02383d8389c0ed719c4281aa7994&units=" + unit;
            }
            else
            {
                conn = "https://api.openweathermap.org/data/2.5/forecast?lat=55.0443&lon=9.4174&cnt=" + (days * 8) + "&appid=fe5e02383d8389c0ed719c4281aa7994&units=" + unit;
            }
            HttpClient client = new HttpClient();
            using HttpResponseMessage response = await client.GetAsync(conn);

            response.EnsureSuccessStatusCode();

            var jsonResponse = await response.Content.ReadAsStringAsync();

            var weatherForecast =
               JsonSerializer.Deserialize<Root>(jsonResponse);
            

            return weatherForecast;
        }
    }
}