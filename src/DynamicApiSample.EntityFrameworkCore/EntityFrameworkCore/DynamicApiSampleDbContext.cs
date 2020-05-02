using Abp.EntityFrameworkCore;
using DynamicApiSample.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace DynamicApiSample.EntityFrameworkCore
{
    public class DynamicApiSampleDbContext : AbpDbContext
    {
        //Add DbSet properties for your entities...
        public DbSet<Person> Persons {get; set;}
        public DynamicApiSampleDbContext(DbContextOptions<DynamicApiSampleDbContext> options) 
            : base(options)
        {

        }
    }
}
