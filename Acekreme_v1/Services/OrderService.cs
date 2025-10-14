using Microsoft.AspNetCore.Mvc;

namespace Acekreme_v1.Services
{
    public class OrderService : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
