using System;
using System.Threading.Tasks;
using Abp.TestBase;
using DynamicApiSample.EntityFrameworkCore;
using DynamicApiSample.Tests.TestDatas;

namespace DynamicApiSample.Tests
{
    public class DynamicApiSampleTestBase : AbpIntegratedTestBase<DynamicApiSampleTestModule>
    {
        public DynamicApiSampleTestBase()
        {
            UsingDbContext(context => new TestDataBuilder(context).Build());
        }

        protected virtual void UsingDbContext(Action<DynamicApiSampleDbContext> action)
        {
            using (var context = LocalIocManager.Resolve<DynamicApiSampleDbContext>())
            {
                action(context);
                context.SaveChanges();
            }
        }

        protected virtual T UsingDbContext<T>(Func<DynamicApiSampleDbContext, T> func)
        {
            T result;

            using (var context = LocalIocManager.Resolve<DynamicApiSampleDbContext>())
            {
                result = func(context);
                context.SaveChanges();
            }

            return result;
        }

        protected virtual async Task UsingDbContextAsync(Func<DynamicApiSampleDbContext, Task> action)
        {
            using (var context = LocalIocManager.Resolve<DynamicApiSampleDbContext>())
            {
                await action(context);
                await context.SaveChangesAsync(true);
            }
        }

        protected virtual async Task<T> UsingDbContextAsync<T>(Func<DynamicApiSampleDbContext, Task<T>> func)
        {
            T result;

            using (var context = LocalIocManager.Resolve<DynamicApiSampleDbContext>())
            {
                result = await func(context);
                context.SaveChanges();
            }

            return result;
        }
    }
}
