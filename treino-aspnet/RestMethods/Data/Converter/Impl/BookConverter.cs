using RestMethods.Data.Converter.Contract;
using RestMethods.Data.DTO;
using RestMethods.Model;
using System.Collections.Generic;
using System.Linq;

namespace RestMethods.Data.Converter.Impl
{
    public class BookConverter : IConverter<BookDTO, Book>, IConverter<Book, BookDTO>
    {
        #region book/dto
        public Book Convert(BookDTO input)
        {
            if (input == null) return null;

            return new Book
            {
                Id = input.Id,
                Title = input.Title,
                Author = input.Author,
                LaunchDate = input.LaunchDate,
                Price = input.Price
            };
        }

        public List<Book> Convert(List<BookDTO> input)
        {
            return input.Select(item => Convert(item)).ToList();
        }
        #endregion
        #region dto/person
        public BookDTO Convert(Book input)
        {
            if (input == null) return null;

            return new BookDTO
            {
                Id = input.Id,
                Title = input.Title,
                Author = input.Author,
                LaunchDate = input.LaunchDate,
                Price = input.Price
            };
        }

        public List<BookDTO> Convert(List<Book> input)
        {
            return input.Select(item => Convert(item)).ToList();
        }
        #endregion
    }
}
