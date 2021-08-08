using Microsoft.EntityFrameworkCore;
using RestMethods.Model;
using RestMethods.Model.Context;
using RestMethods.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace RestMethods.Repository.Implementations
{
    public class PersonRepositoryImplementation : IPersonRepository
    {
        private MySQLContext repository;

        public PersonRepositoryImplementation(MySQLContext context)
        {
            repository = context;
        }

        Person IPersonRepository.Create(Person person)
        {
            try
            {
                if (!Exists(person.Id))
                {
                    repository.Add(person);
                    repository.SaveChanges();
                }
                else
                {
                    throw new SystemException();
                }
            }
            catch (SystemException)
            {

            }
            return person;
        }

        void IPersonRepository.Delete(long id)
        {
            Person result = repository.Persons.SingleOrDefault(p => p.Id.Equals(id));
            if (result != null)
            {
                repository.Persons.Remove(result);
                repository.SaveChanges();
            }
        }

        Person IPersonRepository.FindById(long id)
        {
            return repository.Persons.SingleOrDefault(p => p.Id.Equals(id));
        }

        List<Person> IPersonRepository.ListAll()
        {
            return repository.Persons.ToList();
        }

        Person IPersonRepository.Replace(Person person)
        {
            try
            {
                if (Exists(person.Id))
                {
                    repository.Update(person);
                    repository.SaveChanges();
                }
                else
                {
                    throw new SystemException();
                }
            }
            catch (SystemException)
            {
                throw;
            }
            return person;

        }

        Person IPersonRepository.Update(Person person)
        {
            try
            {

            }
            catch (SystemException)
            {
                throw;
            }
            return person;
        }
        /// <summary>
        /// Verifica se o elemento já foi persistido.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Exists(long id)
        {
            return repository.Persons.Any(p => p.Id.Equals(id));
        }
    }
}