using System.Collections.Generic;
using NUnit.Framework;
using Person.DAL;
using Person.Person;

namespace PersonTest
{
    public class MockPersonDbDal : IPersonDbDal
    {
        // SHOULD ABSOLUTELY BE REPLACED BY PROPER FAKE!!


        
        
        private readonly PersonModel _expectedSingleModel;
        private readonly List<PersonModel> _returnableList;

        public MockPersonDbDal(PersonModel expectedModel)
        {
            _expectedSingleModel = expectedModel;
        }

        public MockPersonDbDal(List<PersonModel> returnableList)
        {
            _returnableList = returnableList;
        }


        public void AddPerson(PersonModel person)
        {
            Assert.AreEqual(_expectedSingleModel.Firstname, person.Firstname);
            Assert.AreEqual(_expectedSingleModel.Lastname, person.Lastname);
            Assert.AreEqual(_expectedSingleModel.Streetname, person.Streetname);
            Assert.AreEqual(_expectedSingleModel.Streetname, person.Streetname);
        }

        public List<PersonModel> ListPersons()
        {
            return _returnableList;
        }

        public List<PersonModel> ListPersonsByLastName(string lastname)
        {
            return _returnableList;
        }

        public List<PersonModel> ListPersonsByZip(string zip)
        {
            return _returnableList;
        }
    }
}