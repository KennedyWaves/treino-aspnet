using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RestMethods.Model
{
    /// <summary>
    /// Fornece opções de gênero tradicionais
    /// </summary>
    public enum Gender
    {
        /// <summary>
        /// Sexo masculino.
        /// </summary>
        Male=0,
        /// <summary>
        /// Sexo feminino.
        /// </summary>
        Female=1
    }
    [Table("person")]
    /// <summary>
    /// Representa uma pessoa natural.
    /// </summary>
    public class Person
    {
        [Column("id")]
        /// <summary>
        /// Determina o identificador do objeto
        /// </summary>
        public long Id { get; set; }
        [Column("first_name")]
        /// <summary>
        /// Determina o primeiro nome.
        /// </summary>
        public string FirstName { get;set; }
        [Column("last_name")]
        /// <summary>
        /// Determina o último nome.
        /// </summary>
        public string LastName { get;set; }
        [Column("address")]
        /// <summary>
        /// Determina o endereço postal.
        /// </summary>
        public string Address { get; set; }
        [Column("gender")]
        /// <summary>
        /// Determina o sexo.
        /// </summary>
        public string Gender{ get; set; }
    }
}
