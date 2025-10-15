using AceKreme_v1.Data;
using AceKreme_v1.Dtos;
using AceKreme_v1.Interfaces;
using AceKreme_v1.Models;
using Microsoft.EntityFrameworkCore;

namespace AceKreme_v1.Services
{
    public class OrderService : IOrderService
    {
        private readonly ApplicationDbContext _context;

        public OrderService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ServiceResponse<IEnumerable<OrderDto>>> GetAllAsync()
        {
            var data = await _context.Orders
                .Select(o => new OrderDto
                {
                    OrderId = o.OrderId,
                    OrderDate = o.OrderDate,
                    TotalAmount = o.TotalAmount,
                    Status = o.Status
                })
                .ToListAsync();
            return new ServiceResponse<IEnumerable<OrderDto>> { Data = data };
        }

        public async Task<ServiceResponse<OrderDto>> GetByIdAsync(int id)
        {
            var o = await _context.Orders.FindAsync(id);
            if (o == null)
                return new ServiceResponse<OrderDto> { Success = false, Message = "Order not found." };

            var dto = new OrderDto
            {
                OrderId = o.OrderId,
                OrderDate = o.OrderDate,
                TotalAmount = o.TotalAmount,
                Status = o.Status
            };
            return new ServiceResponse<OrderDto> { Data = dto };
        }

        public async Task<ServiceResponse<OrderDto>> CreateAsync(OrderDto dto)
        {
            var entity = new Order
            {
                OrderDate = dto.OrderDate == default ? DateTime.UtcNow : dto.OrderDate,
                TotalAmount = dto.TotalAmount,
                Status = dto.Status
            };
            _context.Orders.Add(entity);
            await _context.SaveChangesAsync();

            dto.OrderId = entity.OrderId;
            return new ServiceResponse<OrderDto> { Data = dto, Message = "Order created." };
        }

        public async Task<ServiceResponse<OrderDto>> UpdateAsync(OrderDto dto)
        {
            var e = await _context.Orders.FindAsync(dto.OrderId);
            if (e == null)
                return new ServiceResponse<OrderDto> { Success = false, Message = "Order not found." };

            e.OrderDate = dto.OrderDate;
            e.TotalAmount = dto.TotalAmount;
            e.Status = dto.Status;

            await _context.SaveChangesAsync();
            return new ServiceResponse<OrderDto> { Data = dto, Message = "Order updated." };
        }

        public async Task<ServiceResponse<bool>> DeleteAsync(int id)
        {
            var e = await _context.Orders.FindAsync(id);
            if (e == null)
                return new ServiceResponse<bool> { Success = false, Message = "Order not found." };

            _context.Orders.Remove(e);
            await _context.SaveChangesAsync();
            return new ServiceResponse<bool> { Data = true, Message = "Deleted." };
        }
    }
}
