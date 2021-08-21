using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestMethods.Hypermedia.Filters
{
    /// <summary>
    /// Executa a filtragem das respostas.
    /// </summary>
    public class HypermediaFilter : ResultFilterAttribute
    {
        private readonly HypermediaFilterOptions hypermediaFilterOptions;
        public HypermediaFilter(HypermediaFilterOptions hmfo)
        {
            hypermediaFilterOptions = hmfo;
        }
        /// <summary>
        /// Sobrescreve o método do evento de resposta.
        /// </summary>
        /// <param name="context"></param>
        public override void OnResultExecuting(ResultExecutingContext context)
        {
            this.TryEnrichResult(context);
            base.OnResultExecuting(context);
        }
        /// <summary>
        /// Tenta enriquecer a resposta.
        /// </summary>
        /// <param name="context"></param>
        private void TryEnrichResult(ResultExecutingContext context)
        {
            if (context.Result is OkObjectResult objectResult)
            {
                var enricher = this.hypermediaFilterOptions
                    .ContentResponseEnrichers.FirstOrDefault(x => x.CanEnrich(context));
                if(enricher!= null)
                {
                    Task.FromResult(enricher.Enrich(context));
                }
            }
        }
    }
}
