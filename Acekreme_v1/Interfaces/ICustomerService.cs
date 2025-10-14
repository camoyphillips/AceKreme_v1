using Microsoft.AspNetCore.Mvc;

namespace Acekreme_v1.Interfaces
{
    public class ICustomerService : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
