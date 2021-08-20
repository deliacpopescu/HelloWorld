using HelloWorldWebApp.Models;
using Microsoft.AspNetCore.SignalR;
using System.Collections.Generic;
using System.Linq;

namespace HelloWorldWebApp.Services
{
    public class TeamService : ITeamService
    {
        private readonly TeamInfo teamInfo;
        private readonly TimeService timeService;
        private readonly IHubContext<MessageHub> messageHub;

        public TeamService(IHubContext<MessageHub> messageHubContext)
        {
            teamInfo = new TeamInfo
            {
                TeamName = "name",
                TeamMembers = new List<Member>()
                { new Member(1, "Gabi", timeService),
                    new Member(2, "Delia", timeService),
                    new Member(3, "Rares", timeService),
                    new Member(4, "Catalin", timeService)
                }
           
            };
            this.messageHub = messageHubContext;
        }


        public TeamInfo GetTeamInfo()
        {
            return teamInfo;
        }

        public Member AddTeamMember(Member member)
        {
            int id = teamInfo.TeamMembers.Max(member => member.Id)+ 1 ;
            member.Id = id ;
            teamInfo.TeamMembers.Add(member);
            messageHub.Clients.All.SendAsync("NewTeamMemberAdded", member);
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
