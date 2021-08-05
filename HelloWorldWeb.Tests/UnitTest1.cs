using System;
using HelloWorldWebApp.Models;
using HelloWorldWebApp.Services;
using Xunit;

namespace HelloWorldWeb.Tests
{
    public class TeamServiceTest
    {
        [Fact]
        public void AddTeamMemberToTheTeam()
        {
            // Assume

            ITeamService teamService = new TeamService();

            // Act

            teamService.AddTeamMember(new Member("George",6));

            // Assert
            Assert.Equal(6, teamService.GetTeamInfo().TeamMembers.Count);

        }
    }
}