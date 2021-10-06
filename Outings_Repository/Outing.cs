using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Outings_Repository
{
    public class Outing
    {
        private List<Event> _listOfOutings = new List<Event>();
        public List<Event> ListOfOutings { get; set; }
        public int _count = 0;

        public bool AddOutingToList(Event outingToBeAdded)
        {
            if (outingToBeAdded is null)
            {
                return false;
            }
            _count++;
            _listOfOutings.Add(outingToBeAdded);
            return true;
        }

        public List<Event> GetOutingList()
        {
            return _listOfOutings;
        }

        public bool RemoveOutingFromList(int id)
        {
            var outingToBeDeleted = GetOutingByID(id);
            if (outingToBeDeleted is null)
            {
                return false;
            }
            else
            {
                _listOfOutings.Remove(outingToBeDeleted);
                return true;
            }
        }
        public Event GetOutingByID(int id)
        {
            foreach(Event outing in _listOfOutings)
            {
                if(outing.ID == id)
                {
                    return outing;
                }
            }
            return null;
        }

    }
}
