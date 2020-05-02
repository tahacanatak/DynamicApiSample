using Abp.Modules;
using Abp.Reflection.Extensions;
using DynamicApiSample.Localization;

namespace DynamicApiSample
{
    public class DynamicApiSampleCoreModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Auditing.IsEnabledForAnonymousUsers = true;

            DynamicApiSampleLocalizationConfigurer.Configure(Configuration.Localization);
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(DynamicApiSampleCoreModule).GetAssembly());
        }
    }
}