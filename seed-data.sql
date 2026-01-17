-- ============================================
-- E-Commerce Platform - Seed Data Script
-- ============================================
-- Script này tạo dữ liệu mẫu cho database local
-- Chạy script này sau khi đã chạy migrations

USE [ECommercePlatformDB]; -- Database name từ appsettings.json
GO

-- Xóa dữ liệu cũ (nếu cần)
-- DELETE FROM reviews;
-- DELETE FROM order_items;
-- DELETE FROM payments;
-- DELETE FROM shipments;
-- DELETE FROM orders;
-- DELETE FROM CartItems;
-- DELETE FROM Carts;
-- DELETE FROM product_variants;
-- DELETE FROM products;
-- DELETE FROM shops;
-- DELETE FROM categories;
-- DELETE FROM users;
-- DELETE FROM roles;
-- GO

-- ============================================
-- 1. ROLES
-- ============================================
INSERT INTO roles (RoleId, Name, Description, CreatedAt)
VALUES
    ('11111111-1111-1111-1111-111111111111', 'Admin', 'Quản trị viên hệ thống', GETDATE()),
    ('22222222-2222-2222-2222-222222222222', 'Customer', 'Khách hàng', GETDATE()),
    ('33333333-3333-3333-3333-333333333333', 'Seller', 'Người bán', GETDATE());
GO

-- ============================================
-- 2. USERS
-- ============================================
-- Password: "123456" (BCrypt hash)
-- Bạn có thể thay đổi password hash theo nhu cầu
INSERT INTO users (Id, Name, PasswordHash, Email, RoleId, Status, CreatedAt)
VALUES
    -- Admin
    ('aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa', 'Admin User', '$2a$11$K7L1OJ45/4Y2nIvhRVpCe.FSmhDdOOXvQbyQ.Y9ibzXjVmhQw7b6O', 'admin@example.com', '11111111-1111-1111-1111-111111111111', 1, GETDATE()),
    
    -- Sellers
    ('bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb', 'Shop Owner 1', '$2a$11$K7L1OJ45/4Y2nIvhRVpCe.FSmhDdOOXvQbyQ.Y9ibzXjVmhQw7b6O', 'seller1@example.com', '33333333-3333-3333-3333-333333333333', 1, GETDATE()),
    ('cccccccc-cccc-cccc-cccc-cccccccccccc', 'Shop Owner 2', '$2a$11$K7L1OJ45/4Y2nIvhRVpCe.FSmhDdOOXvQbyQ.Y9ibzXjVmhQw7b6O', 'seller2@example.com', '33333333-3333-3333-3333-333333333333', 1, GETDATE()),
    
    -- Customers
    ('dddddddd-dddd-dddd-dddd-dddddddddddd', 'Customer 1', '$2a$11$K7L1OJ45/4Y2nIvhRVpCe.FSmhDdOOXvQbyQ.Y9ibzXjVmhQw7b6O', 'customer1@example.com', '22222222-2222-2222-2222-222222222222', 1, GETDATE()),
    ('eeeeeeee-eeee-eeee-eeee-eeeeeeeeeeee', 'Customer 2', '$2a$11$K7L1OJ45/4Y2nIvhRVpCe.FSmhDdOOXvQbyQ.Y9ibzXjVmhQw7b6O', 'customer2@example.com', '22222222-2222-2222-2222-222222222222', 1, GETDATE()),
    ('ffffffff-ffff-ffff-ffff-ffffffffffff', 'Customer 3', '$2a$11$K7L1OJ45/4Y2nIvhRVpCe.FSmhDdOOXvQbyQ.Y9ibzXjVmhQw7b6O', 'customer3@example.com', '22222222-2222-2222-2222-222222222222', 1, GETDATE());
GO

-- ============================================
-- 3. CATEGORIES
-- ============================================
INSERT INTO categories (Id, Name, Status)
VALUES
    ('10000000-0000-0000-0000-000000000001', 'Điện tử', 'Active'),
    ('10000000-0000-0000-0000-000000000002', 'Thời trang', 'Active'),
    ('10000000-0000-0000-0000-000000000003', 'Đồ gia dụng', 'Active'),
    ('10000000-0000-0000-0000-000000000004', 'Sách', 'Active'),
    ('10000000-0000-0000-0000-000000000005', 'Thể thao', 'Active');
GO

-- ============================================
-- 4. SHOPS
-- ============================================
INSERT INTO shops (Id, UserId, ShopName, Description, Status, CreatedAt)
VALUES
    ('20000000-0000-0000-0000-000000000001', 'bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb', 'Tech Store', 'Cửa hàng điện tử uy tín', 'Active', GETDATE()),
    ('20000000-0000-0000-0000-000000000002', 'cccccccc-cccc-cccc-cccc-cccccccccccc', 'Fashion Shop', 'Thời trang nam nữ', 'Active', GETDATE());
GO

-- ============================================
-- 5. PRODUCTS
-- ============================================
INSERT INTO products (Id, ShopId, CategoryId, Name, Description, BasePrice, Status, AvgRating, ImageUrl, CreatedAt)
VALUES
    -- Điện tử
    ('30000000-0000-0000-0000-000000000001', '20000000-0000-0000-0000-000000000001', '10000000-0000-0000-0000-000000000001', 'iPhone 15 Pro', 'Điện thoại thông minh cao cấp', 25000000, 'Active', 4.5, 'https://example.com/iphone15.jpg', GETDATE()),
    ('30000000-0000-0000-0000-000000000002', '20000000-0000-0000-0000-000000000001', '10000000-0000-0000-0000-000000000001', 'Samsung Galaxy S24', 'Điện thoại Android flagship', 22000000, 'Active', 4.3, 'https://example.com/galaxy-s24.jpg', GETDATE()),
    ('30000000-0000-0000-0000-000000000003', '20000000-0000-0000-0000-000000000001', '10000000-0000-0000-0000-000000000001', 'MacBook Pro M3', 'Laptop chuyên nghiệp', 45000000, 'Active', 4.8, 'https://example.com/macbook-pro.jpg', GETDATE()),
    
    -- Thời trang
    ('30000000-0000-0000-0000-000000000004', '20000000-0000-0000-0000-000000000002', '10000000-0000-0000-0000-000000000002', 'Áo sơ mi nam', 'Áo sơ mi công sở cao cấp', 500000, 'Active', 4.2, 'https://example.com/ao-so-mi.jpg', GETDATE()),
    ('30000000-0000-0000-0000-000000000005', '20000000-0000-0000-0000-000000000002', '10000000-0000-0000-0000-000000000002', 'Quần jean nữ', 'Quần jean thời trang', 800000, 'Active', 4.0, 'https://example.com/quan-jean.jpg', GETDATE()),
    ('30000000-0000-0000-0000-000000000006', '20000000-0000-0000-0000-000000000002', '10000000-0000-0000-0000-000000000002', 'Giày thể thao', 'Giày chạy bộ đa năng', 1200000, 'Active', 4.5, 'https://example.com/giay-the-thao.jpg', GETDATE());
GO

-- ============================================
-- 6. PRODUCT VARIANTS
-- ============================================
INSERT INTO product_variants (Id, ProductId, VariantName, Price, Size, Color, Stock, Sku, Status, ImageUrl)
VALUES
    -- iPhone 15 Pro variants
    ('40000000-0000-0000-0000-000000000001', '30000000-0000-0000-0000-000000000001', 'iPhone 15 Pro 128GB - Titanium Blue', 25000000, NULL, 'Blue', 50, 'IP15P-128-BLUE', 'Active', 'https://example.com/iphone15-blue.jpg'),
    ('40000000-0000-0000-0000-000000000002', '30000000-0000-0000-0000-000000000001', 'iPhone 15 Pro 256GB - Titanium Blue', 28000000, NULL, 'Blue', 30, 'IP15P-256-BLUE', 'Active', 'https://example.com/iphone15-blue.jpg'),
    ('40000000-0000-0000-0000-000000000003', '30000000-0000-0000-0000-000000000001', 'iPhone 15 Pro 128GB - Titanium Black', 25000000, NULL, 'Black', 40, 'IP15P-128-BLACK', 'Active', 'https://example.com/iphone15-black.jpg'),
    
    -- Samsung Galaxy S24 variants
    ('40000000-0000-0000-0000-000000000004', '30000000-0000-0000-0000-000000000002', 'Galaxy S24 256GB - Phantom Black', 22000000, NULL, 'Black', 35, 'GS24-256-BLACK', 'Active', 'https://example.com/galaxy-s24-black.jpg'),
    ('40000000-0000-0000-0000-000000000005', '30000000-0000-0000-0000-000000000002', 'Galaxy S24 512GB - Phantom Black', 25000000, NULL, 'Black', 20, 'GS24-512-BLACK', 'Active', 'https://example.com/galaxy-s24-black.jpg'),
    
    -- MacBook Pro variants
    ('40000000-0000-0000-0000-000000000006', '30000000-0000-0000-0000-000000000003', 'MacBook Pro M3 14" 512GB', 45000000, '14 inch', 'Space Gray', 15, 'MBP-M3-14-512', 'Active', 'https://example.com/macbook-pro.jpg'),
    ('40000000-0000-0000-0000-000000000007', '30000000-0000-0000-0000-000000000003', 'MacBook Pro M3 16" 1TB', 55000000, '16 inch', 'Space Gray', 10, 'MBP-M3-16-1TB', 'Active', 'https://example.com/macbook-pro.jpg'),
    
    -- Áo sơ mi variants
    ('40000000-0000-0000-0000-000000000008', '30000000-0000-0000-0000-000000000004', 'Áo sơ mi - Trắng - M', 500000, 'M', 'White', 100, 'ASM-WHITE-M', 'Active', 'https://example.com/ao-so-mi-white.jpg'),
    ('40000000-0000-0000-0000-000000000009', '30000000-0000-0000-0000-000000000004', 'Áo sơ mi - Trắng - L', 500000, 'L', 'White', 80, 'ASM-WHITE-L', 'Active', 'https://example.com/ao-so-mi-white.jpg'),
    ('40000000-0000-0000-0000-000000000010', '30000000-0000-0000-0000-000000000004', 'Áo sơ mi - Xanh - M', 500000, 'M', 'Blue', 90, 'ASM-BLUE-M', 'Active', 'https://example.com/ao-so-mi-blue.jpg'),
    
    -- Quần jean variants
    ('40000000-0000-0000-0000-000000000011', '30000000-0000-0000-0000-000000000005', 'Quần jean - Xanh - Size 28', 800000, '28', 'Blue', 60, 'QJ-BLUE-28', 'Active', 'https://example.com/quan-jean-blue.jpg'),
    ('40000000-0000-0000-0000-000000000012', '30000000-0000-0000-0000-000000000005', 'Quần jean - Xanh - Size 30', 800000, '30', 'Blue', 70, 'QJ-BLUE-30', 'Active', 'https://example.com/quan-jean-blue.jpg'),
    ('40000000-0000-0000-0000-000000000013', '30000000-0000-0000-0000-000000000005', 'Quần jean - Đen - Size 28', 800000, '28', 'Black', 50, 'QJ-BLACK-28', 'Active', 'https://example.com/quan-jean-black.jpg'),
    
    -- Giày thể thao variants
    ('40000000-0000-0000-0000-000000000014', '30000000-0000-0000-0000-000000000006', 'Giày thể thao - Trắng - Size 40', 1200000, '40', 'White', 45, 'GT-WHITE-40', 'Active', 'https://example.com/giay-white.jpg'),
    ('40000000-0000-0000-0000-000000000015', '30000000-0000-0000-0000-000000000006', 'Giày thể thao - Đen - Size 42', 1200000, '42', 'Black', 55, 'GT-BLACK-42', 'Active', 'https://example.com/giay-black.jpg');
GO

-- ============================================
-- 7. CARTS
-- ============================================
INSERT INTO Carts (Id, UserId, Status, CreatedAt)
VALUES
    ('50000000-0000-0000-0000-000000000001', 'dddddddd-dddd-dddd-dddd-dddddddddddd', 'Active', GETDATE()),
    ('50000000-0000-0000-0000-000000000002', 'eeeeeeee-eeee-eeee-eeee-eeeeeeeeeeee', 'Active', GETDATE());
GO

-- ============================================
-- 8. CART ITEMS
-- ============================================
INSERT INTO CartItems (Id, CartId, ProductVariantId, Quantity, CreatedAt)
VALUES
    ('60000000-0000-0000-0000-000000000001', '50000000-0000-0000-0000-000000000001', '40000000-0000-0000-0000-000000000001', 1, GETDATE()),
    ('60000000-0000-0000-0000-000000000002', '50000000-0000-0000-0000-000000000001', '40000000-0000-0000-0000-000000000008', 2, GETDATE()),
    ('60000000-0000-0000-0000-000000000003', '50000000-0000-0000-0000-000000000002', '40000000-0000-0000-0000-000000000004', 1, GETDATE());
GO

-- ============================================
-- 9. ORDERS
-- ============================================
INSERT INTO orders (Id, UserId, TotalAmount, ShippingAddress, Status, CreatedAt)
VALUES
    ('70000000-0000-0000-0000-000000000001', 'dddddddd-dddd-dddd-dddd-dddddddddddd', 25500000, '123 Đường ABC, Quận 1, TP.HCM', 'Completed', DATEADD(day, -5, GETDATE())),
    ('70000000-0000-0000-0000-000000000002', 'eeeeeeee-eeee-eeee-eeee-eeeeeeeeeeee', 800000, '456 Đường XYZ, Quận 2, TP.HCM', 'Processing', DATEADD(day, -2, GETDATE())),
    ('70000000-0000-0000-0000-000000000003', 'ffffffff-ffff-ffff-ffff-ffffffffffff', 1200000, '789 Đường DEF, Quận 3, TP.HCM', 'Pending', DATEADD(day, -1, GETDATE()));
GO

-- ============================================
-- 10. ORDER ITEMS
-- ============================================
INSERT INTO order_items (Id, OrderId, ProductVariantId, ProductName, Price, Quantity)
VALUES
    ('80000000-0000-0000-0000-000000000001', '70000000-0000-0000-0000-000000000001', '40000000-0000-0000-0000-000000000001', 'iPhone 15 Pro 128GB - Titanium Blue', 25000000, 1),
    ('80000000-0000-0000-0000-000000000002', '70000000-0000-0000-0000-000000000001', '40000000-0000-0000-0000-000000000008', 'Áo sơ mi - Trắng - M', 500000, 1),
    
    ('80000000-0000-0000-0000-000000000003', '70000000-0000-0000-0000-000000000002', '40000000-0000-0000-0000-000000000011', 'Quần jean - Xanh - Size 28', 800000, 1),
    
    ('80000000-0000-0000-0000-000000000004', '70000000-0000-0000-0000-000000000003', '40000000-0000-0000-0000-000000000014', 'Giày thể thao - Trắng - Size 40', 1200000, 1);
GO

-- ============================================
-- 11. PAYMENTS
-- ============================================
INSERT INTO payments (Id, OrderId, Method, Amount, Status, TransactionCode, PaidAt)
VALUES
    ('90000000-0000-0000-0000-000000000001', '70000000-0000-0000-0000-000000000001', 'Credit Card', 25500000, 'Completed', 'TXN-' + FORMAT(GETDATE(), 'yyyyMMdd') + '-001', DATEADD(day, -5, GETDATE())),
    ('90000000-0000-0000-0000-000000000002', '70000000-0000-0000-0000-000000000002', 'Bank Transfer', 800000, 'Completed', 'TXN-' + FORMAT(GETDATE(), 'yyyyMMdd') + '-002', DATEADD(day, -2, GETDATE())),
    ('90000000-0000-0000-0000-000000000003', '70000000-0000-0000-0000-000000000003', 'COD', 1200000, 'Pending', 'TXN-' + FORMAT(GETDATE(), 'yyyyMMdd') + '-003', GETDATE());
GO

-- ============================================
-- 12. SHIPMENTS
-- ============================================
INSERT INTO shipments (Id, OrderId, Carrier, TrackingCode, Status, UpdatedAt)
VALUES
    ('A0000000-0000-0000-0000-000000000001', '70000000-0000-0000-0000-000000000001', 'Vietnam Post', 'VN123456789', 'Delivered', DATEADD(day, -3, GETDATE())),
    ('A0000000-0000-0000-0000-000000000002', '70000000-0000-0000-0000-000000000002', 'Giao Hàng Nhanh', 'GHN987654321', 'In Transit', GETDATE()),
    ('A0000000-0000-0000-0000-000000000003', '70000000-0000-0000-0000-000000000003', 'Giao Hàng Tiết Kiệm', 'GHTK555666777', 'Pending', GETDATE());
GO

-- ============================================
-- 13. REVIEWS
-- ============================================
INSERT INTO reviews (Id, UserId, ProductId, OrderItemId, Rating, Comment, Status, SpamScore, ToxicityScore, CreatedAt)
VALUES
    ('B0000000-0000-0000-0000-000000000001', 'dddddddd-dddd-dddd-dddd-dddddddddddd', '30000000-0000-0000-0000-000000000001', '80000000-0000-0000-0000-000000000001', 5, 'Sản phẩm tuyệt vời, giao hàng nhanh!', 'Approved', 0, 0, DATEADD(day, -4, GETDATE())),
    ('B0000000-0000-0000-0000-000000000002', 'dddddddd-dddd-dddd-dddd-dddddddddddd', '30000000-0000-0000-0000-000000000004', '80000000-0000-0000-0000-000000000002', 4, 'Áo đẹp, chất lượng tốt', 'Approved', 0, 0, DATEADD(day, -4, GETDATE()));
GO

-- ============================================
-- Hoàn tất
-- ============================================
PRINT 'Seed data đã được tạo thành công!';
PRINT 'Tổng số bản ghi đã thêm:';
PRINT '  - Roles: 3';
PRINT '  - Users: 6';
PRINT '  - Categories: 5';
PRINT '  - Shops: 2';
PRINT '  - Products: 6';
PRINT '  - Product Variants: 15';
PRINT '  - Carts: 2';
PRINT '  - Cart Items: 3';
PRINT '  - Orders: 3';
PRINT '  - Order Items: 4';
PRINT '  - Payments: 3';
PRINT '  - Shipments: 3';
PRINT '  - Reviews: 2';
GO
