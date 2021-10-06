using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Green_Plan_POCO
{
    public class Car
    {
        public string Make { get; set; }
        public string Model { get; set; }
        public int ID { get; set; }
        public decimal MSRP { get; set; }
        public int Horsepower { get; set; }
        public decimal SafetyRating { get; set; }

        public Car() { }

        public Car (string make, string model, decimal mSRP, int horsepower, decimal safetyRating)
        {
            Make = make;
            Model = model;
            MSRP = mSRP;
            Horsepower = horsepower;
            SafetyRating = safetyRating;
        }
    }
}
