using HelloWorldWebApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace HelloWorldWeb.Tests
{
   public class StartupTests
    {
        [Fact]
        public void ConvertHerokuStringToAspNetString()
        {
            //Assume
            string herokuConnectionString = "postgres://ubbibounqkmcmr:b03780802704d1c14a5e2a44bfc55d52aeea4436d3f1b3f9fcc27f6fcde11bb8@ec2-52-208-221-89.eu-west-1.compute.amazonaws.com:5432/d21v7j75lkfavs";
            
            //Act
           
            string AspNetConnectionString = Startup.ConvertHerokuStringToAspNetString(herokuConnectionString);

            //Assert
            Assert.Equal("Host=ec2-52-208-221-89.eu-west-1.compute.amazonaws.com;Port=5432;Database=d21v7j75lkfavs;User Id=ubbibounqkmcmr;Password=b03780802704d1c14a5e2a44bfc55d52aeea4436d3f1b3f9fcc27f6fcde11bb8;Pooling=true;SSL Mode=Require;TrustServerCertificate=True", AspNetConnectionString);
        }
    }
}
