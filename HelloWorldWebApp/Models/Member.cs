using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelloWorldWebApp.Models
{
    public class Member
    {
        public Member(string name)
        {
            this.Id = 1;
            this.Name = name;
        }
        public Member(int id, string name)
        {
            this.Id = id;
            this.Name = name;
        }
       
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
