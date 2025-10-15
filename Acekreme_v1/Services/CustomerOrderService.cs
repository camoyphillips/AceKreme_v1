using AceKreme_v1.Data;
using AceKreme_v1.Dtos;
using AceKreme_v1.Interfaces;
using AceKreme_v1.Models;
using Microsoft.EntityFrameworkCore;

namespace AceKreme_v1.Services
{
    public class CustomerOrderService : ICustomerOrderService
    {
        private readonly ApplicationDbContext _context;

        public CustomerOrderService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ServiceResponse<IEnumerable<CustomerOrderDto>>> GetAllAsync()
        {
            var data = await _context.CustomerOrders
                .Select(co => new CustomerOrderDto
                {
                    CustomerOrderId = co.CustomerOrderId,
                    CustomerId = co.CustomerId,
                    OrderId = co.OrderId,
                    PaymentMethod = co.PaymentMethod,
                    TransactionId = co.TransactionId
                }).ToListAsync();

            return new ServiceResponse<IEnumerable<CustomerOrderDto>> { Data = data };
        }

        public async Task<ServiceResponse<CustomerOrderDto>> GetByIdAsync(int id)
        {
            var co = await _context.CustomerOrders.FindAsync(id);
            if (co == null)
                return new ServiceResponse<CustomerOrderDto> { Success = false, Message = "Not found." };

            var dto = new CustomerOrderDto
            {
                CustomerOrderId = co.CustomerOrderId,
                CustomerId = co.CustomerId,
                OrderId = co.OrderId,
                PaymentMethod = co.PaymentMethod,
                TransactionId = co.TransactionId
            };
            return new ServiceResponse<CustomerOrderDto> { Data = dto };
        }

        public async Task<ServiceResponse<CustomerOrderDto>> CreateAsync(CustomerOrderDto dto)
        {
            // Validate referenced entities
            var cust = await _context.Customers.FindAsync(dto.CustomerId);
            var ord = await _context.Orders.FindAsync(dto.OrderId);
            if (cust == null || ord == null)
                return new ServiceResponse<CustomerOrderDto> { Success = false, Message = "Customer or Order not found." };

            var entity = new CustomerOrder
            {
                CustomerId = dto.CustomerId,
                OrderId = dto.OrderId,
                PaymentMethod = dto.PaymentMethod,
                TransactionId = dto.TransactionId
            };

            _context.CustomerOrders.Add(entity);
            await _context.SaveChangesAsync();

            dto.CustomerOrderId = entity.CustomerOrderId;
            return new ServiceResponse<CustomerOrderDto> { Data = dto, Message = "CustomerOrder created." };
        }

        public async Task<ServiceResponse<bool>> DeleteAsync(int id)
        {
            var co = await _context.CustomerOrders.FindAsync(id);
            if (co == null)
                return new ServiceResponse<bool> { Success = false, Message = "Not found." };

            _context.CustomerOrders.Remove(co);
            await _context.SaveChangesAsync();
            return new ServiceResponse<bool> { Data = true, Message = "Deleted." };
        }
    }
}
