using Abp.Application.Services;

namespace DynamicApiSample
{
    /// <summary>
    /// Derive your application services from this class.
    /// </summary>
    public abstract class DynamicApiSampleAppServiceBase : ApplicationService
    {
        protected DynamicApiSampleAppServiceBase()
        {
            LocalizationSourceName = DynamicApiSampleConsts.LocalizationSourceName;
        }
    }
}