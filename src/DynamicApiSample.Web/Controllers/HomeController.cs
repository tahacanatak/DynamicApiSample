using Microsoft.AspNetCore.Mvc;

namespace DynamicApiSample.Web.Controllers
{
    public class HomeController : DynamicApiSampleControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }
    }
}