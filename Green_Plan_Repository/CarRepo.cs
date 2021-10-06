using Green_Plan_POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Green_Plan_Repository
{
   public class CarRepo
    {
        private List<Car> _listOfCars = new List<Car>();
        public List<Car> ListOfCars { get; set; }
        public int _count = 0;

        public bool AddCarToList(Car carToBeAdded)
        {
            if (carToBeAdded is null)
            {
                return false;
            }
            _count++;
            carToBeAdded.ID = _count;
            _listOfCars.Add(carToBeAdded);
            return true;
        }
        //read
        public List<Car> GetCarList()
        {
            return _listOfCars;
        }

        //update
        public bool UpdateExistingCar(int originalCar, Car newCar)
        {
            Car oldCar = GetCarById(originalCar);

            if (oldCar != null)
            {
                oldCar.Make = newCar.Make;
                oldCar.Model = newCar.Model;
                oldCar.MSRP = newCar.MSRP;
                oldCar.Horsepower = newCar.Horsepower;
                oldCar.SafetyRating = newCar.SafetyRating;
                return true;
            }
            else
            {
                return false;
            }
        }

        //delete
        public bool RemoveCarFromList(int id)
        {
            var carToBeDeleted = GetCarById(id);

            if (carToBeDeleted is null)
            {
                return false;
            }
            else
            {
                _listOfCars.Remove(carToBeDeleted);
                return true;
            }
        }
        //id search for cars
        public Car GetCarById(int id)
        {
            foreach (Car car in _listOfCars)
            {
                if (car.ID == id)
                {
                    return car;
                }
            }
            return null;
        }
    }
}
