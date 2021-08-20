using RestMethods.Data.Converter.Impl;
using RestMethods.Data.DTO;
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
        private BookConverter converter = new BookConverter();

        public BookService(IRepository<Book> repo)
        {
            repository = repo;
        }

        BookDTO IBookService.Create(BookDTO  BookDTO )
        {
            return converter.Convert(repository.Create(converter.Convert(BookDTO)));
        }

        void IBookService.Delete(long id)
        {
            repository.Delete(id);
        }

        bool IBookService.Exists(long id)
        {
            return true;
        }

        BookDTO IBookService.FindById(long id)
        {
            return converter.Convert(repository.FindById(id));
        }

        List<BookDTO>IBookService.ListAll()
        {
            return converter.Convert(repository.ListAll());
        }

        BookDTO IBookService.Update(BookDTO  BookDTO )
        {
            return converter.Convert(repository.Update(converter.Convert(BookDTO)));
        }
    }
}
