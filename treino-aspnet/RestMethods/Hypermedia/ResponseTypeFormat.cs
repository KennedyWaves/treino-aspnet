using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestMethods.Hypermedia
{
    /// <summary>
    /// Fornece string representando formatos de tipos de relacionamento.
    /// </summary>
    public sealed class ResponseTypeFormat
    {
        /// <summary>
        /// Formato padrão do método GET.
        /// </summary>
        public static string DefaultGet => "application/json";
        /// <summary>
        /// Formato padrão do método POST.
        /// </summary>
        public static string DefaultPost => "application/json";
        /// <summary>
        /// Formato padrão do método PUT.
        /// </summary>
        public static string DefaultPut => "application/json";
        /// <summary>
        /// Formato padrão do método PATCH.
        /// </summary>
        public static string DefaultPatch => "application/json";
        /// <summary>
        /// Formato padrão do método DELETE.
        /// </summary>
        public static string DefaultDelete => "application/json";
    }
}
