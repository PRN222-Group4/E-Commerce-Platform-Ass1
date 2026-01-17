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



    /// <summary>
    /// DTO để tạo sản phẩm mới
    /// </summary>
    public class CreateProductDto
    {
        public Guid ShopId { get; set; }
        public Guid CategoryId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal BasePrice { get; set; }
        public string ImageUrl { get; set; } = string.Empty;
    }

    /// <summary>
    /// DTO hiển thị thông tin sản phẩm
    /// </summary>
    public class ProductDto
    {
        public Guid Id { get; set; }
        public Guid ShopId { get; set; }
        public Guid CategoryId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal BasePrice { get; set; }
        public string Status { get; set; } = string.Empty;
        public decimal AvgRating { get; set; }
        public string ImageUrl { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
        public string? CategoryName { get; set; }
        public string? ShopName { get; set; }
    }

    /// <summary>
    /// DTO cho Category
    /// </summary>
    public class CategoryDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
    }

    
}
