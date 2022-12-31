using weather_api.Interfaces;

namespace weather_api.Services
{
    public class NotificationService : INotificationService
    {
        IWeatherService _weatherService;
        public NotificationService(IWeatherService weatherService)
        {
            _weatherService = weatherService;
        }

        public void Notify()
        {
            Console.WriteLine($"Date -> {DateTime.Now} || Temparature (Celsius) -> {_weatherService.GetTemparature()}");
        }
    }
}
