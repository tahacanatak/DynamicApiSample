using System.Threading.Tasks;
using DynamicApiSample.Web.Controllers;
using Shouldly;
using Xunit;

namespace DynamicApiSample.Web.Tests.Controllers
{
    public class HomeController_Tests: DynamicApiSampleWebTestBase
    {
        [Fact]
        public async Task Index_Test()
        {
            //Act
            var response = await GetResponseAsStringAsync(
                GetUrl<HomeController>(nameof(HomeController.Index))
            );

            //Assert
            response.ShouldNotBeNullOrEmpty();
        }
    }
}
