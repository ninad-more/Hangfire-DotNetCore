using weather_api.Interfaces;

namespace weather_api.Services
{
    public class WeatherService : IWeatherService
    {
        public int GetTemparature()
        {
            Random rand = new();
            int temparature = rand.Next(30, 50);

            return temparature;
        }
    }
}
