using System;
using System.Collections.Generic;
using Person.Authentication;
using Person.Person;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Person.DAL;

namespace Person.Controllers
{
    [Authorize(Roles = "User, Admin")]
    [ApiController]
    [Route("[controller]")]
    public class PersonController : ControllerBase
    {
        private readonly IPersonDbDal _personDbDal;
        

        public PersonController(IPersonDbDal dal)
        {
            _personDbDal = dal;
        }

        [HttpGet]
        public IEnumerable<PersonModel> Get()
        {
            return _personDbDal.ListPersons().ToArray();
        }

        [HttpGet]
        [Route("lastname/{lastname}")]
        public IEnumerable<PersonModel> GetByLastName([FromRoute] string lastname)
        {
            return _personDbDal.ListPersonsByLastName(lastname).ToArray();
        }

        [HttpGet]
        [Route("zip/{zip}")]
        public IEnumerable<PersonModel> GetByZip([FromRoute] string zip)
        {
            return _personDbDal.ListPersonsByZip(zip).ToArray();
        }



        [Authorize(Roles = UserRoles.Admin)]
        [HttpPut]
        public IActionResult Put([FromBody] PersonModel model){
            //TODO look into created  https://docs.microsoft.com/en-us/aspnet/core/web-api/?view=aspnetcore-3.1
            _personDbDal.AddPerson(model);
            return Ok();
        }
    }
}
