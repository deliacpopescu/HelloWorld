using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelloWorldWebApp.Models
{
    public class Member
    {
        public Member(int id, string name)
        {
            this.Id = id;
            this.Name = name;
        }
        public string Name { get; set; }
        public int Id { get; set; }


    }
}
