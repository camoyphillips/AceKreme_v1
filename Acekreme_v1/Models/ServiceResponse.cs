using Microsoft.AspNetCore.Mvc;

namespace Acekreme_v1.Models
{
    public class ServiceResponse : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
