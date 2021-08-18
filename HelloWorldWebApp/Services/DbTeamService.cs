using HelloWorldWebApp.Data;
using HelloWorldWebApp.Models;
using System.Linq;

namespace HelloWorldWebApp.Services
{
    public class DbTeamService : ITeamService
    {
        private readonly ApplicationDbContext _context;
        public DbTeamService(ApplicationDbContext context)
        {
            _context = context;
        }

        public TeamInfo GetTeamInfo()
        {
            TeamInfo teamInfo = new TeamInfo();
            teamInfo.TeamName = "Sara";
            teamInfo.TeamMembers = _context.Members.ToList();
            return teamInfo;
        }

        public int AddTeamMember(Member member)
        {
            int id = _context.Members.Max(member => member.Id) + 1;
            member.Id = id;
            _context.Add(member);
            _context.SaveChanges();
            return member.Id;
        }

        public Member UpdateTeamMember(Member member)
        {
            _context.Members.Update(member);
            _context.SaveChanges();
            return member;
        }

        public void DeleteTeamMember(int id)
        {

            Member member = _context.Members.Find(id);
            _context.Members.Remove(member);
            _context.SaveChanges();
        }
    }
}
