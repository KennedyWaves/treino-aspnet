using RestMethods.Model.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RestMethods.Model
{
    [Table("books")]
    public class Book:BaseEntity
    {
        [Column("author")]
        /// <summary>
        /// Determina o autor do livro.
        /// </summary>
        public string Author { get; set;  }
        [Column("title")]
        /// <summary>
        /// Determina o título do livro.
        /// </summary>
        public string Title {  get; set;  }
        [Column("launch_date")]
        /// <summary>
        /// Determina da data de lançamento do livro.
        /// </summary>
        public DateTime LaunchDate { get;set; }
        [Column("price")]
        /// <summary>
        /// Determina o preço do livro.
        /// </summary>
        public decimal price { get; set; }
    }
}
