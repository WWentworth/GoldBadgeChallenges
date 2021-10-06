using Green_Plan_POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Green_Plan_Repository
{
    class HybridCarRepo
    {
        private List<HybridCar> _listOfHybridCars = new List<HybridCar>();
        private int _count = 0;
        public bool AddHybridCarToList(HybridCar carToBeAdded)
        {
            if (carToBeAdded is null)
            {
                return false;
            }
            _count++;
            carToBeAdded.ID = _count;
            _listOfHybridCars.Add(carToBeAdded);
            return true;
        }
        public List<HybridCar> GetGasCarList()
        {
            return _listOfHybridCars;
        }

        public bool RemoveHybridCarFromList(int id)
        {
            var carToBeDeleted = GetHybridCarById(id);

            if (carToBeDeleted is null)
            {
                return false;
            }
            else
            {
                _listOfHybridCars.Remove(carToBeDeleted);
                return true;
            }
        }
        public HybridCar GetHybridCarById(int id)
        {
            foreach (HybridCar hybridCar in _listOfHybridCars)
            {
                if (hybridCar.ID == id)
                {
                    return hybridCar;
                }
            }
            return null;
        }
    }
}
