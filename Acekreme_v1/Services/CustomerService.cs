using AceKreme_v1.Data;
using AceKreme_v1.Dtos;
using AceKreme_v1.Interfaces;
using AceKreme_v1.Models;
using Microsoft.EntityFrameworkCore;

namespace AceKreme_v1.Services
{
    public class CustomerService(ApplicationDbContext context) : ICustomerService
    {
        private readonly ApplicationDbContext _context = context;

        public async Task<ServiceResponse<IEnumerable<CustomerDto>>> GetAllAsync()
        {
            var customers = await _context.Customers
                .Select(c => new CustomerDto
                {
                    CustomerId = c.CustomerId,
                    Name = c.Name,
                    Email = c.Email,
                    Phone = c.Phone,
                    Address = c.Address
                }).ToListAsync();

            return new ServiceResponse<IEnumerable<CustomerDto>> { Data = customers };
        }

        public async Task<ServiceResponse<CustomerDto>> GetByIdAsync(int id)
        {
            var customer = await _context.Customers.FindAsync(id);
            if (customer == null)
                return new ServiceResponse<CustomerDto> { Success = false, Message = "Customer not found" };

            return new ServiceResponse<CustomerDto>
            {
                Data = new CustomerDto
                {
                    CustomerId = customer.CustomerId,
                    Name = customer.Name,
                    Email = customer.Email,
                    Phone = customer.Phone,
                    Address = customer.Address
                }
            };
        }

        public async Task<ServiceResponse<CustomerDto>> CreateAsync(CustomerDto dto)
        {
            var entity = new Customer
            {
                Name = dto.Name,
                Email = dto.Email,
                Phone = dto.Phone,
                Address = dto.Address
            };
            _context.Customers.Add(entity);
            await _context.SaveChangesAsync();
            dto.CustomerId = entity.CustomerId;
            return new ServiceResponse<CustomerDto> { Data = dto, Message = "Customer created" };
        }

        public async Task<ServiceResponse<CustomerDto>> UpdateAsync(CustomerDto dto)
        {
            var entity = await _context.Customers.FindAsync(dto.CustomerId);
            if (entity == null)
                return new ServiceResponse<CustomerDto> { Success = false, Message = "Not found" };

            entity.Name = dto.Name;
            entity.Email = dto.Email;
            entity.Phone = dto.Phone;
            entity.Address = dto.Address;

            await _context.SaveChangesAsync();
            return new ServiceResponse<CustomerDto> { Data = dto, Message = "Updated successfully" };
        }

        public async Task<ServiceResponse<bool>> DeleteAsync(int id)
        {
            var entity = await _context.Customers.FindAsync(id);
            if (entity == null)
                return new ServiceResponse<bool> { Success = false, Message = "Not found" };

            _context.Customers.Remove(entity);
            await _context.SaveChangesAsync();
            return new ServiceResponse<bool> { Data = true, Message = "Deleted" };
        }
    }
}
