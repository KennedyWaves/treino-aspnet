using RestMethods.Model;
using RestMethods.Model.Context;
using RestMethods.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace RestMethods.Services.Implementations
{
    public class PersonServiceImplementation : IPersonService
    {
        private IPersonRepository repository;

        public PersonServiceImplementation(IPersonRepository repo)
        {
            repository = repo;
        }

        Person IPersonService.Create(Person person)
        {
            return repository.Create(person);
        }

        void IPersonService.Delete(long id)
        {
            repository.Delete(id);
        }

        bool IPersonService.Exists(long id)
        {
            return true;
        }

        Person IPersonService.FindById(long id)
        {
            return repository.FindById(id);
        }

        List<Person> IPersonService.ListAll()
        {
            return repository.ListAll();
        }

        Person IPersonService.Replace(Person person)
        {
            return repository.Replace(person);
        }

        Person IPersonService.Update(Person person)
        {
            throw new NotImplementedException();
        }
    }
}