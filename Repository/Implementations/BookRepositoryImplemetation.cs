using System;
using System.Collections.Generic;
using System.Linq;
using ApiPerson.Models;
using ApiPeson.Models.Context;

namespace ApiPerson.Repository.Implementations
{
    public class BookRepositoryImplemetation : IBookRepository
    {
        private MySQLContext context;

        public BookRepositoryImplemetation(MySQLContext context) 
        {
            this.context = context;
        }

        public Book FindById(long id)
        {
            return this.context.Books.SingleOrDefault(p =>p.Id.Equals(id));
        }

        public List<Book> FindAll()
        {
            return this.context.Books.ToList();
        }

        public Book Create(Book book)
        {
            try 
            {
                this.context.Add(book);
                this.context.SaveChanges();
            } 
            catch(Exception) 
            {
                throw;
            }
            return book;
        }

        public Book Update(Book book)
        {
            if(!Exists(book.Id))
            {
                return null;
            }

            var result = this.context.Books.SingleOrDefault(p =>p.Id.Equals(book.Id));
            if(result != null){
                try 
                {
                    this.context.Entry(result).CurrentValues.SetValues(book);
                    this.context.SaveChanges();
                } 
                catch(Exception) 
                {
                    throw;
                }
            }
            return book;
        }

        public void Delete(long id)
        {
            var result = this.context.Books.SingleOrDefault(p =>p.Id.Equals(id));
            if(result != null)
            {
                try 
                {
                    this.context.Books.Remove(result);
                    this.context.SaveChanges();
                } 
                catch(Exception) 
                {
                    throw;
                }
            }

        }                
        public  bool Exists(long id) {
            return this.context.Books.Any(p =>p.Id.Equals(id));
        }
    }
}