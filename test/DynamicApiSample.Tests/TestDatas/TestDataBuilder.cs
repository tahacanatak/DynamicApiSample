using DynamicApiSample.EntityFrameworkCore;

namespace DynamicApiSample.Tests.TestDatas
{
    public class TestDataBuilder
    {
        private readonly DynamicApiSampleDbContext _context;

        public TestDataBuilder(DynamicApiSampleDbContext context)
        {
            _context = context;
        }

        public void Build()
        {
            //create test data here...
        }
    }
}