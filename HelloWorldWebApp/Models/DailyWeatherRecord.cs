using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelloWorldWebApp.Models
{
    public class DailyWeatherRecord
    {
        public DailyWeatherRecord(DateTime Day, float Temperature, WeatherType Type)
        {
            this.Day = Day;
            this.Temperature = Temperature;
            this.Type = Type;
        }

        public DateTime Day { get; set; }

        public float Temperature { get; set; }

        public WeatherType Type { get; set; }
    }
}

