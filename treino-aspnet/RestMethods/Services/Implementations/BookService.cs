using RestMethods.Model;
using RestMethods.Repository;
using RestMethods.Repository.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestMethods.Services.Implementations
{
    public class BookService : IBookService
    {
        private IRepository<Book> repository;

        public BookService(IRepository<Book> repo)
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

        Book IBookService.Update(Book book)
        {
            return repository.Update(book);
        }
    }
}
