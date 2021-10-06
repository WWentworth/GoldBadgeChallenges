using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Green_Plan_POCO
{
    public class GasCar
    {
        public int ID { get; set; }
        public List<Car> CarList { get; set; }

        public GasCar()
        {
            CarList = new List<Car>();
        }

        public bool AddCarToGas(Car carToBeAdded)
        {
            int carCount = this.CarList.Count;
            this.CarList.Add(carToBeAdded);

            if (carCount < this.CarList.Count)
            {
                return true;
            }
            return false;
        }

        public bool RemoveCarFromGas(Car carToBeRemoved)
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
