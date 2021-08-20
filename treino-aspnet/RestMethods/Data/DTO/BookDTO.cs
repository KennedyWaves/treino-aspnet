using RestMethods.Model.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RestMethods.Data.DTO
{
    public class BookDTO
    {
        /// <summary>
        /// Determina o identificador do objeto.
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Determina o autor do livro.
        /// </summary>
        public string Author { get; set;  }
        /// <summary>
        /// Determina o título do livro.
        /// </summary>
        public string Title {  get; set;  }
        /// <summary>
        /// Determina da data de lançamento do livro.
        /// </summary>
        public DateTime LaunchDate { get;set; }
        /// <summary>
        /// Determina o preço do livro.
        /// </summary>
        public decimal Price { get; set; }
    }
}
