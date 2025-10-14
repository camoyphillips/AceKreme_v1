using Microsoft.AspNetCore.Mvc;

namespace Acekreme_v1.Services
{
    public class CustomerService : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
