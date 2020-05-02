using Abp.AspNetCore;
using Abp.AspNetCore.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using DynamicApiSample.Configuration;
using DynamicApiSample.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.ApplicationParts;
using Microsoft.Extensions.Configuration;

namespace DynamicApiSample.Web.Startup {
    [DependsOn (
        typeof (DynamicApiSampleApplicationModule),
        typeof (DynamicApiSampleEntityFrameworkCoreModule),
        typeof (AbpAspNetCoreModule))]
    public class DynamicApiSampleWebModule : AbpModule {
        private readonly IConfigurationRoot _appConfiguration;

        public DynamicApiSampleWebModule (IHostingEnvironment env) {
            _appConfiguration = AppConfigurations.Get (env.ContentRootPath, env.EnvironmentName);
        }

        public override void PreInitialize () {
            Configuration.DefaultNameOrConnectionString = _appConfiguration.GetConnectionString (DynamicApiSampleConsts.ConnectionStringName);

            Configuration.Navigation.Providers.Add<DynamicApiSampleNavigationProvider> ();

          Configuration.Modules.AbpAspNetCore().CreateControllersForAppServices(typeof(DynamicApiSampleApplicationModule).Assembly, moduleName: "app", useConventionalHttpVerbs: true);

            Configuration.Modules.AbpAspNetCore ()
                .CreateControllersForAppServices (
                    typeof (DynamicApiSampleApplicationModule).GetAssembly ()
                );
        }

        public override void Initialize () {
            IocManager.RegisterAssemblyByConvention (typeof (DynamicApiSampleWebModule).GetAssembly ());
        }

        public override void PostInitialize () {
            IocManager.Resolve<ApplicationPartManager> ()
                .AddApplicationPartsIfNotAddedBefore (typeof (DynamicApiSampleWebModule).Assembly);
        }
    }
}