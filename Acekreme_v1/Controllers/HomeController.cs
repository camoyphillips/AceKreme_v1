using Microsoft.AspNetCore.Mvc;

namespace AceKreme_v1.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index() => View();
        public IActionResult Privacy() => View();
        public IActionResult Error() => View();
    }
}
