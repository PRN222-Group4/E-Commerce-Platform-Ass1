using System.Security.Claims;
using E_Commerce_Platform_Ass1.Service.Services;
using E_Commerce_Platform_Ass1.Service.Services.IServices;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce_Platform_Ass1.Web.Controllers
{
    public class PaymentController : Controller
    {
        private readonly IMomoService _momoService;
        private readonly ICartService _cartService;
        private readonly IWalletService _walletService;

        public PaymentController(IMomoService momoService, ICartService cartService, IWalletService walletService)
        {
            _momoService = momoService;
            _cartService = cartService;
            _walletService = walletService;
        }

        [HttpPost]
        public async Task<IActionResult> PayWithMomo(string shippingAddress, string selectedCartItemIds)
        {
            if (string.IsNullOrWhiteSpace(selectedCartItemIds))
            {
                TempData["Error"] = "Vui lòng chọn sản phẩm để thanh toán";
                return RedirectToAction("Index", "Cart");
            }

            var cartItemIds = selectedCartItemIds
                .Split(',')
                .Select(Guid.Parse)
                .ToList();

            var selectedItems = await _cartService.GetCartItemsByIdsAsync(cartItemIds);

            var totalAmount = selectedItems.Sum(x => x.Quantity * x.ProductVariant.Price);

            if (string.IsNullOrWhiteSpace(shippingAddress))
            {
                TempData["Error"] = "Vui lòng nhập địa chỉ giao hàng";
                return RedirectToAction("Index", "Cart");
            }

            var userId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));

            var cart = await _cartService.GetCartUserAsync(userId);

            if (cart == null || !cart.Items.Any())
            {
                TempData["Error"] = "Giỏ hàng trống";
                return RedirectToAction("Index", "Cart");
            }

            if (totalAmount <= 0)
            {
                TempData["Error"] = "Số tiền không hợp lệ";
                return RedirectToAction("Index", "Cart");
            }

            // ✅ Lấy số dư ví của người dùng
            var walletDto = await _walletService.GetOrCreateAsync(userId);
            decimal walletBalance = walletDto?.Balance ?? 0;

            decimal walletUsed = 0;
            decimal momoAmount = 0;

            // ✅ Logic thanh toán hybrid
            if (walletBalance >= totalAmount)
            {
                // Trường hợp 1: Ví đủ tiền → chỉ dùng ví
                walletUsed = totalAmount;
                momoAmount = 0;
            }
            else
            {
                // Trường hợp 2: Ví không đủ → dùng hết ví + Momo cho phần còn lại
                walletUsed = walletBalance;
                momoAmount = totalAmount - walletBalance;
            }

            // ✅ Lưu vào Session
            HttpContext.Session.SetString("ShippingAddress", shippingAddress);
            HttpContext.Session.SetString("SelectedCartItemIds", selectedCartItemIds);
            HttpContext.Session.SetString("WalletUsed", walletUsed.ToString());
            HttpContext.Session.SetString("MomoAmount", momoAmount.ToString());

            // ✅ Nếu cần thanh toán qua Momo
            if (momoAmount > 0)
            {
                long amount = (long)momoAmount;

                var payUrl = await _momoService.CreatePaymentAsync(
                    amount,
                    "Thanh toán đơn hàng");

                if (string.IsNullOrEmpty(payUrl))
                {
                    TempData["Error"] = "Thanh toán MoMo thất bại";
                    return RedirectToAction("Index", "Cart");
                }

                return Redirect(payUrl);
            }
            else
            {
                // ✅ Nếu chỉ dùng ví (không cần Momo) → chuyển thẳng đến callback
                return RedirectToAction("PaymentCallBack", "Checkout", new
                {
                    resultCode = 0,
                    message = "Thanh toán bằng ví thành công",
                    orderId = Guid.NewGuid().ToString(),
                    transId = ""
                });
            }
        }

        [HttpGet]
        public IActionResult Result()
        {
            return View();
        }
    }
}
