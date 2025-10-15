using AceKreme_v1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace AceKreme_v1.Controllers
{
    public class CheckoutController(IOptions<PayPalSettings> pp, ILogger<CheckoutController> logger) : Controller
    {
        private readonly PayPalSettings _paypal = pp.Value;
        private readonly ILogger<CheckoutController> _logger = logger;

        public IActionResult Index()
        {
            ViewBag.PayPalClientId = _paypal.ClientId; 
            ViewBag.Currency = "CAD";
            return View();
        }

        public IActionResult Success() => View();
    }
}
