// <copyright file="TeamInfo.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using System.Collections.Generic;

namespace WebApplication1.Models
{
    public class TeamInfo
    {
        // private string teamName;
        // private List<Member> teamMembers;
        public string TeamName { get; set; }

        public List<Member> TeamMembers { get; set; }
    }
}

// "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=WebApplication1;Trusted_Connection=True;MultipleActiveResultSets=true"
// "DefaultConnection": "Server=LAPTOP-TACPFI57\\SQLEXPRESS;Database=WebApplication1;Trusted_Connection=True;MultipleActiveResultSets=true; User=sa; "



