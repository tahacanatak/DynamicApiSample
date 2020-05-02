using System;
using System.Threading.Tasks;
using Abp.Application.Services;
using DynamicApiSample.Appication.Services.Persons.Dtos;

namespace DynamicApiSample.Appication.Services.Persons
{
    public interface IPersonAppService : IApplicationService
    {
        Task<PersonDto> GetPersonAsync(Guid id);
        Task<PersonDto> CreatePersonAsync(CreatePersonInput input);
    }
}