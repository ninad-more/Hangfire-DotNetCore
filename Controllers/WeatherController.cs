using Microsoft.AspNetCore.Mvc;
using weather_api.Interfaces;

namespace weather_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherController : Controller
    {
        public IWeatherService _weatherService { get; set; }

        public WeatherController(IWeatherService weatherService) { 
           _weatherService= weatherService;
        }

        [HttpGet(Name = "GetCurrentTemparature")]
        public IActionResult Index()
        {
            int temparature = _weatherService.GetTemparature();
            return Json(temparature);
        }
    }
}
