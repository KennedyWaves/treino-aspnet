using Microsoft.EntityFrameworkCore;
using RestMethods.Model.Base;
using RestMethods.Model.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestMethods.Repository.Generic
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private MySQLContext repository;
        private DbSet<T> dataset;
        public Repository(MySQLContext context)
        {
            repository = context;
            dataset = context.Set<T>();
        }
        public T Create(T item)
        {
            try
            {
                if (!Exists(item.Id))
                {
                    dataset.Add(item);
                    repository.SaveChanges();
                    return item;
                }
                else
                {
                    return null;
                }
            }
            catch (SystemException)
            {
                throw;
            }
        }

        public void Delete(long id)
        {
            try
            {
                T result = FindById(id);
                if (result!=null)
                {
                    dataset.Remove(result);
                    repository.SaveChanges();
                }
            }
            catch (SystemException)
            {
                throw;
            }
        }

        public T FindById(long id)
        {
            return dataset.SingleOrDefault(p => p.Id==id);
        }

        public List<T> ListAll()
        {
            return dataset.ToList();
        }

        public T Update(T item)
        {
            try
            {
                T result = FindById(item.Id);
                if (result != null)
                {
                    repository.Entry(result).CurrentValues.SetValues(item);
                    repository.SaveChanges();
                    return item;
                }
                else
                {
                    return null;
                }
            }
            catch (SystemException)
            {
                throw;
            }
        }
        /// <summary>
        /// Verifica se o elemento já foi persistido.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Exists(long id)
        {
            return dataset.Any(p => p.Id.Equals(id));
        }
    }
}
