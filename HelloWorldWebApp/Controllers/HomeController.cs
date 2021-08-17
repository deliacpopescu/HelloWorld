// <copyright file="HomeController.cs" company="Principal 33">
// Copyright (c) Principal 33. All rights reserved.
// </copyright>

using System.Diagnostics;
using System.Linq;
using HelloWorldWebApp.Models;
using HelloWorldWebApp.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace HelloWorldWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> logger;
        private readonly ITeamService teamService;

        public HomeController(ILogger<HomeController> logger, ITeamService teamService)
        {
            this.logger = logger;
            this.teamService = teamService;
        }

        [HttpGet]
        public int GetCount()
        {
            return this.teamService.GetTeamInfo().TeamMembers.Count;
        }

        [HttpPost]
        public int AddTeamMember(string name)
        {
            int id = this.teamService.AddTeamMember(name);
            return id;
        }


        [HttpPut]
        public Member UpdateTeamMember(int id, string name)
        {
            Member member = new Member(id, name);
            member = this.teamService.UpdateTeamMember(member);
            return member;
        }

        [HttpDelete]
        public void DeleteTeamMember(int id)
        {
            this.teamService.DeleteTeamMember(id);
        }

        public IActionResult Index()
        {
            return this.View(teamService.GetTeamInfo());
        }

        public IActionResult Privacy()
        {
            return this.View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return this.View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier });
        }
    }
}
