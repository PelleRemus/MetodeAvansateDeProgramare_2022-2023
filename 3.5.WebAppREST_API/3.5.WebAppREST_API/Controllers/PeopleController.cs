using _3._5.WebAppREST_API.Data;
using _3._5.WebAppREST_API.Models;
using _3._5.WebAppREST_API.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

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
        public ActionResult<IEnumerable<Person>> GetFilteredAndPaginated(
            [FromQuery] string search, [FromQuery] int page, [FromQuery] int pageSize)
        {
            var people = _peopleRepository.GetFilteredAndPaginated(search, page, pageSize);
            return new OkObjectResult(people);
        }

        // GET api/People/5
        [HttpGet("{id}")]
        public ActionResult<Person> Get(int id)
        {
            try
            {
                Person person = _peopleRepository.GetOne(id);
                return new OkObjectResult(person);
            }
            catch (InvalidOperationException ioe)
            {
                return new NotFoundResult();
            }
        }

        // POST api/People
        [HttpPost]
        public ActionResult Post([FromBody] Person body)
        {
            _peopleRepository.CreateOne(body);
            return new OkResult();
        }

        // PUT api/People/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Person body)
        {
            try
            {
                _peopleRepository.EditOne(id, body);
                return new OkResult();
            }
            catch (InvalidOperationException ioe)
            {
                return new NotFoundResult();
            }
        }

        // DELETE api/People/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                _peopleRepository.DeleteOne(id);
                return new OkResult();
            }
            catch (InvalidOperationException ioe)
            {
                return new NotFoundResult();
            }
        }
    }
}
