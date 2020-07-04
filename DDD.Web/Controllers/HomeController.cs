using Microsoft.AspNetCore.Mvc;

namespace DDD.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index() => View("Index");
    }
}
