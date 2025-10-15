using AceKreme_v1.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AceKreme_v1.Controllers
{
    public class ProductPageController : Controller
    {
        private readonly IProductService _svc;
        public ProductPageController(IProductService svc) => _svc = svc;

        public async Task<IActionResult> List()
        {
            var res = await _svc.GetAllAsync();
            return View(res.Data);
        }

        public async Task<IActionResult> Details(int id)
        {
            var res = await _svc.GetByIdAsync(id);
            if (!res.Success) return NotFound();
            return View(res.Data);
        }

        public IActionResult New() => View();

        [HttpPost]
        public async Task<IActionResult> New(Dtos.ProductDto dto)
        {
            if (!ModelState.IsValid) return View(dto);
            await _svc.CreateAsync(dto);
            return RedirectToAction(nameof(List));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var res = await _svc.GetByIdAsync(id);
            if (!res.Success) return NotFound();
            return View(res.Data);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, Dtos.ProductDto dto)
        {
            if (id != dto.ProductId) return BadRequest();
            if (!ModelState.IsValid) return View(dto);
            await _svc.UpdateAsync(dto);
            return RedirectToAction(nameof(List));
        }

        [HttpPost]
        public async Task<IActionResult> ConfirmDelete(int id)
        {
            await _svc.DeleteAsync(id);
            return RedirectToAction(nameof(List));
        }
    }
}
