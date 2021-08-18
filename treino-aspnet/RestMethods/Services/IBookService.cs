using RestMethods.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestMethods.Services
{
    public interface IBookService
    {
        /// <summary>
        /// Persiste um objeto <see cref="Book"/>.
        /// </summary>
        /// <param name="book">Objeto a ser persistido.</param>
        /// <returns></returns>
        public Book Create(Book book);
        /// <summary>
        /// Verifica se um objeto já foi persistido antes.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Exists(long id);
        /// <summary>
        /// Retorna uma pessoa a partir do Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Book FindById(long id);
        /// <summary>
        /// Retorna uma lista de todas as <see cref="Book"/>
        /// </summary>
        /// <returns></returns>
        public List<Book> ListAll();
        /// <summary>
        /// Substitui um objeto <see cref="Book"/>.
        /// </summary>
        /// <param name="book">Objeto a ser persistido.</param>
        /// <returns></returns>
        public Book Update(Book book);
        /// <summary>
        /// Remove uma <see cref="Book"/> a partir do Id.
        /// </summary>
        /// <param name="id"></param>
        public void Delete(long id);
    }
}
