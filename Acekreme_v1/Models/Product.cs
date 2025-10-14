using Microsoft.AspNetCore.Mvc;

namespace Acekreme_v1.Models
{
    public class Product : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
