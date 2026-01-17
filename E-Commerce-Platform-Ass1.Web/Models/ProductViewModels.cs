using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace E_Commerce_Platform_Ass1.Web.Models
{
    /// <summary>
    /// ViewModel cho form tạo sản phẩm
    /// </summary>
    public class CreateProductViewModel
    {
        [Required(ErrorMessage = "Tên sản phẩm là bắt buộc.")]
        [StringLength(200, ErrorMessage = "Tên sản phẩm không được vượt quá {1} ký tự.")]
        [Display(Name = "Tên sản phẩm")]
        public string Name { get; set; } = string.Empty;

        [StringLength(2000, ErrorMessage = "Mô tả không được vượt quá {1} ký tự.")]
        [Display(Name = "Mô tả")]
        public string? Description { get; set; }

        [Required(ErrorMessage = "Giá sản phẩm là bắt buộc.")]
        [Range(0, double.MaxValue, ErrorMessage = "Giá phải lớn hơn hoặc bằng 0.")]
        [Display(Name = "Giá bán (₫)")]
        public decimal BasePrice { get; set; }

        [Required(ErrorMessage = "Vui lòng chọn danh mục.")]
        [Display(Name = "Danh mục")]
        public Guid CategoryId { get; set; }

        [StringLength(500, ErrorMessage = "URL hình ảnh không được vượt quá {1} ký tự.")]
        [Display(Name = "Link hình ảnh")]
        [Url(ErrorMessage = "URL không hợp lệ.")]
        public string? ImageUrl { get; set; }

        // Dropdown list categories
        public List<SelectListItem> Categories { get; set; } = new();
    }

    /// <summary>
    /// ViewModel hiển thị sản phẩm trong danh sách
    /// </summary>
    public class ProductListItemViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal BasePrice { get; set; }
        public string Status { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
        public string? CategoryName { get; set; }

        // Helper để hiển thị status
        public string StatusBadgeClass =>
            Status switch
            {
                "active" => "badge-success",
                "inactive" => "badge-secondary",
                "draft" => "badge-warning",
                _ => "badge-info",
            };

        public string StatusDisplayName =>
            Status switch
            {
                "active" => "Đang bán",
                "inactive" => "Ngừng bán",
                "draft" => "Bản nháp",
                _ => Status,
            };
    }

    /// <summary>
    /// ViewModel cho trang danh sách sản phẩm
    /// </summary>
    public class ProductListViewModel
    {
        public Guid ShopId { get; set; }
        public string ShopName { get; set; } = string.Empty;
        public List<ProductListItemViewModel> Products { get; set; } = new();

        // Statistics
        public int TotalProducts => Products.Count;
        public int ActiveCount => Products.Count(p => p.Status == "active");
        public int InactiveCount => Products.Count(p => p.Status == "inactive");
    }
}
