using WebApplication1.Models;

namespace WebApplication1.Services
{
    public interface ITeamService
    {
        TeamInfo GetTeamInfo();

        Member AddTeamMember(Member member);

        Member UpdateTeamMember(Member member);

        void DeleteTeamMember(int id);
    }

}