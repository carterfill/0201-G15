CREATE DATABASE SweetBakery;
GO

USE SweetBakery;
GO

CREATE TABLE DanhMuc (
    MaDanhMuc INT IDENTITY(1,1) PRIMARY KEY,
    TenDanhMuc NVARCHAR(100) NOT NULL,
    MoTa NVARCHAR(500) NULL,
    HinhAnh NVARCHAR(255) NULL
);
GO

CREATE TABLE SanPham (
    MaSanPham INT IDENTITY(1,1) PRIMARY KEY,
    TenSanPham NVARCHAR(150) NOT NULL,
    MoTa NVARCHAR(1000) NULL,
    MoTaChiTiet NVARCHAR(MAX) NULL,
    ThanhPhan NVARCHAR(MAX) NULL,
    BaoQuan NVARCHAR(500) NULL,
    KichThuoc NVARCHAR(255) NULL,
    Gia DECIMAL(18, 2) NOT NULL,
    GiaGoc DECIMAL(18, 2) NULL,
    HinhAnh NVARCHAR(255) NULL,
    Sao INT NOT NULL DEFAULT 5,
    DaBan INT NOT NULL DEFAULT 0,
    Hot BIT NOT NULL DEFAULT 0,
    MaDanhMuc INT NOT NULL,
    CONSTRAINT FK_SanPham_DanhMuc FOREIGN KEY (MaDanhMuc) REFERENCES DanhMuc(MaDanhMuc) ON DELETE CASCADE
);
GO

CREATE TABLE NguoiDung (
    MaNguoiDung INT IDENTITY(1,1) PRIMARY KEY,
    HoTen NVARCHAR(100) NOT NULL,
    Email NVARCHAR(150) NOT NULL UNIQUE,
    MatKhau NVARCHAR(100) NOT NULL,
    SoDienThoai NVARCHAR(15) NULL,
    DiaChi NVARCHAR(255) NULL,
    VaiTro NVARCHAR(20) NOT NULL DEFAULT 'khach'
);
GO

CREATE TABLE DonHang (
    MaDonHang INT IDENTITY(1,1) PRIMARY KEY,
    MaNguoiDung INT NOT NULL,
    NgayDat DATETIME NOT NULL,
    HoTenNguoiNhan NVARCHAR(100) NOT NULL,
    SoDienThoai NVARCHAR(15) NULL,
    DiaChiGiao NVARCHAR(255) NOT NULL,
    GhiChu NVARCHAR(500) NULL,
    PhuongThucThanhToan NVARCHAR(100) NULL,
    TrangThaiThanhToan NVARCHAR(100) NULL,
    TrangThai INT NOT NULL DEFAULT 1,
    PhiShip DECIMAL(18, 2) NOT NULL DEFAULT 0,
    GiamGia DECIMAL(18, 2) NOT NULL DEFAULT 0,
    TongTien DECIMAL(18, 2) NOT NULL,
    CONSTRAINT FK_DonHang_NguoiDung FOREIGN KEY (MaNguoiDung) REFERENCES NguoiDung(MaNguoiDung) ON DELETE CASCADE
);
GO

CREATE TABLE ChiTietDonHang (
    MaChiTiet INT IDENTITY(1,1) PRIMARY KEY,
    MaDonHang INT NOT NULL,
    MaSanPham INT NOT NULL,
    TenSanPham NVARCHAR(150) NOT NULL,
    Gia DECIMAL(18, 2) NOT NULL,
    HinhAnh NVARCHAR(255) NULL,
    SoLuong INT NOT NULL,
    ThanhTien DECIMAL(18, 2) NOT NULL,
    CONSTRAINT FK_ChiTietDonHang_DonHang FOREIGN KEY (MaDonHang) REFERENCES DonHang(MaDonHang) ON DELETE CASCADE,
    CONSTRAINT FK_ChiTietDonHang_SanPham FOREIGN KEY (MaSanPham) REFERENCES SanPham(MaSanPham) ON DELETE CASCADE
);
GO

INSERT INTO DanhMuc (TenDanhMuc, MoTa, HinhAnh) VALUES
(N'Bánh Kem Sinh Nhật', N'Bánh kem tươi cao cấp cho ngày kỷ niệm ý nghĩa', 'banh-kem-dau-tay.jpg'),
(N'Bánh Mì & Pastry', N'Bánh mì sừng bò, bánh nướng chuẩn phong cách Pháp', 'croissant.jpg'),
(N'Bánh Mousse & Bánh Lạnh', N'Mát lạnh mềm mịn xua tan cái nóng ngày hè', 'mousse-xoai.jpg'),
(N'Macaron & Cookie', N'Bánh tráng miệng nhỏ xinh hương vị tinh tế', 'macaron.jpg');
GO

INSERT INTO SanPham (TenSanPham, MoTa, MoTaChiTiet, ThanhPhan, BaoQuan, KichThuoc, Gia, GiaGoc, HinhAnh, Sao, DaBan, Hot, MaDanhMuc) VALUES
(N'Bánh Kem Dâu Tây Đà Lạt', N'Bánh kem tươi mềm xốp phủ ngập dâu tây Đà Lạt tươi mọng ngọt dịu.', N'Bánh kem dâu tây là món bán chạy nhất tại Sweet Bakery. Cốt bánh chiffon vani mềm xốp kết hợp hoàn hảo cùng kem tươi whipping béo nhẹ từ New Zealand, ít ngọt không ngấy. Bề mặt bánh được trang trí bằng những trái dâu tây Đà Lạt tuyển chọn kỹ lưỡng, mọng nước và thơm nồng.', N'Cốt bông lan Chiffon vani, kem sữa tươi New Zealand, dâu tây tươi Đà Lạt, mứt dâu handmade, lá hương thảo trang trí.', N'Bảo quản ở nhiệt độ 2 - 6°C trong tủ mát. Dùng ngon nhất trong vòng 24 - 48 giờ sau khi nhận bánh.', N'Size 16cm (4 - 6 người) | Tặng kèm nến, muỗng, dao cắt bánh', 250000, 290000, 'banh-kem-dau-tay.jpg', 5, 218, 1, 1),
(N'Bánh Mì Sừng Bò (Croissant Bơ Pháp)', N'Bánh ngàn lớp giòn rụm bên ngoài, thơm lừng bơ Pháp cao cấp bên trong.', N'Croissant truyền thống chuẩn kỹ thuật cán bột thủ công nhiều lớp. Khi nướng chín, bánh nở bung phồng xốp giòn rụm, từng thớ bánh thơm lừng mùi bơ Elle & Vire nhập khẩu từ Pháp. Thích hợp dùng kèm cà phê hoặc trà nóng cho bữa sáng tràn đầy năng lượng.', N'Bột mì thượng hạng, bơ lạt nguyên chất Elle & Vire Pháp, men tươi nở chậm, sữa tươi không đường, muối biển.', N'Bảo quản nơi khô ráo, thoáng mát trong 2 ngày. Có thể hâm nóng lại bằng nồi chiên không dầu 160°C trong 3 phút để vỏ giòn lại.', N'Trọng lượng 85g / chiếc | Nướng mới 2 mẻ mỗi ngày: 7h00 và 14h00', 35000, 45000, 'croissant.jpg', 5, 540, 1, 2),
(N'Bánh Macaron Cầu Vồng Pháp', N'Hộp 6 bánh macaron giòn ngọt đủ màu sắc và các vị trái cây tự nhiên.', N'Hộp quà tặng Macaron 6 chiếc gồm 6 hương vị tinh tế: Dâu tây, Matcha Nhật Bản, Chocolate đen, Chanh dây, Việt quất và Vani Madagascar. Vỏ bánh giòn xốp bên ngoài, dẻo dai bên trong cùng lớp nhân ganache sánh mịn tan ngay trên đầu lưỡi.', N'Bột hạnh nhân xay mịn, đường bột cao cấp, lòng trắng trứng tiệt trùng, bơ hạt dẻ, sô cô la Callebaut, chiết xuất trái cây tự nhiên.', N'Bảo quản ngăn mát tủ lạnh dùng trong 5 ngày. Đem ra nhiệt độ phòng khoảng 10 phút trước khi thưởng thức.', N'Hộp 6 chiếc có nơ thắt sang trọng thích hợp làm quà tặng', 120000, 150000, 'macaron.jpg', 5, 185, 0, 4),
(N'Bánh Mousse Xoài Nhiệt Đới', N'Bánh mousse mát lạnh vị chua ngọt thanh mát từ xoài cát Hòa Lộc.', N'Chiếc bánh mousse thanh mát là lựa chọn tuyệt vời cho những ai yêu thích vị chua ngọt tự nhiên của trái cây nhiệt đới. Lớp mousse vàng ươm núng nính làm từ sốt xoài cát tươi nguyên chất, bên dưới là đế bánh bông lan mềm mịn và lớp thạch gương xoài bóng bẩy bên trên.', N'Thịt xoài cát tươi, gelatin lá Đức, kem whipping tươi, sữa chua không đường, đế bông lan vani, đường mía.', N'Bảo quản liên tục trong ngăn mát tủ lạnh từ 1 - 4°C. Dùng ngon nhất trong vòng 2 ngày.', N'Cúp bánh tam giác trọng lượng 120g', 55000, 65000, 'mousse-xoai.jpg', 4, 312, 1, 3),
(N'Bánh Kem Chocolate Truffle', N'Vị chocolate đen 70% Bỉ đậm đà, sang trọng cho các bữa tiệc sinh nhật.', N'Bánh Kem Chocolate Truffle là tuyệt tác dành riêng cho các tín đồ mê sô-cô-la đích thực. Lớp ganache bóng loáng phủ bên ngoài lớp kem mousse chocolate đen 70% từ vương quốc Bỉ, xen kẽ với các tầng cốt bánh ẩm mượt đậm đà, đắng nhẹ hậu vị ngọt ngào.', N'Chocolate đen nguyên chất 70% Bỉ, bột ca cao nguyên chất, kem whipping béo, cốt bánh bông lan chocolate ẩm, rượu rum nhẹ.', N'Bảo quản ở nhiệt độ mát 2 - 6°C. Tránh để nơi có ánh nắng trực tiếp hoặc nhiệt độ cao.', N'Size 18cm (6 - 8 người) | Tặng kèm trọn bộ nến hoa sen và phụ kiện tiệc', 280000, 320000, 'banh-chocolate.jpg', 5, 198, 1, 1),
(N'Bánh Tiramisu Ý Cổ Điển', N'Hương vị cà phê nồng nàn hòa quyện phô mai Mascarpone béo ngậy thơm ngon.', N'Tiramisu chuẩn vị nước Ý được làm từ phô mai Mascarpone nhập khẩu kết hợp cùng từng chiếc bánh sâm-panh (Ladyfinger) thấm đẫm cà phê espresso đậm đà và chút rượu Marsala thơm nồng. Phía trên rắc một lớp bột cacao đắng tạo nên sự cân bằng hương vị hoàn hảo.', N'Phô mai Mascarpone Ý, bánh Ladyfinger, cà phê Espresso thượng hạng, rượu hương nồng nhẹ, trứng gà tiệt trùng, bột cacao nguyên chất.', N'Bảo quản trong ngăn mát 2 - 5°C. Thưởng thức lạnh để cảm nhận rõ từng tầng hương vị béo ngậy.', N'Hộp thiếc vintage hoặc hộp mica 150g', 65000, 75000, 'tiramisu.jpg', 5, 420, 1, 3),
(N'Bánh Mì Sừng Bò Hạnh Nhân', N'Croissant phủ sốt kem hạnh nhân béo ngậy và hạt hạnh nhân thái lát giòn rụm.', N'Phiên bản nâng cấp đặc biệt của Croissant bơ truyền thống: bánh được quét đẫm một lớp kem hạnh nhân ngọt bùi (Frangipane) từ trong ra ngoài, sau đó rắc ngập tràn hạnh nhân lát nướng thơm vàng giòn rụm.', N'Bột mì Pháp, bơ lạt nguyên chất, bột hạnh nhân, hạnh nhân lát sấy giòn, đường bột trang trí.', N'Bảo quản ở nhiệt độ phòng trong 24 giờ hoặc ngăn mát tủ lạnh 3 ngày.', N'Trọng lượng 110g / chiếc', 45000, 55000, 'croissant.jpg', 5, 176, 0, 2),
(N'Bánh Kem Dâu Phô Mai Tươi', N'Sự kết hợp quyến rũ giữa kem phô mai béo ngậy và mứt dâu tây chua thanh.', N'Dành cho những bạn thích vị phô mai đậm đà nhưng không hề bị ngấy. Cốt bánh vani xen lẫn lớp phô mai kem mịn màng và dâu tươi cắt hạt lựu, mang đến cảm giác tan chảy ngay khi thưởng thức miếng đầu tiên.', N'Cream cheese cao cấp, kem tươi động vật, dâu tây tươi, sốt dâu nấu thủ công, cốt bông lan mềm mịn.', N'Bảo quản tủ lạnh từ 2 - 5°C. Hạn sử dụng trong 48 giờ.', N'Size 16cm (4 - 6 người ăn)', 260000, 300000, 'banh-kem-dau-tay.jpg', 5, 145, 0, 1);
GO

INSERT INTO NguoiDung (HoTen, Email, MatKhau, SoDienThoai, DiaChi, VaiTro) VALUES
(N'Quản Trị Viên', 'admin@sweetbakery.vn', '240be518fabd2724ddb6f04eeb1da5967448d7e831c08c8fa822809f74c720a9', '0912345678', N'123 Đường Tân Sơn, An Hội Tây, TP. Hồ Chí Minh', 'admin'),
(N'Lê Hương Mai', 'huongmai@gmail.com', '8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92', '0918123456', N'Số 12 Nguyễn Huệ, Quận 1, TP. Hồ Chí Minh', 'khach');
GO

INSERT INTO DonHang (MaNguoiDung, NgayDat, HoTenNguoiNhan, SoDienThoai, DiaChiGiao, GhiChu, PhuongThucThanhToan, TrangThaiThanhToan, TrangThai, PhiShip, GiamGia, TongTien) VALUES
(2, '2026-10-10 14:30:00', N'Trần Mai Anh', '0918123456', N'Số 45 Lê Duẩn, Bến Nghé, Quận 1, TP. Hồ Chí Minh', N'Vui lòng vẽ chữ ''Chúc mừng sinh nhật Mẹ'' lên bánh kem giúp mình nhé!', N'Chuyển khoản QR Ngân hàng (VietQR / Momo)', N'Đã thanh toán', 4, 25000, 20000, 320000),
(2, '2026-10-12 09:15:00', N'Nguyễn Văn Tuấn', '0909876543', N'120 Điện Biên Phủ, Phường 15, Quận Bình Thạnh, TP. Hồ Chí Minh', N'Giao trước 11h trưa để kịp liên hoan văn phòng', N'Tiền mặt khi nhận bánh (COD)', N'Chưa thanh toán', 2, 15000, 0, 205000);
GO

INSERT INTO ChiTietDonHang (MaDonHang, MaSanPham, TenSanPham, Gia, HinhAnh, SoLuong, ThanhTien) VALUES
(1, 1, N'Bánh Kem Dâu Tây Đà Lạt', 250000, 'banh-kem-dau-tay.jpg', 1, 250000),
(1, 6, N'Bánh Tiramisu Ý Cổ Điển', 65000, 'tiramisu.jpg', 1, 65000),
(2, 2, N'Bánh Mì Sừng Bò (Croissant Bơ Pháp)', 35000, 'croissant.jpg', 2, 70000),
(2, 3, N'Bánh Macaron Cầu Vồng Pháp', 120000, 'macaron.jpg', 1, 120000);
GO
