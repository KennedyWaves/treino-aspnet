using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.Routing;
using RestMethods.Abstract.Hypermedia;
using RestMethods.Hypermedia.Abstract;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestMethods.Hypermedia
{
    public abstract class ContentResponseEnricher<T> : IResponseEnricher where T : ISupportHypermedia
    {
        public ContentResponseEnricher()
        {

        }

        protected abstract Task EnrichModel(T content, IUrlHelper urlHelper);

        bool IResponseEnricher.CanEnrich(ResultExecutingContext context)
        {
            if (context.Result is OkObjectResult okobjresult)
            {
                return CanEnrich(okobjresult.Value.GetType());
            }
            return false;
        }

        bool CanEnrich(Type contentType)
        {
            return contentType == typeof(T) || contentType == typeof(List<T>);
        }

        public async Task Enrich(ResultExecutingContext response)
        {
            var urlHelper = new UrlHelperFactory().GetUrlHelper(response);
            if (response.Result is OkObjectResult okobjresult)
            {
                if (okobjresult.Value is T model)
                {
                    await EnrichModel(model, urlHelper);
                }
                else if (okobjresult.Value is List<T> models)
                {
                    ConcurrentBag<T> bag = new ConcurrentBag<T>(models);
                    Parallel.ForEach(bag, element =>
                    {
                        EnrichModel(element, urlHelper);
                    }
                    );
                }
            }
            await Task.FromResult<object>(null);
        }
    }
}
