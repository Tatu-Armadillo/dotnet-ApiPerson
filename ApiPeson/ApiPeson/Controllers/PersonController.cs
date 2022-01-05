using Microsoft.AspNetCore.Mvc;
using ApiPerson.Services.Implementations;
using Microsoft.Extensions.Logging;
using ApiPerson.Models;
using System.Collections.Generic;

namespace ApiPerson.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonController : ControllerBase
    {
        private readonly ILogger<PersonController> _logger;
        private IPersonService personService;

        public PersonController(ILogger<PersonController> logger, IPersonService personService)
        {
            _logger = logger;
            this.personService = personService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            List<Person> persons = personService.FindAll();
            return Ok(persons) ;
        }

        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            Person person = personService.FindById(id);
            if (person == null) return NotFound();            
            return Ok(person);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Person person)
        {
            if (person == null) return BadRequest();
            return Ok(this.personService.Create(person));
        }

        [HttpPut]
        public IActionResult Put([FromBody] Person person)
        {
            if (person == null) return BadRequest();
            return Ok(this.personService.Update(person));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            personService.Delete(id);
            return NoContent();
        }

    }
}