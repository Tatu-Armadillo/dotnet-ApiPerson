using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ApiPerson.Models;
using System.Collections.Generic;
using ApiPerson.Services;

namespace ApiPerson.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonController : ControllerBase
    {
        private readonly ILogger<PersonController> _logger;
        private IPersonServices personServices;

        public PersonController(ILogger<PersonController> logger, IPersonServices personServices)
        {
            _logger = logger;
            this.personServices = personServices;
        }

        [HttpGet]
        public IActionResult Get()
        {
            List<Person> persons = personServices.FindAll();
            return Ok(persons) ;
        }

        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            Person person = personServices.FindById(id);
            if (person == null) return NotFound();            
            return Ok(person);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Person person)
        {
            if (person == null) return BadRequest();
            return Ok(this.personServices.Create(person));
        }

        [HttpPut]
        public IActionResult Put([FromBody] Person person)
        {
            if (person == null) return BadRequest();
            return Ok(this.personServices.Update(person));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            personServices.Delete(id);
            return NoContent();
        }

    }
}