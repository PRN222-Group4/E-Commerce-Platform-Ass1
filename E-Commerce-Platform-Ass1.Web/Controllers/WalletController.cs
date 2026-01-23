using System.Security.Claims;
using E_Commerce_Platform_Ass1.Service.Services.IServices;
using E_Commerce_Platform_Ass1.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce_Platform_Ass1.Web.Controllers
{
    public class WalletController : Controller
    {
        private readonly IWalletService _walletService;

        public WalletController(IWalletService walletService)
        {
            _walletService = walletService;
        }

        public async Task<IActionResult> Index()
        {
            var userIdClaim = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (!Guid.TryParse(userIdClaim, out Guid userId))
            {
                return Unauthorized();
            }

            var walletDto = await _walletService.GetOrCreateAsync(userId);

            var vm = new WalletViewModel
            {
                Balance = walletDto.Balance,
                UpdatedAt = walletDto.UpdatedAt,
                LastChangeAmount = walletDto.LastChangeAmount,
                LastChangeType = walletDto.LastChangeType
            };

            return View(vm);
        }
    }
}
