using RestMethods.Model.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RestMethods.Data.DTO
{
    public class PersonDTO
    {
        /// <summary>
        /// Determina o identificador do objeto.
        /// </summary>
        public int Id { get; set; }
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
        public string Gender{ get; set; }
    }
}
