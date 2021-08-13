
namespace HelloWorldWebApp.Services
{
    public class WeatherService : IWeatherService
    {
        public const float KELVIN_CONST = 273.15F;
        public float KelvinToCelsiusConvert(float kelvinTemp)
        {
            float celsiusTemp = kelvinTemp - KELVIN_CONST;
            return celsiusTemp;
        }
    }
}
