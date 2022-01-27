using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ApiPerson.Models;
using System.Collections.Generic;
using ApiPerson.Business;

namespace ApiPerson.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonController : ControllerBase
    {
        private readonly ILogger<PersonController> _logger;
        private IPersonBusiness personBusiness;

        public PersonController(ILogger<PersonController> logger, IPersonBusiness personBusiness)
        {
            _logger = logger;
            this.personBusiness = personBusiness;
        }

        [HttpGet]
        public IActionResult Get()
        {
            List<Person> persons = personBusiness.FindAll();
            return Ok(persons) ;
        }

        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            Person person = personBusiness.FindById(id);
            if (person == null) return NotFound();            
            return Ok(person);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Person person)
        {
            if (person == null) return BadRequest();
            return Ok(this.personBusiness.Create(person));
        }

        [HttpPut]
        public IActionResult Put([FromBody] Person person)
        {
            if (person == null) return BadRequest();
            return Ok(this.personBusiness.Update(person));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            personBusiness.Delete(id);
            return NoContent();
        }

    }
}