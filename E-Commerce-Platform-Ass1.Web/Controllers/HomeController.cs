using System.Diagnostics;
using E_Commerce_Platform_Ass1.Service.Services.IServices;
using E_Commerce_Platform_Ass1.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce_Platform_Ass1.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProductService _productService;

        public HomeController(ILogger<HomeController> logger, IProductService productService)
        {
            _logger = logger;
            _productService = productService;
        }

        public async Task<IActionResult> Index()
        {
            var products = await _productService.GetAllProductsAsync();
            var viewModel = new HomeIndexViewModel
            {
                Products = products
                    .Select(p => new HomeProductItemViewModel
                    {
                        Id = p.Id,
                        Name = p.Name,
                        Description = p.Description,
                        BasePrice = p.BasePrice,
                        ImageUrl = p.ImageUrl,
                        AvgRating = p.AvgRating,
                        ShopName = p.ShopName,
                        CategoryName = p.CategoryName,
                    })
                    .ToList(),
            };
            return View(viewModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(
                new ErrorViewModel
                {
                    RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier,
                }
            );
        }
    }
}
