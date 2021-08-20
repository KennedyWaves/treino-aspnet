using RestMethods.Data.Converter.Impl;
using RestMethods.Data.DTO;
using RestMethods.Model;
using RestMethods.Model.Context;
using RestMethods.Repository;
using RestMethods.Repository.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace RestMethods.Services.Implementations
{
    public class PersonService : IPersonService
    {
        private readonly IRepository<Person> repository;
        private readonly PersonConverter converter = new PersonConverter();

        public PersonService(IRepository<Person> repo)
        {
            repository = repo;
        }

        PersonDTO IPersonService.Create(PersonDTO person)
        {
            return converter.Convert(repository.Create(converter.Convert(person)));
        }

        void IPersonService.Delete(long id)
        {
            repository.Delete(id);
        }

        bool IPersonService.Exists(long id)
        {
            return true;
        }

        PersonDTO IPersonService.FindById(long id)
        {
            return converter.Convert(repository.FindById(id));
        }

        List<PersonDTO> IPersonService.ListAll()
        {
            return converter.Convert(repository.ListAll());
        }

        PersonDTO IPersonService.Update(PersonDTO person)
        {
            return converter.Convert(repository.Update(converter.Convert(person)));
        }
    }
}