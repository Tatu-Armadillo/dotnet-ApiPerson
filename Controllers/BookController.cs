using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using ApiPerson.Models;
using ApiPerson.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ApiPerson.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookController : Controller
    {
        private readonly ILogger<BookController> _logger;
        private  IBookService bookService;

        public BookController(ILogger<BookController> logger, IBookService bookService)
        {
            _logger = logger;
            this.bookService = bookService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            List<Book> books = bookService.FindAll();
            return Ok(books) ;
        }

        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            Book book = bookService.FindById(id);
            if (book == null) return NotFound();            
            return Ok(book);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Book book)
        {
            if (book == null) return BadRequest();
            return Ok(this.bookService.Create(book));
        }

        [HttpPut]
        public IActionResult Put([FromBody] Book book)
        {
            if (book == null) return BadRequest();
            return Ok(this.bookService.Update(book));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            bookService.Delete(id);
            return NoContent();
        }
    }
}