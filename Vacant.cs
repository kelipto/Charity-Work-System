using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CharityWorkSystem
{
    public class Vacant
    {
        public string Title { get; set; }
        public string Field { get; set; }
        public string StartDate { get; set; }
        public string Salary { get; set; }
        public string Qualification { get; set; }
        public string Experience { get; set; }
        public bool Driving { get; set; }
        public bool Criminal { get; set; }
        public List<Organisation> Organisations { get; }
        public List<Client> Clients { get; }

        public Vacant(string t, string f, string d, string s, string q, string e)
        {
            Title = t;
            Field = f;
            StartDate = d;
            Salary = s;
            Convert.ToDecimal(s);
            Qualification = q;
            Organisations = new List<Organisation>();
            Clients = new List<Client>();
            Experience = e;
            Driving = false;
            Criminal = false;
        }


        public void AddOrganisation(Organisation o)
        {
            Organisations.Add(o);
        }

        public void RemoveOrganisation(Organisation o)
        {
            Organisations.Remove(o);
        }

        public void AddClient(Client c)
        {
            Clients.Add(c);
        }


        // Method to print the vacant as text
        override public string ToString()
        {
            return "|" + Field + "|" + Title;
        }
    }
}
