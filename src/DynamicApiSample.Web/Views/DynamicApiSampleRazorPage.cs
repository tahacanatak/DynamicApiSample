using Abp.AspNetCore.Mvc.Views;

namespace DynamicApiSample.Web.Views
{
    public abstract class DynamicApiSampleRazorPage<TModel> : AbpRazorPage<TModel>
    {
        protected DynamicApiSampleRazorPage()
        {
            LocalizationSourceName = DynamicApiSampleConsts.LocalizationSourceName;
        }
    }
}
