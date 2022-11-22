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
    public class EmailsController : ControllerBase
    {
        private readonly EmailsRepository _emailsRepository;

        public EmailsController(ApplicationDbContext applicationDbContext)
        {
            _emailsRepository = new EmailsRepository(applicationDbContext);
        }

        // GET: api/Emails
        [HttpGet]
        public ActionResult<IEnumerable<Email>> Get()
        {
            return _emailsRepository.GetAll();
        }

        // GET api/Emails/5
        [HttpGet("{id}")]
        public ActionResult<Email> Get(int id)
        {
            try
            {
                Email email = _emailsRepository.GetOne(id);
                return new OkObjectResult(email);
            }
            catch (InvalidOperationException ioe)
            {
                return new NotFoundResult();
            }
        }

        // POST api/Emails
        [HttpPost]
        public ActionResult Post([FromBody] Email body)
        {
            _emailsRepository.CreateOne(body);
            return new OkResult();
        }

        // PUT api/Emails/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Email body)
        {
            try
            {
                _emailsRepository.EditOne(id, body);
                return new OkResult();
            }
            catch (InvalidOperationException ioe)
            {
                return new NotFoundResult();
            }
        }

        // DELETE api/Emails/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                _emailsRepository.DeleteOne(id);
                return new OkResult();
            }
            catch (InvalidOperationException ioe)
            {
                return new NotFoundResult();
            }
        }
    }
}
