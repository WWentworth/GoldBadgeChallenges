using Microsoft.VisualStudio.TestTools.UnitTesting;
using Outings_Repository;
using System;

namespace Outings_Test
{
    [TestClass]
    public class Outing_UnitTest
    {
        private readonly Outing _repo = new Outing();
        [TestInitialize]
        public void Arrange()
        {
            Event vent = new Event("golf", 20, 5m, DateTime.Now);
            _repo.AddOutingToList(vent);
        }

        [TestMethod]
        public void AddOutingToList_OutingIsNull_ReturnFalse()
        {
            Event vent = null;
            Outing outingRepository = new Outing();

            bool result = outingRepository.AddOutingToList(vent);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void AddOutingToList_OutingIsNotNull_ReturnTrue()
        {
            Event vent = new Event("golf", 20, 5m, DateTime.Now);
            Outing repo = new Outing();

            bool result = repo.AddOutingToList(vent);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void RemoveOutingFromList_OutingIsNull_ReturnFalse()
        {
            int id = 444;

            bool result = _repo.RemoveOutingFromList(id);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void RemoveOutingFromList_OutingIsNotNull_ReturnTrue()
        {
            int id = 1;

            bool result = _repo.RemoveOutingFromList(id);

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void GetOutingByID_OutingExists_ReturnMenu()
        {
            int id = 0;

            Event result = _repo.GetOutingByID(id);

            Assert.IsNotNull(result);
            Assert.AreEqual(result.ID, id);
        }
    }
}
