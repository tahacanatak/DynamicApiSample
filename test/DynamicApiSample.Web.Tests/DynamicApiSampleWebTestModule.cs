using Abp.AspNetCore.TestBase;
using Abp.Modules;
using Abp.Reflection.Extensions;
using DynamicApiSample.Web.Startup;
namespace DynamicApiSample.Web.Tests
{
    [DependsOn(
        typeof(DynamicApiSampleWebModule),
        typeof(AbpAspNetCoreTestBaseModule)
        )]
    public class DynamicApiSampleWebTestModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.UnitOfWork.IsTransactional = false; //EF Core InMemory DB does not support transactions.
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(DynamicApiSampleWebTestModule).GetAssembly());
        }
    }
}