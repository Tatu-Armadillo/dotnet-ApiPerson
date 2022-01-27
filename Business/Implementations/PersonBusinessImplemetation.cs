﻿using ApiPerson.Models;
using ApiPerson.Repository;
using System.Collections.Generic;

namespace ApiPerson.Business.Implementations
{
    public class PersonBusinessImplemetation : IPersonBusiness
    {
        private readonly IPersonRepository repository;

        public PersonBusinessImplemetation(IPersonRepository repository)
        {
            this.repository = repository;
        }

        public List<Person> FindAll()
        {
            return this.repository.FindAll();
        }

        public Person FindById(long id)
        {
            return this.repository.FindById(id);
        }

        public Person Create(Person person)
        {
            return this.repository.Create(person);
        }

        public Person Update(Person person)
        {
            return this.repository.Update(person);
        }

        public void Delete(long id)
        {
            this.repository.Delete(id);
        }

    }
}
