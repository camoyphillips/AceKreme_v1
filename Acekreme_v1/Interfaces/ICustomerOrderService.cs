using AceKreme_v1.Dtos;
using AceKreme_v1.Models;

namespace AceKreme_v1.Interfaces
{
    public interface ICustomerOrderService
    {
        Task<ServiceResponse<IEnumerable<CustomerOrderDto>>> GetAllAsync();
        Task<ServiceResponse<CustomerOrderDto>> GetByIdAsync(int id);
        Task<ServiceResponse<CustomerOrderDto>> CreateAsync(CustomerOrderDto dto);
        Task<ServiceResponse<bool>> DeleteAsync(int id);
    }
}
