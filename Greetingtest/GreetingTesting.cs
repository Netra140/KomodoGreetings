using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using Repository;

namespace GreetingTest
{
    [TestClass]
    public class GreetingTesting
    {
        [TestMethod]
        public void AddTest()
        {
            GreetingRepo repository = new GreetingRepo();
            //Arrange
            repository._Greetings = new List<GreetingPoco>() { new GreetingPoco("Stan", "Marsh", 1) };
            //Act
            repository.AddGreeting(new GreetingPoco("Eric", "Cartman", 2));
            //Assert
            Assert.AreEqual(2, repository._Greetings.Count);
        }
        [TestMethod]
        public void RemoveTest()
        {
            GreetingRepo repository = new GreetingRepo();

            repository._Greetings = new List<GreetingPoco>() { new GreetingPoco("Stan", "Marsh", 1), new GreetingPoco("Eric", "Cartman", 2) };

            repository.RemoveGreeting(0);

            Assert.IsTrue(repository._Greetings.Count == 1 && repository._Greetings[0].firstname == "Eric");
        }
        [TestMethod]
        public void NameUpdateTest()
        {
            GreetingRepo repository = new GreetingRepo();
            repository._Greetings = new List<GreetingPoco>() { new GreetingPoco("Stan", "Marsh", 1), new GreetingPoco("Eric", "Cartman", 2) };
            repository.UpdateName("McCormic", 2, 0);
            repository.UpdateName("Kyle", 1, 1);
            Assert.IsTrue(repository._Greetings[0].fullname == "Stan McCormic" && repository._Greetings[1].fullname == "Kyle Cartman");
        }
        [TestMethod]
        public void StatusUpdateTest()
        {
            GreetingRepo repository = new GreetingRepo();
            repository._Greetings = new List<GreetingPoco>() { new GreetingPoco("Stan", "Marsh", 1), new GreetingPoco("Eric", "Cartman", 2) };
            repository.UpdateStatus(0, 3);
            Assert.IsTrue(repository._Greetings[0].type == "Potential" && repository._Greetings[0].email == "We currently have the lowest rates on Helicopter Insurance!");
        }
        [TestMethod]
        public void ListTest()
        {
            GreetingRepo repository = new GreetingRepo();
            repository._Greetings = new List<GreetingPoco>() { new GreetingPoco("Stan", "Marsh", 1), new GreetingPoco("Eric", "Cartman", 2) };
            repository.UpdateName("Stan", 1, 0);
            repository.UpdateName("Eric", 1, 1);
            repository.UpdateStatus(0, 1);
            repository.UpdateStatus(1, 2);
            List<GreetingPoco> result = repository.GetList();
            Assert.AreEqual(2, result.Count);
        }
    }
}
