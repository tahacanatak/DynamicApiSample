using System;
using System.Threading.Tasks;
using Abp.Domain.Repositories;
using Abp.ObjectMapping;
using DynamicApiSample.Appication.Services.Persons.Dtos;
using DynamicApiSample.Core.Models;

namespace DynamicApiSample.Appication.Services.Persons
{
    public class PersonAppService : IPersonAppService
    {
        private readonly IRepository<Person, Guid> _personRepository;
        private readonly IObjectMapper _objectMapper;

    
        public PersonAppService(IRepository<Person,Guid> personRepository,IObjectMapper objectMapper)
        {
            _personRepository = personRepository;
            _objectMapper = objectMapper;
        }

        public async Task<PersonDto> GetPersonAsync(Guid id)
        {
            var person = await _personRepository.GetAsync(id);

            return _objectMapper.Map<PersonDto>(person);
        }
        public async Task<PersonDto> CreatePersonAsync(CreatePersonInput input)
        {
            var person = new Person {
                FirstName = input.FirstName,
                LastName = input.LastName,
                Email = input.Email,
                City = input.City
            };
            var newPerson = await _personRepository.InsertAsync(person);
            return _objectMapper.Map<PersonDto>(newPerson);
        }

    }
}