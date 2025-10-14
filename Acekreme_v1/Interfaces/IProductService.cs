using Microsoft.AspNetCore.Mvc;

namespace Acekreme_v1.Interfaces
{
    public class IProductService : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
