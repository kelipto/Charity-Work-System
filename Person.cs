using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharityWorkSystem
{
    public abstract class Person
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Status { get; set; }

        public Person(string n, string a, string e, string s)
        {
            Name = n;
            Address = a;
            Email = e;
            Status = s;
        }
    }
}
