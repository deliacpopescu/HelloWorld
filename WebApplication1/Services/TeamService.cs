using WebApplication1.Models;
using System.Collections.Generic;
using System.Linq;

namespace WebApplication1.Services
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
                    { new Member("Gabi", 1), new Member("Delia", 2), new Member("Rares", 3), new Member("Catalin", 4) }
            };
        }

        public TeamInfo GetTeamInfo()
        {
            return teamInfo;
        }

        public Member AddTeamMember(Member member)
        {
            int id = teamInfo.TeamMembers.Max(member => member.Id);
            member.Id = id + 1;
            teamInfo.TeamMembers.Add(member);
            return member;
        }

        public Member UpdateTeamMember(Member member)
        {
            // List<Member> teamMembers = teamInfo.TeamMembers.Select(r => { if (r.Id == member.Id) { r = member; }; return r; }).ToList();
            // teamInfo.TeamMembers = teamMembers;
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
