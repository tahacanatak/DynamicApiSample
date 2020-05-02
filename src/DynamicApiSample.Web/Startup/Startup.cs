using System;
using Abp.AspNetCore;
using Abp.Castle.Logging.Log4Net;
using Abp.EntityFrameworkCore;
using Castle.Facilities.Logging;
using DynamicApiSample.EntityFrameworkCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace DynamicApiSample.Web.Startup {
    public class Startup {
        public IServiceProvider ConfigureServices (IServiceCollection services) {
            //Configure DbContext
            services.AddAbpDbContext<DynamicApiSampleDbContext> (options => {
                DbContextOptionsConfigurer.Configure (options.DbContextOptions, options.ConnectionString);
            });

            //your other code...

            services.AddSwaggerGen (options => {
                options.SwaggerDoc ("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "Dynamic Web Api ", Version = "v1" });
                options.DocInclusionPredicate ((docName, description) => true);
            });

            //your other code...

            services.AddControllersWithViews (options => {
             //   options.Filters.Add (new AutoValidateAntiforgeryTokenAttribute ());
            }).AddNewtonsoftJson ();

            //Configure Abp and Dependency Injection
            return services.AddAbp<DynamicApiSampleWebModule> (options => {
                //Configure Log4Net logging
                options.IocManager.IocContainer.AddFacility<LoggingFacility> (
                    f => f.UseAbpLog4Net ().WithConfig ("log4net.config")
                );
            });
        }

        public void Configure (IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory) {
            app.UseAbp (); //Initializes ABP framework.

            if (env.IsDevelopment ()) {
                app.UseDeveloperExceptionPage ();
                app.UseDatabaseErrorPage ();
            } else {
                app.UseExceptionHandler ("/Error");
            }

            app.UseSwagger ();

            app.UseSwaggerUI (options => {
                options.SwaggerEndpoint ("/swagger/v1/swagger.json", "Dynamic API V1");
            });

            app.UseStaticFiles ();
            app.UseRouting ();

            app.UseEndpoints (endpoints => {
                endpoints.MapControllerRoute ("default", "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}