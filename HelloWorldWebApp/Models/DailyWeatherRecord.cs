using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelloWorldWebApp.Models
{
    public class DailyWeatherRecord
    {
        
        public DailyWeatherRecord(DateTime day, float temperature, WeatherType type)
        {
            this.Day = day;
            this.Temperature = temperature;
            this.Type = type;
        }

        public DateTime Day { get; set; }

        public float Temperature { get; set; }

        public WeatherType Type { get; set; }
    }
}

