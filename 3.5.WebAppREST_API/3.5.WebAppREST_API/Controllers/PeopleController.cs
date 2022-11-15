using _3._5.WebAppREST_API.Data;
using _3._5.WebAppREST_API.Models;
using _3._5.WebAppREST_API.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace _3._5.WebAppREST_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        private readonly PeopleRepository _peopleRepository; 

        public PeopleController(ApplicationDbContext applicationDbContext)
        {
            _peopleRepository = new PeopleRepository(applicationDbContext);
        }

        // GET: api/People
        [HttpGet]
        public IEnumerable<Person> Get()
        {
            return _peopleRepository.GetAll();
        }

        // GET api/People/5
        [HttpGet("{id}")]
        public Person Get(int id)
        {
            return _peopleRepository.GetOne(id);
        }

        // POST api/People
        [HttpPost]
        public void Post([FromBody] Person body)
        {
            _peopleRepository.CreateOne(body);
        }

        // PUT api/People/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Person body)
        {
            _peopleRepository.EditOne(id, body);
        }

        // DELETE api/People/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _peopleRepository.DeleteOne(id);
        }
    }
}
