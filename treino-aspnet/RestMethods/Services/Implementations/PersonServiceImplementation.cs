using RestMethods.Model;
using RestMethods.Model.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace RestMethods.Services.Implementations
{
    public class PersonServiceImplementation : IPersonService
    {
        private MySQLContext dbContext;

        public PersonServiceImplementation(MySQLContext context)
        {
            dbContext=context;
        }


        Person IPersonService.Create(Person person)
        {
            try
            {
                dbContext.Add(person);
                dbContext.SaveChanges();
            }
            catch(SystemException)
            {

            }
            return person;
        }

        void IPersonService.Delete(long id)
        {
            Person result = dbContext.Persons.SingleOrDefault(p => p.Id.Equals(id));
            if (result != null)
            {
                dbContext.Persons.Remove(result);
                dbContext.SaveChanges();
            }
        }
        /// <summary>
        /// Retorna um elemento a partir do id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Person IPersonService.GetById(long id)
        {
            return dbContext.Persons.SingleOrDefault(p=>p.Id.Equals(id));
        }
        /// <summary>
        /// Retorna todos os elementos.
        /// </summary>
        /// <returns></returns>
        List<Person> IPersonService.ListAll()
        {
            return dbContext.Persons.ToList();
        }
        /// <summary>
        /// Atualiza um elemento.
        /// </summary>
        /// <param name="person">Objeto com dados a serem persistidos.</param>
        /// <returns></returns>
        Person IPersonService.Replace(Person person)
        {
            try
            {
                if (!Exists(person.Id))
                {
                    return null;
                }
                else
                {
                    dbContext.Update(person);
                    dbContext.SaveChanges();
                }
            }
            catch (SystemException)
            {
                throw;
            }
            return person;
            
        }
        /// <summary>
        /// Determina se uma entrada já existe no banco.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        bool Exists(long id)
        {
            return dbContext.Persons.Any(p => p.Id.Equals(id));
        }
        /// <summary>
        /// Atualiza parcialmente um objeto.
        /// </summary>
        /// <param name="person"></param>
        /// <returns></returns>
        Person IPersonService.Update(Person person)
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
    }
}