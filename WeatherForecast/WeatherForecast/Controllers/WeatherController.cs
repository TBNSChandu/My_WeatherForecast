using Microsoft.AspNetCore.Mvc;
using WeatherForecast.Models;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json; 


namespace WeatherForecast.Controllers
{
    public class WeatherController : Controller
    {
        private readonly WeatherService _weatherService;

        // Replace "YOUR_API_KEY" with your actual OpenWeatherMap API key
        private static readonly string apiKey = "d32a0c0d385a803ce83cd16b47bfe7b9";

        public WeatherController()
        {
            _weatherService = new WeatherService(apiKey);
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(string city)
        {
            if (string.IsNullOrEmpty(city))
                return View();

            Weather weather = await _weatherService.GetWeatherData(city);
            return View(weather);
        }
    }
}
