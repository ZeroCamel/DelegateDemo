using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventAgentDemo
{
    public class User
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Pwd { get; set; }
        public User(string Id,string Name,string Pwd)
        {
            this.Id = Id;
            this.Name = Name;
            this.Pwd = Pwd;
        }
    }
}
