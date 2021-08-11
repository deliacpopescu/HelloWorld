using HelloWorldWebApp.Models;
using HelloWorldWebApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace HelloWorldWeb.Tests
{
    public class TeamMemberTests
    {
        private ITimeService timeService;

        public TeamMemberTests()
        {
            timeService = new FakeTimeService();
        }

        [Fact]
        public void GettingAge()
        {
            // Assume
            var newTeamMember = new Member("Delia", timeService);
            newTeamMember.Birthdate = new DateTime(1990, 09, 30);

            // Act

            int age = newTeamMember.GetAge(); 

            // Assert

        
            Assert.Equal(30,age);

        }
    }

    internal class FakeTimeService : ITimeService
    {
        public DateTime Now()
        {
            return new DateTime(2021, 8, 11);
        }
    }
}
