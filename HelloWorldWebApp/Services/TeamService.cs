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
                    { new Member(1, "Gabi"), new Member(2, "Delia"), new Member(3, "Rares"), new Member(4, "Catalin") }
            };
        }

        public TeamInfo GetTeamInfo()
        {
            return teamInfo;
        }

        public int AddTeamMember(Member member)
        {
            int id = teamInfo.TeamMembers.Max(member => member.Id) + 1;
            member.Id = id;
            teamInfo.TeamMembers.Add(member);
            return id;
        }

        public Member UpdateTeamMember(Member member)
        {
            teamInfo.TeamMembers.ForEach(r => { if (r.Id == member.Id) { r.Name = member.Name; }; });
            return member;
        }

        public void DeleteTeamMember(int id)
        {
            Member member = teamInfo.TeamMembers.Single(r => r.Id == id);
            teamInfo.TeamMembers.Remove(member);
        }
    }
}
