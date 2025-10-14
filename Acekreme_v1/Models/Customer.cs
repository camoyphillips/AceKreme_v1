using Microsoft.AspNetCore.Mvc;

namespace Acekreme_v1.Models
{
    public class Customer : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
