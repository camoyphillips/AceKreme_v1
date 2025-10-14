using Microsoft.AspNetCore.Mvc;

namespace Acekreme_v1.Controllers
{
    public class ProductPageController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
