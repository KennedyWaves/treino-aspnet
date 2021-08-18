using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RestMethods.Model.Base
{
    public class BaseEntity
    {
        [Column("id")]
        /// <summary>
        /// Determina o identificador do objeto.
        /// </summary>
        public int Id { get; set; }
    }
}
