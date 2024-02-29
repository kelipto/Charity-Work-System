using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CharityWorkSystem
{
    public class Client : Person
    {
        private static int nextID = 0;
        public string ID { get; private set; }
        public bool Recorded { get; private set; }
        public bool Registered { get; private set; }
        public bool Driving { get; private set; }
        public bool Criminal { get; private set; }
        public Organisation Organisation { get; private set; }
        public List<Vacant> Vacants { get; }
        public List<Interview> Interviews { get; }

        public Client(string n, string a, string e, string s) : base(n, a, e, s)
        {
            Recorded = true;
            Registered = false;
            Vacants = new List<Vacant>();
            Interviews = new List<Interview>();
            Driving = false;
            Criminal = false;
            ID = nextID.ToString("D3");
            nextID++;
        }

        public void Assign(Organisation o)
        {
            if (Recorded)
            {
                Organisation = o;
                o.AddClient(this);
                Registered = true;
            }
        }

        public void AddVacant(Vacant v)
        {
            Vacants.Add(v);
            v.AddClient(this);

        }

        public void AddInterview(Vacant v, DateTime dt, Organisation o)
        {
            Interviews.Add(new Interview(this, v, dt, o));
        }

        public List<string> PrintInterviews()
        {
            List<string> result = new List<string>();
            foreach (Interview i in Interviews)
            {

                result.Add(i.ToString());
            }
            return result;
        }

        //method to print Client as text
        public override string ToString()
        {
            string result = "(" + ID + ")" + Name;

            if (Registered)
            {
                result += " - " + Organisation.ToString();
            }
            if (!Registered)
            {
                result += " - " + "Unemployed";
            }
            return result;
        }
    }
}