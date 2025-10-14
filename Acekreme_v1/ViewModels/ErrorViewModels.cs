using Microsoft.AspNetCore.Mvc;

namespace Acekreme_v1.ViewModels
{
    public class ErrorViewModels : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
