using Abp.EntityFrameworkCore;
using Abp.Modules;
using Abp.Reflection.Extensions;

namespace DynamicApiSample.EntityFrameworkCore
{
    [DependsOn(
        typeof(DynamicApiSampleCoreModule), 
        typeof(AbpEntityFrameworkCoreModule))]
    public class DynamicApiSampleEntityFrameworkCoreModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(DynamicApiSampleEntityFrameworkCoreModule).GetAssembly());
        }
    }
}