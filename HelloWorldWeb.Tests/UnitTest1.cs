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

            teamService.AddTeamMember(new Member(5, "George"));

            // Assert

            Assert.Equal(5, teamService.GetTeamInfo().TeamMembers.Count);

        }

        [Fact]
        public void DeleteTeamMemberToTheTeam()
        {
            // Assume

            ITeamService teamService = new TeamService();
            int count = teamService.GetTeamInfo().TeamMembers.Count;

            // Act

            teamService.DeleteTeamMember(2);

            // Assert

            Assert.False(teamService.GetTeamInfo().TeamMembers.Exists(r => r.Id == 2));
            Assert.Equal(count - 1 , teamService.GetTeamInfo().TeamMembers.Count);

        }
    }
}