using Microsoft.AspNetCore.Mvc;

namespace Acekreme_v1.Controllers
{
    public class CustomerPageController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
