using Green_Plan_POCO;
using Green_Plan_Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Green_Plan_UnitTest
{
    [TestClass]
    public class Green_Plan_Car_UnitTest
    {
        private readonly CarRepo _repo = new CarRepo();
        [TestInitialize]
        public void Arrange()
        {
            Car car = new Car("Tesla", "Model Y", 39990m, 456, 5);
            _repo.AddCarToList (car);
        }
        //add
        [TestMethod]
        public void AddCarToList_CarIsNull_ReturnFalse()
        {
            Car car = null;
            CarRepo carRepo = new CarRepo();

            bool result = carRepo.AddCarToList(car);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void AddCarToList_CarIsNotNull_ReturnTrue()
        {
            Car car = new Car("Tesla", "Model Y", 39990m, 456, 5);
            CarRepo carRepo = new CarRepo();

            bool result = _repo.AddCarToList(car);

            Assert.IsTrue(result);
        }
        //getbyid
        [TestMethod]
        public void GetCarByID_CarDoesNotExist_ReturnNull()
        {
            int id = 555;

            Car result = _repo.GetCarById(id);

            Assert.IsNull(result);
        }

        [TestMethod]
        public void GetCarByID_CarExists_ReturnMenu()
        {
            int id = 1;

            Car result = _repo.GetCarById(id);

            Assert.IsNotNull(result);
            Assert.AreEqual(result.ID, id);
        }
        //remove
        [TestMethod]
        public void RemoveCarFromList_CarIsNull_ReturnFalse()
        {
            int id = 555;

            bool result = _repo.RemoveCarFromList(id);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void RemoveCarFromList_CarIsNotNull_ReturnTrue()
        {
            int id = 1;

            bool result = _repo.RemoveCarFromList(id);

            Assert.IsNotNull(result);
        }
        //update
        [TestMethod]
        public void UpdateExistingCar_CarDoesNotExist_ReturnFalse()
        {
            int id = 555;
            Car updateCar = new Car("Volvo", "350", 34990m, 500, 3);

            bool result = _repo.UpdateExistingCar(id, updateCar);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void UpdateExistingCar_CarDoesExist_ReturnTrue()
        {
            int id = 1;
            Car updateCar = new Car();

            bool result = _repo.UpdateExistingCar(id, updateCar);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void UpdateExistingCar_CarDoesExist_PropertiesUpdated()
        {
            int id = 1;
            Car updatedCar = new Car("Volvo", "350", 34990m, 500, 3);

            _repo.UpdateExistingCar(id, updatedCar);
            Car car = _repo.GetCarById(id);

            Assert.AreEqual("Volvo", car.Make);
            Assert.AreEqual("350", car.Model);
            Assert.AreEqual(34990m, car.MSRP);
            Assert.AreEqual(500, car.Horsepower);
            Assert.AreEqual(3, car.SafetyRating);
        }
    }
}
