using AceKreme_v1.Data;
using AceKreme_v1.Dtos;
using AceKreme_v1.Interfaces;
using AceKreme_v1.Models;
using Microsoft.EntityFrameworkCore;

namespace AceKreme_v1.Services
{
    public class ProductService : IProductService
    {
        private readonly ApplicationDbContext _context;

        public ProductService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ServiceResponse<IEnumerable<ProductDto>>> GetAllAsync()
        {
            var data = await _context.Products
                .Select(p => new ProductDto
                {
                    ProductId = p.ProductId,
                    Name = p.Name,
                    Price = p.Price,
                    Description = p.Description,
                    Stock = p.Stock,
                    ProductImagePath = p.ProductImagePath
                })
                .ToListAsync();

            return new ServiceResponse<IEnumerable<ProductDto>> { Data = data };
        }

        public async Task<ServiceResponse<ProductDto>> GetByIdAsync(int id)
        {
            var p = await _context.Products.FindAsync(id);
            if (p == null)
                return new ServiceResponse<ProductDto> { Success = false, Message = "Product not found." };

            var dto = new ProductDto
            {
                ProductId = p.ProductId,
                Name = p.Name,
                Price = p.Price,
                Description = p.Description,
                Stock = p.Stock,
                ProductImagePath = p.ProductImagePath
            };
            return new ServiceResponse<ProductDto> { Data = dto };
        }

        public async Task<ServiceResponse<ProductDto>> CreateAsync(ProductDto dto)
        {
            var entity = new Product
            {
                Name = dto.Name,
                Price = dto.Price,
                Description = dto.Description,
                Stock = dto.Stock,
                ProductImagePath = dto.ProductImagePath
            };
            _context.Products.Add(entity);
            await _context.SaveChangesAsync();

            dto.ProductId = entity.ProductId;
            return new ServiceResponse<ProductDto> { Data = dto, Message = "Product created." };
        }

        public async Task<ServiceResponse<ProductDto>> UpdateAsync(ProductDto dto)
        {
            var e = await _context.Products.FindAsync(dto.ProductId);
            if (e == null)
                return new ServiceResponse<ProductDto> { Success = false, Message = "Product not found." };

            e.Name = dto.Name;
            e.Price = dto.Price;
            e.Description = dto.Description;
            e.Stock = dto.Stock;
            e.ProductImagePath = dto.ProductImagePath;

            await _context.SaveChangesAsync();
            return new ServiceResponse<ProductDto> { Data = dto, Message = "Product updated." };
        }

        public async Task<ServiceResponse<bool>> DeleteAsync(int id)
        {
            var e = await _context.Products.FindAsync(id);
            if (e == null)
                return new ServiceResponse<bool> { Success = false, Message = "Product not found." };

            _context.Products.Remove(e);
            await _context.SaveChangesAsync();
            return new ServiceResponse<bool> { Data = true, Message = "Deleted." };
        }
    }
}
