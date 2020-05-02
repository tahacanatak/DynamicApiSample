using Abp.AspNetCore.Mvc.Controllers;

namespace DynamicApiSample.Web.Controllers
{
    public abstract class DynamicApiSampleControllerBase: AbpController
    {
        protected DynamicApiSampleControllerBase()
        {
            LocalizationSourceName = DynamicApiSampleConsts.LocalizationSourceName;
        }
    }
}