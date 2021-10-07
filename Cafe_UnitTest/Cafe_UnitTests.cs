using Cafe_Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Cafe_UnitTest
{
    [TestClass]
    public class Cafe_UnitTests
    {
        private readonly MenuRepository _repo = new MenuRepository();
        [TestInitialize]
        public void Arrange()
        {
            Menu menu = new Menu("Crab Legs", "Seafood", "Yummy", 5m);
            _repo.AddMealToList(menu);
        }

        [TestMethod]
        public void AddMealToList_MenuIsNull_ReturnFalse()
        {
            //arrange - create variables we need to test
            Menu menu = null;
            MenuRepository menuRepository = new MenuRepository();
            //act - calling method
            bool result = menuRepository.AddMealToList(menu);
            //assert - confirm method did what it was supposed to
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void AddMealToList_MenuIsNotNull_ReturnTrue()
        {
            Menu menu = new Menu("Crab Legs", "Seafood", "Yummy", 5m);
            MenuRepository repo = new MenuRepository();

            bool result = repo.AddMealToList(menu);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void GetMealByID_MenuDoesNotExist_ReturnNull()
        {
            int id = 555;

            Menu result = _repo.GetMealByID(id);

            Assert.IsNull(result);
        }
        [TestMethod]
        public void RemoveMealFromList_MenuIsNull_ReturnFalse()
        {
            int id = 555;

            bool result = _repo.RemoveMealFromList(id);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void RemoveMealFromList_MenuIsNotNull_ReturnTrue()
        {
            int id = 1;

            bool result = _repo.RemoveMealFromList(id);

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void GetMealByID_MenuExists_ReturnMenu()
        {
            int id = 1;

            Menu result = _repo.GetMealByID(id);

            Assert.IsNotNull(result);
            Assert.AreEqual(result.ID, id);
        }
    }
}
