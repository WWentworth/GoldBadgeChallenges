﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Green_Plan_POCO
{
    public class CarClass
    {
        public string Name { get; set; }
        public int ID { get; set; }
        public List<Car> CarList { get; set; }

        public CarClass() { }

        public CarClass(string name)
        {
            Name = name;
            CarList = new List<Car>();
        }
        public bool AddCarToCarClass(Car carToBeAdded)
        {
            int carCount = this.CarList.Count;
            this.CarList.Add(carToBeAdded);

            if (carCount < this.CarList.Count)
            {
                return true;
            }
            return false;
        }

        public bool RemoveCarFromCarClass(Car carToBeRemoved)
        {
            int carCount = this.CarList.Count;
            this.CarList.Remove(carToBeRemoved);

            if (carCount > this.CarList.Count)
            {
                return true;
            }
            return false;
        }

    }

}
