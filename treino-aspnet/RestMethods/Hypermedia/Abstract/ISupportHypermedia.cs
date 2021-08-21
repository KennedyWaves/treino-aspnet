using RestMethods.Hypermedia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestMethods.Abstract.Hypermedia
{
    public interface ISupportHypermedia
    {
        /// <summary>
        /// Fornece os links relacionados aos elementos de Hypermidia.
        /// </summary>
        List<HypermediaLink> Links { get; set; }
    }
}
