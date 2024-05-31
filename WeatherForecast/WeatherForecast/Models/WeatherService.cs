using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
namespace WeatherForecast.Models
{
    public class WeatherService
    {
        private readonly string _apiKey;
        public WeatherService(string apiKey)
        {
            _apiKey = apiKey;
            
        }
        public async Task<Weather> GetWeatherData(string city)
        {
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync($"http://api.openweathermap.org/data/2.5/weather?q={city}&appid={_apiKey}&units=metric");
                if (response.IsSuccessStatusCode)
                {
                    string data = await response.Content.ReadAsStringAsync();
                    dynamic result = JsonConvert.DeserializeObject(data);
                    Weather weather = new Weather
                    {
                        City = result.name,
                        Description = result.weather[0].description,
                        Temperature = result.main.temp,
                        Humidity = result.main.humidity,
                        WindSpeed = result.wind.speed
                    };
                    return weather;
                }
                return null;
            }
        }
    }
  }

