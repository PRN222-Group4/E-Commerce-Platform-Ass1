using E_Commerce_Platform_Ass1.Data.Database.Entities;
using E_Commerce_Platform_Ass1.Data.Repositories.Interfaces;
using E_Commerce_Platform_Ass1.Service.Services.IServices;

namespace E_Commerce_Platform_Ass1.Service.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<List<Product>> GetAllProductAsync()
        {
            var products = await _productRepository.GetAllAsync();
            return products.ToList();
        }


        public async Task<Product?> GetProductWithVariantsAsync(Guid productId)
        {
            var product = await _productRepository.GetProductWithVariantsAsync(productId);
            return product;
        }
    }
}
