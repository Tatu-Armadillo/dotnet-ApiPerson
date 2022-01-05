﻿using ApiPerson.Models;
using ApiPeson.Models.Context;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ApiPerson.Services.Implementations
{
    public class PersonServiceImplemetation : IPersonService
    {
        private MySQLContext context;

        public PersonServiceImplemetation(MySQLContext context) 
        {
            this.context = context;
        }

        public Person FindById(long id)
        {
            return this.context.Persons.SingleOrDefault(p =>p.Id.Equals(id));
        }

        public List<Person> FindAll()
        {
            return this.context.Persons.ToList();
        }

        public Person Create(Person person)
        {
            try 
            {
                this.context.Add(person);
                this.context.SaveChanges();
            } 
            catch(Exception) 
            {
                throw;
            }
            return person;
        }

        public Person Update(Person person)
        {
            if(!Exists(person.Id))
            {
                return new Person();
            }

            var result = this.context.Persons.SingleOrDefault(p =>p.Id.Equals(person.Id));
            if(result != null){
                try 
                {
                    this.context.Entry(result).CurrentValues.SetValues(person);
                    this.context.SaveChanges();
                } 
                catch(Exception) 
                {
                    throw;
                }
            }
            return person;
        }

        public void Delete(long id)
        {
            var result = this.context.Persons.SingleOrDefault(p =>p.Id.Equals(id));
            if(result != null)
            {
                try 
                {
                    this.context.Persons.Remove(result);
                    this.context.SaveChanges();
                } 
                catch(Exception) 
                {
                    throw;
                }
            }

        }                

        

        private bool Exists(long id) {
            return this.context.Persons.Any(p =>p.Id.Equals(id));
        }

    }
}
