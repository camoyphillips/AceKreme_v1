using Microsoft.AspNetCore.Mvc;

namespace Acekreme_v1.Interfaces
{
    public class ICustomerOrderService : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
