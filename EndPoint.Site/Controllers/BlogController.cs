using Microsoft.AspNetCore.Mvc;

namespace EndPoint.Site.Controllers
{
    public class BlogController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
