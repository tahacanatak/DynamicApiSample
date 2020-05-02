using Microsoft.EntityFrameworkCore;

namespace DynamicApiSample.EntityFrameworkCore
{
    public static class DbContextOptionsConfigurer
    {
        public static void Configure(
            DbContextOptionsBuilder<DynamicApiSampleDbContext> dbContextOptions, 
            string connectionString
            )
        {
            /* This is the single point to configure DbContextOptions for DynamicApiSampleDbContext */
            dbContextOptions.UseSqlServer(connectionString);
        }
    }
}
