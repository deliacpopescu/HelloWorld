// <copyright file="HomeController.cs" company="Principal 33">
// Copyright (c) Principal 33. All rights reserved.
// </copyright>

using System.Collections.Generic;
using System.Diagnostics;
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
        private int index;
        public HomeController(ILogger<HomeController> logger, ITeamService teamService)
        {
            this.logger = logger;
            this.teamService = teamService;
            this.index = teamService.GetTeamInfo().TeamMembers.Count;
        }

        [HttpPost]
        public void AddTeamMember(string name)
        {
            this.index++;
            Member member = new Member(name, this.index);

            this.teamService.AddTeamMember(member);
        }
        [HttpPost]
        public void DeleteTeamMember(int id)
        {
            string name="";
            foreach(Member m in teamService.GetTeamInfo().TeamMembers)
            {
                if (m.Id == id)
                {
                    name = m.Name;
                    break;
                }
                Member member = new Member(name, id);
                this.teamService.DeleteTeamMember(member);
            }

           
        }

        [HttpGet]
        public int GetCount()
        {
            return teamService.GetTeamInfo().TeamMembers.Count;
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
