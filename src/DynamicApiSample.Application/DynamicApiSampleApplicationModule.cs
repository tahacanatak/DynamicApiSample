using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using DynamicApiSample.Appication.Services.Persons.Dtos;
using DynamicApiSample.Core.Models;

namespace DynamicApiSample
{
    [DependsOn(
        typeof(DynamicApiSampleCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class DynamicApiSampleApplicationModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(DynamicApiSampleApplicationModule).GetAssembly());
        }
        public override void PreInitialize()
        {
         Configuration.Modules.AbpAutoMapper().Configurators.Add(config => 
            {
                config.CreateMap<Person, PersonDto>();
                config.CreateMap<CreatePersonInput, Person>();
            });
        }
    }
}