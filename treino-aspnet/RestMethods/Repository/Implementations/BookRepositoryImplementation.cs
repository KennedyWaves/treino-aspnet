using RestMethods.Model.Context;
using RestMethods.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestMethods.Repository.Implementations
{
    public class BookRepositoryImplementation : IBookRepository
    {
        private MySQLContext repository;
        public BookRepositoryImplementation(MySQLContext context)
        {
            repository = context;
        }

        Book IBookRepository.Create(Book book)
        {
            try
            {
                if (!Exists(book.Id))
                {
                    repository.Add(book);
                    repository.SaveChanges();
                }
                else
                {
                    throw new SystemException();
                }
            }
            catch (SystemException)
            {

            }
            return book;
        }

        void IBookRepository.Delete(long id)
        {
            Book result = repository.Books.SingleOrDefault(p => p.Id.Equals(id));
            if (result != null)
            {
                repository.Books.Remove(result);
                repository.SaveChanges();
            }
        }

        Book IBookRepository.FindById(long id)
        {
            return repository.Books.SingleOrDefault(p => p.Id.Equals(id));
        }

        List<Book> IBookRepository.ListAll()
        {
            return repository.Books.ToList();
        }

        Book IBookRepository.Replace(Book book)
        {
            try
            {
                if (Exists(book.Id))
                {
                    repository.Update(book);
                    repository.SaveChanges();
                }
                else
                {
                    throw new SystemException();
                }
            }
            catch (SystemException)
            {
                throw;
            }
            return book;

        }

        Book IBookRepository.Update(Book book)
        {
            try
            {

            }
            catch (SystemException)
            {
                throw;
            }
            return book;
        }
        /// <summary>
        /// Verifica se o elemento já foi persistido.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Exists(long id)
        {
            return repository.Books.Any(p => p.Id.Equals(id));
        }
    }
}