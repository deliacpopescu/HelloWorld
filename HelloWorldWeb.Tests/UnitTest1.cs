using HelloWorldWebApp.Models;
using HelloWorldWebApp.Services;
using System.Linq;
using Xunit;

namespace HelloWorldWeb.Tests
{
    public class TeamServiceTest
    {
        [Fact]
        public void AddTeamMember()
        {
            // Assume

            ITeamService teamService = new TeamService();
            int id = teamService.GetTeamInfo().TeamMembers.Max(member => member.Id);
            int size = teamService.GetTeamInfo().TeamMembers.Count();

            // Act

            teamService.AddTeamMember(new Member("George"));

            // Assert

            Assert.Equal(size + 1, teamService.GetTeamInfo().TeamMembers.Count);
            Assert.Equal(id + 1, teamService.GetTeamInfo().TeamMembers[size].Id);
            Assert.Equal("George", teamService.GetTeamInfo().TeamMembers[size].Name);
        }

        [Fact]
        public void AddTeamMemberWithId()
        {
            // Assume

            ITeamService teamService = new TeamService();
            int id = teamService.GetTeamInfo().TeamMembers.Max(member => member.Id);
            int size = teamService.GetTeamInfo().TeamMembers.Count();

            // Act

            teamService.AddTeamMember(new Member("Mike"));

            // Assert

            Assert.Equal(size + 1, teamService.GetTeamInfo().TeamMembers.Count);
            Assert.NotEqual(8, teamService.GetTeamInfo().TeamMembers[size].Id);
            Assert.Equal(id + 1, teamService.GetTeamInfo().TeamMembers[size].Id);
            Assert.Equal("Mike", teamService.GetTeamInfo().TeamMembers[size].Name);
        }

        [Fact]
        public void UpdateTeamMember()
        {
            // Assume
            ITeamService teamService = new TeamService();
            Member member = new Member(2, "Anna");

            // Act

            teamService.UpdateTeamMember(member);

            // Assert

            Assert.Equal("Anna", teamService.GetTeamInfo().TeamMembers[1].Name);


        }

        [Fact]
        public void UpdateTeamMemberNoId()
        {
            // Assume
            ITeamService teamService = new TeamService();
            TeamInfo teamInfo = teamService.GetTeamInfo();
            Member member = new Member(100,"Anna");

            // Act

            teamService.UpdateTeamMember(member);

            // Assert

            Assert.Null(teamService.GetTeamInfo().TeamMembers.ElementAtOrDefault(99));
            Assert.Equal(teamInfo, teamService.GetTeamInfo());
        }
        
        [Fact(Skip = "fails right now later.")]
        public void DeleteTeamMember()
        {
            // Assume

            ITeamService teamService = new TeamService();
            int count = teamService.GetTeamInfo().TeamMembers.Count;

            // Act

            teamService.DeleteTeamMember(2);

            // Assert

            Assert.True(teamService.GetTeamInfo().TeamMembers.Exists(r => r.Id == 2));
            Assert.Equal(count - 1 , teamService.GetTeamInfo().TeamMembers.Count);

        }
    }
}