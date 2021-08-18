using HelloWorldWebApp.Models;
using System;

namespace HelloWorldWebApp.Services
{
    public interface ITeamService
    {
        TeamInfo GetTeamInfo();

        int AddTeamMember(Member member);

        Member UpdateTeamMember(Member member);

        void DeleteTeamMember(int id);
    }

}