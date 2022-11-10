using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Text.Json;
using WeatherView.Models;
using WeatherLibrary;

namespace WeatherView.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> Index(string sortOrder, string daysString, string units)
        {
            ViewData["PoPSortParm"] = String.IsNullOrEmpty(sortOrder) ? "pop_desc" : "";
            //ViewData["unitParm"] = String.IsNullOrEmpty(units) ? "unit" : "";

            string conn = "https://localhost:7299/WeatherForecast/";
            if (!String.IsNullOrEmpty(units))
            {
                if (units == "metric")
                {
                    conn += "metric";
                }
                else if (units == "imperial")
                {
                    conn += "imperial";
                }
            }

            int days = 0;
            HttpClient client = new HttpClient();

            if (int.TryParse(daysString, out days)){
                if (!string.IsNullOrEmpty(units))
                {
                    conn += "&";
                }
                conn += daysString;
            }
            else
            {
                if (!string.IsNullOrEmpty(units))
                {
                    conn += "&8";
                }
            }
            using HttpResponseMessage response = await client.GetAsync(conn);

            response.EnsureSuccessStatusCode();

            var jsonResponse = await response.Content.ReadAsStringAsync();

            var weatherForecast =
               JsonSerializer.Deserialize<Root>(jsonResponse);
            switch (sortOrder)
            {
                case "pop_desc":
                    weatherForecast.list = weatherForecast.list.OrderByDescending(l => l.pop).ToList();
                    break;
                default:
                    weatherForecast.list = weatherForecast.list.OrderBy(l => l.dt).ToList();
                    break;
            }
            return View(weatherForecast);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}