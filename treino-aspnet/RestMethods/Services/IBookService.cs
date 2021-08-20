using RestMethods.Data.DTO;
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
        /// Persiste um objeto <see cref="BookDTO"/>.
        /// </summary>
        /// <param name="BookDTO">Objeto a ser persistido.</param>
        /// <returns></returns>
        public BookDTO Create(BookDTO BookDTO);
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
        public BookDTO FindById(long id);
        /// <summary>
        /// Retorna uma lista de todas as <see cref="BookDTO"/>
        /// </summary>
        /// <returns></returns>
        public List<BookDTO> ListAll();
        /// <summary>
        /// Substitui um objeto <see cref="BookDTO"/>.
        /// </summary>
        /// <param name="BookDTO">Objeto a ser persistido.</param>
        /// <returns></returns>
        public BookDTO Update(BookDTO BookDTO);
        /// <summary>
        /// Remove uma <see cref="BookDTO"/> a partir do Id.
        /// </summary>
        /// <param name="id"></param>
        public void Delete(long id);
    }
}
