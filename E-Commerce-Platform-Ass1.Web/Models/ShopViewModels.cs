using E_Commerce_Platform_Ass1.Service.DTOs;

namespace E_Commerce_Platform_Ass1.Web.Models
{
    /// <summary>
    /// ViewModel cho trang ViewShop (Dashboard của shop owner)
    /// </summary>
    public class ShopDashboardViewModel
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string ShopName { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }

        // Products list
        public List<ProductDto> Products { get; set; } = new();

        // Statistics
        public int TotalProducts => Products.Count;
        public int ActiveProducts => Products.Count(p => p.Status == "active");
        public int PendingProducts => Products.Count(p => p.Status == "pending");
        public int DraftProducts => Products.Count(p => p.Status == "draft");

        // Helper properties
        public string StatusBadgeClass =>
            Status switch
            {
                "Active" => "badge-success",
                "Pending" => "badge-warning",
                "Inactive" => "badge-secondary",
                _ => "badge-info",
            };

        public string StatusDisplayName =>
            Status switch
            {
                "Active" => "Đang hoạt động",
                "Pending" => "Chờ duyệt",
                "Inactive" => "Ngừng hoạt động",
                _ => Status,
            };
    }

    /// <summary>
    /// ViewModel cho trang Shop Detail (public view)
    /// </summary>
    public class ShopDetailViewModel
    {
        public Guid Id { get; set; }
        public string ShopName { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }

        // Products list
        public List<ProductDto> Products { get; set; } = new();

        public int ProductCount => Products.Count;
    }
}
