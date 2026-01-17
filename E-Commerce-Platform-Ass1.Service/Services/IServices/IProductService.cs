using E_Commerce_Platform_Ass1.Data.Database.Entities;

namespace E_Commerce_Platform_Ass1.Service.Services.IServices
{
    public interface IProductService
    {
        Task<List<Product>> GetAllProductAsync();

        Task<Product?> GetProductWithVariantsAsync(Guid productId);
    }
}
