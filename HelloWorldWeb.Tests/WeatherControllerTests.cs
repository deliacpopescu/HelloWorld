using HelloWorldWebApp.Controllers;
using HelloWorldWebApp.Models;
using HelloWorldWebApp.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace HelloWorldWeb.Tests
{
    public class WeatherControllerTests
    {
        private IWeatherService weatherService;
        private Mock<IWeatherControllerSettings> weatherMock;

        private void InitializeWeatherService()
        {
            weatherService = new WeatherService();
        }
        private void InitializeTWeatherServiceMock()
        {
            weatherMock = new Mock<IWeatherControllerSettings>();
            weatherMock.Setup(_ => _.Latitude).Returns(" ");
            weatherMock.Setup(_ => _.Longitude).Returns(" ");
            weatherMock.Setup(_ => _.ApiKey).Returns(" ");
        }

        [Fact]
        public void TestMethodConversion()
        {
            InitializeTWeatherServiceMock();
            //Assume
            this.weatherMock = new Mock<IWeatherControllerSettings>();
            string content = this.LoadJsonFromResource();
            WeatherController weatherController = new WeatherController(this.weatherMock.Object);
           
            //Act
            var result = weatherController.ConvertResponseToWeatherRecordList(content);
              
            //Assert
            Assert.Equal(7, result.Count());
            var firstDay = result.First();
            Assert.Equal(new DateTime(2021, 8, 13), firstDay.Day);
            Assert.Equal(297.21F, firstDay.Temperature);
            Assert.Equal(WeatherType.ScatteredClouds, firstDay.Type);
        }

        private string LoadJsonFromResource()
        {
            {
                var assembly = this.GetType().Assembly;
                var assemblyName = assembly.GetName().Name;
                var resourseName = $"{assemblyName}.TestData.ContentWeatherApi.json";

                var resourceStream = assembly.GetManifestResourceStream(resourseName);
                using (var tr = new StreamReader(resourceStream))
                {
                    return tr.ReadToEnd();
                }
            }
        }
          
            [Fact]
             public void KelvinToCelsiusConversion()
        {
            //Assume
            InitializeWeatherService();
            float kelvinTemp = 298.15F;
            float expectedTemp = 25F;

            //Act

            float actualTemp = weatherService.KelvinToCelsiusConvert(kelvinTemp);

            //Assert
            Assert.Equal(actualTemp, expectedTemp);

        }
    }
}
