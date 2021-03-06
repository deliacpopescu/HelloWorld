using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelloWorldWebApp.Controllers
{
    public class  WeatherControllerSettings : IWeatherControllerSettings
    {
        public WeatherControllerSettings(IConfiguration conf)
        {
            ApiKey = conf["WeatherForecast:ApiKey"];
            Longitude = conf["WeatherForecast:Longitude"];
            Latitude = conf["WeatherForecast:Latitude"];
        }
        public string Longitude { get; set; }

        public string Latitude { get; set; }

        public string ApiKey { get; set; }
    }

}
