using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Badges_Repository
{
    public class Event
    {
        public int ID { get; set; }
        public string Outing { get; set; }
        public int Attendence { get; set; }
        public decimal PersonCost { get; set; }
        public decimal EventCost { get {
                return this.Attendence * this.PersonCost;} }
        public DateTime Date { get; set; }

        public Event() { }

        public Event(string outing, int attendence, decimal personCost, DateTime date)
        {
            Outing = outing;
            Attendence = attendence;
            PersonCost = personCost;

            Date = date;
        }
    }
    
}
