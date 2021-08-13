using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelloWorldWebApp.Controllers
{
    
        public interface IWeatherControllerSettings
        {
            string Longitude { get; }
            string Latitude { get; }
            string ApiKey { get; }
        }
    
}
