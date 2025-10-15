using AceKreme_v1.Dtos;
using AceKreme_v1.Models;

namespace AceKreme_v1.Interfaces
{
    public interface ICustomerService
    {
        Task<ServiceResponse<IEnumerable<CustomerDto>>> GetAllAsync();
        Task<ServiceResponse<CustomerDto>> GetByIdAsync(int id);
        Task<ServiceResponse<CustomerDto>> CreateAsync(CustomerDto dto);
        Task<ServiceResponse<CustomerDto>> UpdateAsync(CustomerDto dto);
        Task<ServiceResponse<bool>> DeleteAsync(int id);
    }
}
