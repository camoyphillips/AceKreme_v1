using AceKreme_v1.Dtos;
using AceKreme_v1.Models;

namespace AceKreme_v1.Interfaces
{
    public interface IProductService
    {
        Task<ServiceResponse<IEnumerable<ProductDto>>> GetAllAsync();
        Task<ServiceResponse<ProductDto>> GetByIdAsync(int id);
        Task<ServiceResponse<ProductDto>> CreateAsync(ProductDto dto);
        Task<ServiceResponse<ProductDto>> UpdateAsync(ProductDto dto);
        Task<ServiceResponse<bool>> DeleteAsync(int id);
    }
}
