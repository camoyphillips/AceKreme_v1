using AceKreme_v1.Dtos;
using AceKreme_v1.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AceKreme_v1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _svc;
        public CustomerController(ICustomerService svc) => _svc = svc;

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var res = await _svc.GetAllAsync();
            if (!res.Success) return BadRequest(res);
            return Ok(res);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var res = await _svc.GetByIdAsync(id);
            if (!res.Success) return NotFound(res);
            return Ok(res);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CustomerDto dto)
        {
            var res = await _svc.CreateAsync(dto);
            if (!res.Success) return BadRequest(res);
            return CreatedAtAction(nameof(Get), new { id = res.Data!.CustomerId }, res);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] CustomerDto dto)
        {
            if (id != dto.CustomerId) return BadRequest();
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
