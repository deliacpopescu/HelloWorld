using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelloWorldWebApp.Models
{
    public class Member
    {
        public Member(string name, int id)
        {
            this.Name = name;
            this.Id = id;
        }
        public string Name { get; set; }
        public int Id { get; set; }


    }
}
