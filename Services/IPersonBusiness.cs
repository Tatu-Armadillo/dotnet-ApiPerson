using ApiPerson.Models;
using System.Collections.Generic;

namespace ApiPerson.Services
{
    public interface IPersonServices
    {
        Person Create(Person person);
        Person FindById(long id);
        List<Person> FindAll();
        Person Update(Person person);  
        void Delete(long id);

    }
}
