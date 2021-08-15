﻿using RestMethods.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestMethods.Repository
{
    public interface IBookRepository
    {
        /// <summary>
        /// Persiste um objeto <see cref="Book"/>.
        /// </summary>
        /// <param name="book">Objeto a ser persistido.</param>
        /// <returns></returns>
        public Book Create(Book book);
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
        public Book Replace(Book book);
        /// <summary>
        /// Remove uma <see cref="Book"/> a partir do Id.
        /// </summary>
        /// <param name="id"></param>
        public void Delete(long id);
        /// <summary>
        /// Atualiza um objeto.
        /// </summary>
        /// <param name="book"></param>
        /// <returns></returns>
        public Book Update(Book book);
    }
}