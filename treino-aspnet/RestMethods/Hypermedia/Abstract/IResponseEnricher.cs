using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestMethods.Hypermedia.Abstract
{
    public interface IResponseEnricher
    {
        /// <summary>
        /// Verifica se é possível enriquecer resposta com padrão HATEOAS
        /// </summary>
        /// <param name="context">Contexto a ser enriquecido.</param>
        /// <returns>Retorna <see langword="true"/> se for possível enriquecer.<br/>
        /// Retorna <see langword="false"/> se não for possível enriquecer.
        /// </returns>
        bool CanEnrich(ResultExecutingContext context);
        /// <summary>
        /// Enrique as respostas válidas da API através do padrão HATEOAS
        /// </summary>
        /// <param name="context">Contexto a ser enriquecido.</param>
        /// <returns>Contexto enriquecido.</returns>
        Task Enrich(ResultExecutingContext context);
    }
}
