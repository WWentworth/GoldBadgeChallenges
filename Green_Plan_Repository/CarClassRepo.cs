using Green_Plan_POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Green_Plan_Repository
{
    public class CarClassRepo
    {
        private List<CarClass> _listOfCarClasses = new List<CarClass>();
        private int _count = 0;
        public bool AddCarClassToList(CarClass carToBeAdded)
        {
            if (carToBeAdded is null)
            {
                return false;
            }
            _count++;
            carToBeAdded.ID = _count;
            _listOfCarClasses.Add(carToBeAdded);
            return true;
        }
        public List<CarClass> GetCarClassList()
        {
            return _listOfCarClasses;
        }

        public bool RemoveCarFromCarClass(int id)
        {
            var carToBeDeleted = GetCarClassById(id);

            if (carToBeDeleted is null)
            {
                return false;
            }
            else
            {
                _listOfCarClasses.Remove(carToBeDeleted);
                return true;
            }
        }
        public CarClass GetCarClassById(int id)
        {
            foreach (CarClass electricCar in _listOfCarClasses)
            {
                if (electricCar.ID == id)
                {
                    return electricCar;
                }
            }
            return null;
        }
    }
}
