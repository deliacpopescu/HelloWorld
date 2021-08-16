using HelloWorldWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HelloWorldWebApp.Controllers
{
    /// <summary>
    /// fetch data from weather API. https://openweathermap.org/api
    /// <see href="https://github.com">GitHub</see>
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class WeatherController : ControllerBase
    {
        private readonly string longitude = "23.5800";
        private readonly string latitude = "46.7700";
        private readonly string apiKey = "c39de899f75ef4e85f748679a0126376";

        public WeatherController(IWeatherControllerSettings conf)
        {
            longitude = conf.Longitude;
            latitude = conf.Latitude;
            apiKey = conf.ApiKey;
        }

        // GET: api/<WeatherController>
        [HttpGet]
        public IEnumerable<DailyWeatherRecord> Get()
        {
            //lat 46.7700 lon 23.5800
            // https://api.openweathermap.org/data/2.5/onecall?lat=46.7700&lon=23.5800&exclude=hourly,minutely&appid=14cd0691c3f83a08af36b95d6c3cff18
            var client = new RestClient($"https://api.openweathermap.org/data/2.5/onecall?lat={latitude}&lon={longitude}&exclude=hourly,minutely&appid={apiKey}");
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);
            return ConvertResponseToWeatherRecordList(response.Content);

           
        }
        [NonAction]
        public IEnumerable<DailyWeatherRecord> ConvertResponseToWeatherRecordList(string content)
        {
            var json = JObject.Parse(content);

            //List<DailyWeatherRecord> result = new List<DailyWeatherRecord>();

            var jsonArray = json["daily"].Take(7);
            return jsonArray.Select(CreateDailyWeatherRecordFromJToken);
        }

        private DailyWeatherRecord CreateDailyWeatherRecordFromJToken(JToken item)
        {
            long unixDateTime = item.Value<long>("dt");
            var day = DateTimeOffset.FromUnixTimeSeconds(unixDateTime).DateTime.Date;
            float temperature = item.SelectToken("temp").Value<float>("day");
            string weather = item.SelectToken("weather")[0].Value<string>("description");
            var type = Convert(weather);

            DailyWeatherRecord dailyWeatherRecord = new DailyWeatherRecord(day, temperature, type);
            return dailyWeatherRecord;
        }

        private WeatherType Convert(string weather)
        {
            switch (weather)
            {
                case "few clouds":
                        return WeatherType.FewClouds;
                case "light rain":
                    return WeatherType.LightRain;
                case "broken clouds":
                    return WeatherType.BrokenClouds;

                case "scattered clouds":
                    return WeatherType.ScatteredClouds;

                case "overcast clauds":
                    return WeatherType.OvercastClauds;

                default:
                    throw new Exception($"Unknown weather type {weather}+description");
            }
        }

        // GET api/<WeatherController>/5
        [HttpGet("{index}")]
        
        /// <summary>
        /// Get a weather forecast for the day in specified amount of days from now.
        /// </summary>
        /// <param name="index">amount of days from now (from 0 to 7).</param>
        /// <returns>The weather forecast.</returns>
        
        public string Get(int index)
        {
            return "value";
        }

      
    }
}
