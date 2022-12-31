using Hangfire;
using Microsoft.AspNetCore.Mvc;
using weather_api.Interfaces;
using weather_api.Models;

namespace weather_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WeatherController : Controller
    {
        private readonly IWeatherService _weatherService;
        private readonly INotificationService _notificationService;
        private readonly IBackgroundJobClient _backgroundJobClient;
        private readonly IRecurringJobManager _recurringJobManager;

        public WeatherController(IWeatherService weatherService, 
            INotificationService notificationService, 
            IBackgroundJobClient backgroundJobClient, 
            IRecurringJobManager recurringJobManager)
        {
            _weatherService = weatherService;
            _notificationService = notificationService;
            _backgroundJobClient = backgroundJobClient;
            _recurringJobManager= recurringJobManager;
        }

        [HttpGet("/NotifyCurrentTemparature")]
        public IActionResult GetCurrentTemparature()
        {
            WeatherDataModel model = new()
            {
                Temparature = _weatherService.GetTemparature(),
                Date = DateTime.Now
            };
            _backgroundJobClient.Enqueue(() => _notificationService.Notify());

            return Ok(model);
        }

        [HttpGet("/NotifyTemparatureEveryMinute")]
        public IActionResult GetTemparatureByMinute()
        {
            _recurringJobManager.AddOrUpdate("Job: Notify after a minute", () => _notificationService.Notify(), Cron.Minutely);
            
            return Ok();
        }
    }
}
