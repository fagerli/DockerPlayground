using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Person.Controllers;
using Person.Person;

namespace PersonTest
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestPersonInsertion()
        {
            var testPersonModel = new PersonModel()
            {
                Firstname = "Fornavn",
                Lastname = "Etternavn",
                Streetname = "Gate",
                Zip = "5000"

            };
            var dal = new MockPersonDbDal(testPersonModel);
            var personController = new PersonController(dal);
            personController.Put(testPersonModel);
            Assert.Pass("Because dal wil assert values are similar.");
        }

        [Test]
        public void TestPersonListing()
        {
            var expectedList = new List<PersonModel>();
            expectedList.Add(new PersonModel()
            {
                Firstname = "Fornavn",
                Lastname = "Etternavn",
                Streetname = "Gate",
                Zip = "5000"

            });
            expectedList.Add(new PersonModel()
            {
                Firstname = "Fornavn2",
                Lastname = "Etternavn2",
                Streetname = "Gate2",
                Zip = "5001"

            });
            var dal = new MockPersonDbDal(expectedList);
            var personController = new PersonController(dal);
            var result = personController.Get();
            Assert.AreEqual(2, result.Count());
            Assert.AreEqual(expectedList.First().Firstname, result.First().Firstname);

        }
    }
}
