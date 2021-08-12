﻿using HelloWorldWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HelloWorldWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeatherController : ControllerBase
    {
        private readonly object latitude = "46.7700";
        private readonly object longitude = "23.5800";
        private readonly object apiKey = "14cd0691c3f83a08af36b95d6c3cff18";


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
            return ConvertResponseToWeatherForecastList(response.Content);

           
        }

        private IEnumerable<DailyWeatherRecord> ConvertResponseToWeatherForecastList(string content)
        {
            return new DailyWeatherRecord[] {
                new DailyWeatherRecord(new DateTime(2021, 8, 08), 22.0F, WeatherType.Mild),
                new DailyWeatherRecord(new DateTime(2021, 8, 08), 22.0F, WeatherType.Mild),
                    };
        }

        // GET api/<WeatherController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

      
    }
}
