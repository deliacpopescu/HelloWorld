using HelloWorldWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelloWorldWebApp.Services
{
    public class TeamService : ITeamService
    {
        private readonly TeamInfo teamInfo;

        public TeamService()
        {
            this.teamInfo = new TeamInfo
            {
                Name = "Team 2",
                TeamMembers = new List<string>(new string[]
               {
                    "Gabi",
                    "Delia",
                    "Sorina",
                    "Rares",
                    "Catalin",
               }),
            };
        }

        public TeamInfo GetTeamInfo()
        {
            return teamInfo;
        }

        public void AddTeamMember(string teamMemberName)
        {
            teamInfo.TeamMembers.Add(teamMemberName);
        }
    }
}
