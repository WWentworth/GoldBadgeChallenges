using Green_Plan_POCO;
using Green_Plan_Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Green_Plan_UnitTest
{

    [TestClass]
    public class Green_Plan_CarClass_UnitTest
    {
        private readonly CarClassRepo _repo = new CarClassRepo();
        [TestInitialize]
        public void Arrange()
        {
            CarClass carClass = new CarClass("Electric");
            _repo.AddCarClassToList(carClass);
        }
        //add
        [TestMethod]
        public void AddCarClassToList_MenuIsNull_ReturnFalse()
        {
            CarClass carClass = null;
            CarClassRepo carClassRepository = new CarClassRepo();

            bool result = carClassRepository.AddCarClassToList(carClass);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void AddCarClassToList_MenuIsNotNull_ReturnTrue()
        {
            CarClass electric = new CarClass("Electric");
            CarClassRepo repo = new CarClassRepo();

            bool result = repo.AddCarClassToList(electric);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void RemoveCarFromCarClass_CarIsNull_ReturnFalse()
        {
            int id = 555;

            bool result = _repo.RemoveCarFromCarClass(id);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void RemoveCarFromCarClass_MenuIsNotNull_ReturnTrue()
        {
            int id = 1;

            bool result = _repo.RemoveCarFromCarClass(id);

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void GetCarClassByID_CarClassExists_ReturnMenu()
        {
            int id = 1;

            CarClass result = _repo.GetCarClassById(id);

            Assert.IsNotNull(result);
            Assert.AreEqual(result.ID, id);
        }
    }
}
