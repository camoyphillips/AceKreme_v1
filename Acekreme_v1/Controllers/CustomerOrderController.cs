using AceKreme_v1.Dtos;
using AceKreme_v1.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AceKreme_v1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerOrderController : ControllerBase
    {
        private readonly ICustomerOrderService _svc;
        public CustomerOrderController(ICustomerOrderService svc) => _svc = svc;

        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _svc.GetAllAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var res = await _svc.GetByIdAsync(id);
            if (!res.Success) return NotFound(res);
            return Ok(res);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CustomerOrderDto dto)
        {
            var res = await _svc.CreateAsync(dto);
            if (!res.Success) return BadRequest(res);
            return CreatedAtAction(nameof(Get), new { id = res.Data!.CustomerOrderId }, res);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var res = await _svc.DeleteAsync(id);
            if (!res.Success) return NotFound(res);
            return Ok(res);
        }
    }
}
