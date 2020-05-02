using DynamicApiSample.Configuration;
using DynamicApiSample.Web;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace DynamicApiSample.EntityFrameworkCore
{
    /* This class is needed to run EF Core PMC commands. Not used anywhere else */
    public class DynamicApiSampleDbContextFactory : IDesignTimeDbContextFactory<DynamicApiSampleDbContext>
    {
        public DynamicApiSampleDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<DynamicApiSampleDbContext>();
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());

            DbContextOptionsConfigurer.Configure(
                builder,
                configuration.GetConnectionString(DynamicApiSampleConsts.ConnectionStringName)
            );

            return new DynamicApiSampleDbContext(builder.Options);
        }
    }
}