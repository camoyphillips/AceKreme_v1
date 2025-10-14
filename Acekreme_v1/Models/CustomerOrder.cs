using Microsoft.AspNetCore.Mvc;

namespace Acekreme_v1.Models
{
    public class CustomerOrder : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
