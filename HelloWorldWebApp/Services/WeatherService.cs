
namespace HelloWorldWebApp.Services
{
    public class WeatherService : IWeatherService
    {
        public float KelvinToCelsiusConvert(float kelvinTemp)
        {
            float celsiusTemp = kelvinTemp - 273.15F;
            return celsiusTemp;
        }
    }
}
