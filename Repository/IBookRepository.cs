using System.Collections.Generic;
using ApiPerson.Models;

namespace ApiPerson.Repository
{
    public interface IBookRepository 
    {
        Book Create(Book book);
        Book FindById(long id);
        List<Book> FindAll();
        Book Update(Book person);  
        void Delete(long id);
        bool Exists(long id);

    }
}