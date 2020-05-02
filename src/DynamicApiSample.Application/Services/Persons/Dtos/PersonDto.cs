using System;
using Abp.Application.Services.Dto;

namespace DynamicApiSample.Appication.Services.Persons.Dtos
{
    public class PersonDto : EntityDto<Guid>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string City { get; set; }
    }
}