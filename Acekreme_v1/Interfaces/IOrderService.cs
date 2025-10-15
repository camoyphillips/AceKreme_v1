using AceKreme_v1.Dtos;
using AceKreme_v1.Models;

namespace AceKreme_v1.Interfaces
{
    public interface IOrderService
    {
        Task<ServiceResponse<IEnumerable<OrderDto>>> GetAllAsync();
        Task<ServiceResponse<OrderDto>> GetByIdAsync(int id);
        Task<ServiceResponse<OrderDto>> CreateAsync(OrderDto dto);
        Task<ServiceResponse<OrderDto>> UpdateAsync(OrderDto dto);
        Task<ServiceResponse<bool>> DeleteAsync(int id);
    }
}
