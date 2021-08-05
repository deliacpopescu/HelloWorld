using HelloWorldWebApp.Models;

namespace HelloWorldWebApp.Services
{
    public interface ITeamService
    {
        void AddTeamMember(Member member);

        TeamInfo GetTeamInfo();

        void DeleteTeamMember(int id);

    }

}