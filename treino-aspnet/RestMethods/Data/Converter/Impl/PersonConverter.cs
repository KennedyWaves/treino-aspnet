using RestMethods.Data.Converter.Contract;
using RestMethods.Data.DTO;
using RestMethods.Model;
using System.Collections.Generic;
using System.Linq;

namespace RestMethods.Data.Converter.Impl
{
    public class PersonConverter : IConverter<PersonDTO, Person>, IConverter<Person, PersonDTO>
    {
        #region person/dto
        public Person Convert(PersonDTO input)
        {
            if (input == null) return null;

            return new Person
            {
                Id = input.Id,
                FirstName = input.FirstName,
                LastName = input.LastName,
                Address = input.Address,
                Gender = input.Gender
            };
        }

        public List<Person> Convert(List<PersonDTO> input)
        {
            return input.Select(item => Convert(item)).ToList();
        }
        #endregion
        #region dto/person
        public PersonDTO Convert(Person input)
        {
            if (input == null) return null;

            return new PersonDTO
            {
                Id = input.Id,
                FirstName = input.FirstName,
                LastName = input.LastName,
                Address = input.Address,
                Gender = input.Gender
            };
        }

        public List<PersonDTO> Convert(List<Person> input)
        {
            return input.Select(item => Convert(item)).ToList();
        }
        #endregion
    }
}
