using Green_Plan_POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Green_Plan_Repository
{
    class GasCarRepo
    {
        private List<GasCar> _listOfGasCars = new List<GasCar>();
        private int _count = 0;
        public bool AddGasCarToList(GasCar carToBeAdded)
        {
            if (carToBeAdded is null)
            {
                return false;
            }
            _count++;
            carToBeAdded.ID = _count;
            _listOfGasCars.Add(carToBeAdded);
            return true;
        }
        public List<GasCar> GetGasCarList()
        {
            return _listOfGasCars;
        }

        public bool RemoveGasCarFromList(int id)
        {
            var carToBeDeleted = GetGasCarById(id);

            if (carToBeDeleted is null)
            {
                return false;
            }
            else
            {
                _listOfGasCars.Remove(carToBeDeleted);
                return true;
            }
        }
        public GasCar GetGasCarById(int id)
        {
            foreach (GasCar gasCar in _listOfGasCars)
            {
                if (gasCar.ID == id)
                {
                    return gasCar;
                }
            }
            return null;
        }
    }
}
