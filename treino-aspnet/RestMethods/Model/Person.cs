using System;
using System.Collections.Generic;
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
    /// <summary>
    /// Representa uma pessoa natural.
    /// </summary>
    public class Person
    {
        /// <summary>
        /// Determina o identificador do objeto
        /// </summary>
        public long Id { get; set; }
        /// <summary>
        /// Determina o primeiro nome.
        /// </summary>
        public string FirstName { get;set; }
        /// <summary>
        /// Determina o último nome.
        /// </summary>
        public string LastName { get;set; }
        /// <summary>
        /// Determina o endereço postal.
        /// </summary>
        public string Address { get; set; }
        /// <summary>
        /// Determina o sexo.
        /// </summary>
        public Gender Gender{ get; set; }
    }
}
