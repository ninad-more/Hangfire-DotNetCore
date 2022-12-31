namespace weather_api.Models
{
    public class WeatherDataModel
    {
        public int Temparature { get; set; } = 0;
        public DateTime Date { get; set; } = DateTime.Now;
    }
}
