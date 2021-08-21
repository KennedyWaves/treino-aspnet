using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace RestMethods.Hypermedia
{
    /// <summary>
    /// Fornece strings representando métodos HTTP.
    /// </summary>
    public sealed class HttpActionVerb
    {
        /// <summary>
        /// Método Http GET, para obtenção de dados.
        /// </summary>
        public static string Get => "GET";
        /// <summary>
        /// Método Http POST, para persistência de daddos.
        /// </summary>
        public static string Post => "POST";
        /// <summary>
        /// Método Http PUT, para substituição de dados.
        /// </summary>
        public static string Put => "PUT";
        /// <summary>
        /// Método Http DELETE, para remoção de dados.
        /// </summary>
        public static string Delete => "DELETE";
        /// <summary>
        /// Método Http PATCH, para atualização parcial de dados.
        /// </summary>
        public static string Patch => "PATCH";
    }
}
