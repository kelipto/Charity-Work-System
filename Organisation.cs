using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CharityWorkSystem
{
    public class Organisation
    {
        // Properties
        public string Name { get; set; }
        private static int nextID = 1;
        public string ID { get; set; }

        public List<Vacant> Vacants { get; }
        public List<Client> Clients { get; }

        // Constructor
        public Organisation(string n)
        {
            Name = n;
            Vacants = new List<Vacant>();
            Clients = new List<Client>();
            ID = "ORG" + nextID.ToString("D2");
            nextID++;

        }

        // Methods
        public void AddVacant(Vacant v)
        {
            Vacants.Add(v);
            v.AddOrganisation(this);
        }

        public void RemoveVacant(Vacant v)
        {
            Vacants.Remove(v);
            v.RemoveOrganisation(this);
        }


        public void AddClient(Client c)
        {
            Clients.Add(c);
        }


        // Method to print the organisation as text
        override public string ToString()
        {
            return ID + " " + Name;
        }

    }
}
