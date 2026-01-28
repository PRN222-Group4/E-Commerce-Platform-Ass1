using System.Security.Claims;
using E_Commerce_Platform_Ass1.Service.Services.IServices;
using E_Commerce_Platform_Ass1.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce_Platform_Ass1.Web.Controllers
{
    [Authorize]
    public class ShopWalletController : Controller
    {
        private readonly IShopWalletService _shopWalletService;
        private readonly IShopService _shopService;

        public ShopWalletController(IShopWalletService shopWalletService, IShopService shopService)
        {
            _shopWalletService = shopWalletService;
            _shopService = shopService;
        }

        /// <summary>
        /// Hiển thị ví Shop với số dư và giao dịch gần đây
        /// </summary>
        public async Task<IActionResult> Index()
        {
            var userId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
            var shop = await _shopService.GetShopByUserIdAsync(userId);

            if (shop == null)
            {
                TempData["ErrorMessage"] = "Bạn chưa có shop.";
                return RedirectToAction("Register", "Shop");
            }

            var wallet = await _shopWalletService.GetOrCreateAsync(shop.Id);
            var transactions = await _shopWalletService.GetTransactionsAsync(shop.Id, 10);

            var viewModel = new ShopWalletViewModel
            {
                ShopId = shop.Id,
                ShopName = shop.ShopName ?? "Shop",
                Balance = wallet.Balance,
                RecentTransactions = transactions
            };

            return View(viewModel);
        }

        /// <summary>
        /// Xem tất cả lịch sử giao dịch
        /// </summary>
        public async Task<IActionResult> Transactions()
        {
            var userId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
            var shop = await _shopService.GetShopByUserIdAsync(userId);

            if (shop == null)
            {
                TempData["ErrorMessage"] = "Bạn chưa có shop.";
                return RedirectToAction("Register", "Shop");
            }

            var transactions = await _shopWalletService.GetTransactionsAsync(shop.Id, 100);

            ViewBag.ShopName = shop.ShopName;
            return View(transactions);
        }
    }
}
