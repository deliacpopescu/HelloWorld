using HelloWorldWebApp.Models;
using System.Collections.Generic;
using System.Linq;

namespace HelloWorldWebApp.Services
{
    public class TeamService : ITeamService
    {
        private readonly TeamInfo teamInfo;

        public TeamService()
        {
            teamInfo = new TeamInfo
            {
                TeamName = "name",
                TeamMembers = new List<Member>()
                    { new Member(1, "Gabi"), new Member(2, "delia"), new Member(3, "Rares"), new Member(4, "Catalin") }
            };
        }

        public TeamInfo GetTeamInfo()
        {
            return teamInfo;
        }

        public void AddTeamMember(Member member)
        {
            teamInfo.TeamMembers.Add(member);
        }

        public void DeleteTeamMember(int id)
        {
            Member itemToRemove = teamInfo.TeamMembers.Single(r => r.Id == id);
            teamInfo.TeamMembers.Remove(itemToRemove);
        }
    }
}
