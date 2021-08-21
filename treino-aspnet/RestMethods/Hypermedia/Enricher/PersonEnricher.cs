using Microsoft.AspNetCore.Mvc;
using RestMethods.Data.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestMethods.Hypermedia.Enricher
{
    public class PersonEnricher : ContentResponseEnricher<PersonDTO>
    {
        private readonly object _lock = new object();
        protected override Task EnrichModel(PersonDTO content, IUrlHelper urlHelper)
        {
            var path = "api/v1/person";
            string link = GetLink(content.Id, urlHelper, path);
            content.Links.Add(new HypermediaLink()
            {
                Action = HttpActionVerb.Get,
                Href = link,
                Rel = RelationTypes.Self,
                Type = ResponseTypeFormat.DefaultGet
            });
            content.Links.Add(new HypermediaLink()
            {
                Action = HttpActionVerb.Post,
                Href = link,
                Rel = RelationTypes.Self,
                Type = ResponseTypeFormat.DefaultPost
            });
            content.Links.Add(new HypermediaLink()
            {
                Action = HttpActionVerb.Put,
                Href = link,
                Rel = RelationTypes.Self,
                Type = ResponseTypeFormat.DefaultPut
            });
            content.Links.Add(new HypermediaLink()
            {
                Action = HttpActionVerb.Delete,
                Href = link,
                Rel = RelationTypes.Self,
                Type = "int"
            });
            return null;
        }

        private string GetLink(long id, IUrlHelper urlHelper, string path)
        {
            lock (_lock)
            {
                var url = new
                {
                    controller = path,
                    id = id
                };
                return new StringBuilder(urlHelper.Link("DefaultApi",url)).Replace("%2F","/").ToString();
            }
        }
    }
}
