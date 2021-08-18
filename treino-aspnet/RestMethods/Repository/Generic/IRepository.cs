using RestMethods.Model.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestMethods.Repository.Generic
{
    public interface IRepository<T> where T : BaseEntity
    {
        /// <summary>
        /// Persiste um objeto.
        /// </summary>
        /// <param name="item">Objeto a ser persistido.</param>
        /// <returns></returns>
        public T Create(T item);
        /// <summary>
        /// Retorna uma pessoa a partir do Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public T FindById(long id);
        /// <summary>
        /// Retorna uma lista de todas as <see cref="T"/>
        /// </summary>
        /// <returns></returns>
        public List<T> ListAll();
        /// <summary>
        /// Remove uma <see cref="T"/> a partir do Id.
        /// </summary>
        /// <param name="id"></param>
        public void Delete(long id);
        /// <summary>
        /// Atualiza um objeto.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public T Update(T item);
    }
}