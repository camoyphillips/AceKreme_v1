using AceKreme_v1.Dtos;
using AceKreme_v1.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AceKreme_v1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _svc;
        public OrderController(IOrderService svc) => _svc = svc;

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
        public async Task<IActionResult> Create([FromBody] OrderDto dto)
        {
            var res = await _svc.CreateAsync(dto);
            return CreatedAtAction(nameof(Get), new { id = res.Data!.OrderId }, res);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] OrderDto dto)
        {
            if (id != dto.OrderId) return BadRequest();
            var res = await _svc.UpdateAsync(dto);
            if (!res.Success) return NotFound(res);
            return Ok(res);
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
