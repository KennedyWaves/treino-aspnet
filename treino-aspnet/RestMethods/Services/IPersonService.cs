using RestMethods.Data.DTO;
using RestMethods.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestMethods.Services
{
    public interface IPersonService
    {
        /// <summary>
        /// Persiste um objeto <see cref="PersonDTO"/>.
        /// </summary>
        /// <param name="person">Objeto a ser persistido.</param>
        /// <returns></returns>
        public PersonDTO Create(PersonDTO person);
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
        public PersonDTO FindById(long  id);
        /// <summary>
        /// Retorna uma lista de todas as <see cref="Person"/>
        /// </summary>
        /// <returns></returns>
        public List<PersonDTO> ListAll();
        /// <summary>
        /// Remove uma <see cref="Person"/> a partir do Id.
        /// </summary>
        /// <param name="id"></param>
        public void Delete(long id);
        /// <summary>
        /// Atualiza um objeto.
        /// </summary>
        /// <param name="person"></param>
        /// <returns></returns>
        public PersonDTO Update(PersonDTO person);
    }
}
