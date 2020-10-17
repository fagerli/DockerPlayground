using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Person.Person;

namespace Person.DAL
{
    public interface IPersonDbDal
    {
        void AddPerson(PersonModel person);

        List<PersonModel> ListPersons();

        List<PersonModel> ListPersonsByLastName(string lastname);

        List<PersonModel> ListPersonsByZip(string zip);
    }
}
