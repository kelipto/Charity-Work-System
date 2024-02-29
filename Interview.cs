using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharityWorkSystem
{
    public class Interview
    {
        public Client Client { get; }

        public Vacant Vacant { get; }

        public DateTime Date { get; set; }

        public Organisation Organisation { get; set; }

        public Interview(Client c, Vacant v, DateTime dt, Organisation o)
        {
            Client = c;
            Vacant = v;
            Date = dt;
            Organisation = o;
        }


        public override string ToString()
        {
            return Organisation + " " + Vacant.Title + " - " + Date;
        }
    }
}
