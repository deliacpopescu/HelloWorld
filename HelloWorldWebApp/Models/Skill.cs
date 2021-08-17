using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelloWorldWebApp.Models
{
    public class Skill
    {
        /*public Skill(string name, string URL)
        {
            this.Id = 1;
            this.Name = name;
            this.URL = URL;
        }
        public Skill(int id, string name, string URL)
        {
            this.Id = id;
            this.Name = name;
            this.URL = URL;
        }
        */
        public int Id { get; set; }
        public string Name { get; set; }
        public string URL { get; set; }
    }
 
}
