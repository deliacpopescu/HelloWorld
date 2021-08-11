﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelloWorldWebApp.Models
{
    public class Member
    {
        public Member(string name, int id = 0)
        {
            this.Id = id;
            this.Name = name;
        }

        public int Id { get; set; }

        public string Name { get; set; }
        public DateTime Birthdate { get; set; }

        public int GetAge()
        {
            var age = DateTime.Now.Subtract(Birthdate).Days;
            age = age / 365;
            return age;
            
        }
    }
}
