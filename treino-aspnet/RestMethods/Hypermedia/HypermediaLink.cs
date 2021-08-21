using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestMethods.Hypermedia
{
    /// <summary>
    /// Representa os campos necessários para o padrão HATEOAS
    /// </summary>
    public class HypermediaLink
    {
        /// <summary>
        /// Determina o relacionamento.
        /// </summary>
        public string Rel { get; set; }
        /// <summary>
        /// Campo para a propriedade <see cref="href"/>
        /// </summary>
        private string href;
        /// <summary>
        /// Determina o link.
        /// </summary>
        public string Href
        {
            get
            {
                object _lock = new object();
                lock (_lock)
                {
                    StringBuilder sb = new StringBuilder(href);
                    return sb.Replace("%2F", "/").ToString();
                }
            }
            set { href = value; }
        }
        /// <summary>
        /// Determina o tipo da resposta.
        /// </summary>
        public string Type { get; set; }
        /// <summary>
        /// Determina o método HTTP a ser utilizado.
        /// </summary>
        public string Action { get; set; }

    }
}
