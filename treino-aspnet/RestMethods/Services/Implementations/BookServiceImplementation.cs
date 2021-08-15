using RestMethods.Model;
using RestMethods.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestMethods.Services.Implementations
{
    public class BookServiceImplementation : IBookService
    {
        private IBookRepository repository;

        public BookServiceImplementation(IBookRepository repo)
        {
            repository = repo;
        }

        Book IBookService.Create(Book book)
        {
            return repository.Create(book);
        }

        void IBookService.Delete(long id)
        {
            repository.Delete(id);
        }

        bool IBookService.Exists(long id)
        {
            return true;
        }

        Book IBookService.FindById(long id)
        {
            return repository.FindById(id);
        }

        List<Book> IBookService.ListAll()
        {
            return repository.ListAll();
        }

        Book IBookService.Replace(Book book)
        {
            return repository.Replace(book);
        }

        Book IBookService.Update(Book book)
        {
            throw new NotImplementedException();
        }
    }
}
