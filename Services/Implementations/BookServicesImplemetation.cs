using System.Collections.Generic;
using ApiPerson.Models;
using ApiPerson.Repository;

namespace ApiPerson.Services.Implementations
{
    public class BookServicesImplemetation : IBookService
    {
        private readonly IBookRepository repository;

        public BookServicesImplemetation(IBookRepository repository)
        {
            this.repository = repository;
        }

        public List<Book> FindAll()
        {
            return this.repository.FindAll();
        }

        public Book FindById(long id)
        {
            return this.repository.FindById(id);
        }

        public Book Create(Book book)
        {
            return this.repository.Create(book);
        }

        public Book Update(Book book)
        {
            return this.repository.Update(book);
        }

        public void Delete(long id)
        {
            this.repository.Delete(id);
        }
    }
}