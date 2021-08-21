using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace RestMethods.Hypermedia
{
    /// <summary>
    /// Fornece strings representando tipos de relacionamento.
    /// </summary>
    public sealed class RelationTypes
    {
        /// <summary>
        /// Nem sei o que é ainda.
        /// </summary>
        public static string Self => "self";
        /// <summary>
        /// Método Http GET, para obtenção de dados.
        /// </summary>
        public static string Get => "get";
        /// <summary>
        /// Método Http POST, para persistência de daddos.
        /// </summary>
        public static string Post => "post";
        /// <summary>
        /// Método Http PUT, para substituição de dados.
        /// </summary>
        public static string Put => "put";
        /// <summary>
        /// Método Http DELETE, para remoção de dados.
        /// </summary>
        public static string Delete => "delete";
        /// <summary>
        /// Método Http PATCH, para atualização parcial de dados.
        /// </summary>
        public static string Patch => "patch";
        /// <summary>
        /// 
        /// </summary>
        public static string Next => "next";
        /// <summary>
        /// 
        /// </summary>
        public static string Previous => "previous";
        /// <summary>
        /// 
        /// </summary>
        public static string First => "first";
        /// <summary>
        /// 
        /// </summary>
        public static string Last => "last";
    }
}
