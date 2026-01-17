using E_Commerce_Platform_Ass1.Service.DTOs;
using E_Commerce_Platform_Ass1.Service.Models;

namespace E_Commerce_Platform_Ass1.Service.Services.IServices
{
    /// <summary>
    /// Service interface cho quản lý sản phẩm
    /// </summary>
    public interface IProductService
    {
        /// <summary>
        /// Tạo sản phẩm mới
        /// </summary>
        Task<ServiceResult<Guid>> CreateProductAsync(CreateProductDto dto);

        /// <summary>
        /// Lấy danh sách sản phẩm theo ShopId
        /// </summary>
        Task<ServiceResult<List<ProductDto>>> GetByShopIdAsync(Guid shopId);

        /// <summary>
        /// Lấy sản phẩm theo Id
        /// </summary>
        Task<ServiceResult<ProductDto>> GetByIdAsync(Guid productId);

        /// <summary>
        /// Lấy tất cả danh mục active
        /// </summary>
        Task<List<CategoryDto>> GetAllCategoriesAsync();
    }
}
