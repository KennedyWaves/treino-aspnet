using RestMethods.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace RestMethods.Services.Implementations
{
    public class PersonServiceImplementation : IPersonService
    {
        private int count;

        Person IPersonService.Create(Person person)
        {
            person.Id = IncrementAndGet();
            return person;
        }

        void IPersonService.Delete(long id)
        {

        }

        Person IPersonService.GetById(long id)
        {
            return new Person()
            {
                Id = id,
                FirstName = "Cuca",
                LastName = "Beludo",
                Address = "Meio Do Mundo-AP",
                Gender = Gender.Male
            };
        }

        List<Person> IPersonService.ListAll()
        {
            List<Person> persons = new List<Person>();
            for (int x = 0; x < 8; x++)
            {
                persons.Add(MockPerson());
            }
            return persons;
        }
        Person IPersonService.Update(Person person)
        {
            return person;
        }

        Person MockPerson()
        {
            return new Person()
            {
                Id = IncrementAndGet(),
                FirstName = "Cuca",
                LastName = "Beludo",
                Address = "Meio Do Mundo-AP",
                Gender = Gender.Male
            };
        }

        private long IncrementAndGet()
        {
            return Interlocked.Increment(ref count);
        }
    }
}