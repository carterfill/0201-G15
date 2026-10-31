using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace SweetBakery.Models
{
    public class DbInitializer : DropCreateDatabaseIfModelChanges<ShopDbContext>
    {
        protected override void Seed(ShopDbContext db)
        {
            var admin = new NguoiDung
            {
                HoTen = "Quản Trị Viên",
                Email = "admin@sweetbakery.vn",
                MatKhau = BaoMat.BamMatKhau("admin123"),
                SoDienThoai = "0912345678",
                DiaChi = "123 Đường Tân Sơn, An Hội Tây, TP. Hồ Chí Minh",
                VaiTro = "admin"
            };
            var khach = new NguoiDung
            {
                HoTen = "Lê Hương Mai",
                Email = "huongmai@gmail.com",
                MatKhau = BaoMat.BamMatKhau("123456"),
                SoDienThoai = "0918123456",
                DiaChi = "Số 12 Nguyễn Huệ, Quận 1, TP. Hồ Chí Minh",
                VaiTro = "khach"
            };
            db.NguoiDungs.Add(admin);
            db.NguoiDungs.Add(khach);

            var dmKem = new DanhMuc
            {
                TenDanhMuc = "Bánh Kem Sinh Nhật",
                MoTa = "Bánh kem tươi cao cấp cho ngày kỷ niệm ý nghĩa",
                HinhAnh = "banh-kem-dau-tay.jpg"
            };
            var dmPastry = new DanhMuc
            {
                TenDanhMuc = "Bánh Mì & Pastry",
                MoTa = "Bánh mì sừng bò, bánh nướng chuẩn phong cách Pháp",
                HinhAnh = "croissant.jpg"
            };
            var dmMousse = new DanhMuc
            {
                TenDanhMuc = "Bánh Mousse & Bánh Lạnh",
                MoTa = "Mát lạnh mềm mịn xua tan cái nóng ngày hè",
                HinhAnh = "mousse-xoai.jpg"
            };
            var dmMacaron = new DanhMuc
            {
                TenDanhMuc = "Macaron & Cookie",
                MoTa = "Bánh tráng miệng nhỏ xinh hương vị tinh tế",
                HinhAnh = "macaron.jpg"
            };
            db.DanhMucs.Add(dmKem);
            db.DanhMucs.Add(dmPastry);
            db.DanhMucs.Add(dmMousse);
            db.DanhMucs.Add(dmMacaron);

            var sp1 = new SanPham
            {
                TenSanPham = "Bánh Kem Dâu Tây Đà Lạt",
                Gia = 250000,
                GiaGoc = 290000,
                HinhAnh = "banh-kem-dau-tay.jpg",
                MoTa = "Bánh kem tươi mềm xốp phủ ngập dâu tây Đà Lạt tươi mọng ngọt dịu.",
                MoTaChiTiet = "Bánh kem dâu tây là món bán chạy nhất tại Sweet Bakery. Cốt bánh chiffon vani mềm xốp kết hợp hoàn hảo cùng kem tươi whipping béo nhẹ từ New Zealand, ít ngọt không ngấy. Bề mặt bánh được trang trí bằng những trái dâu tây Đà Lạt tuyển chọn kỹ lưỡng, mọng nước và thơm nồng.",
                ThanhPhan = "Cốt bông lan Chiffon vani, kem sữa tươi New Zealand, dâu tây tươi Đà Lạt, mứt dâu handmade, lá hương thảo trang trí.",
                BaoQuan = "Bảo quản ở nhiệt độ 2 - 6°C trong tủ mát. Dùng ngon nhất trong vòng 24 - 48 giờ sau khi nhận bánh.",
                KichThuoc = "Size 16cm (4 - 6 người) | Tặng kèm nến, muỗng, dao cắt bánh",
                Sao = 5,
                DaBan = 218,
                Hot = true,
                DanhMuc = dmKem
            };
            var sp2 = new SanPham
            {
                TenSanPham = "Bánh Mì Sừng Bò (Croissant Bơ Pháp)",
                Gia = 35000,
                GiaGoc = 45000,
                HinhAnh = "croissant.jpg",
                MoTa = "Bánh ngàn lớp giòn rụm bên ngoài, thơm lừng bơ Pháp cao cấp bên trong.",
                MoTaChiTiet = "Croissant truyền thống chuẩn kỹ thuật cán bột thủ công nhiều lớp. Khi nướng chín, bánh nở bung phồng xốp giòn rụm, từng thớ bánh thơm lừng mùi bơ Elle & Vire nhập khẩu từ Pháp. Thích hợp dùng kèm cà phê hoặc trà nóng cho bữa sáng tràn đầy năng lượng.",
                ThanhPhan = "Bột mì thượng hạng, bơ lạt nguyên chất Elle & Vire Pháp, men tươi nở chậm, sữa tươi không đường, muối biển.",
                BaoQuan = "Bảo quản nơi khô ráo, thoáng mát trong 2 ngày. Có thể hâm nóng lại bằng nồi chiên không dầu 160°C trong 3 phút để vỏ giòn lại.",
                KichThuoc = "Trọng lượng 85g / chiếc | Nướng mới 2 mẻ mỗi ngày: 7h00 và 14h00",
                Sao = 5,
                DaBan = 540,
                Hot = true,
                DanhMuc = dmPastry
            };
            var sp3 = new SanPham
            {
                TenSanPham = "Bánh Macaron Cầu Vồng Pháp",
                Gia = 120000,
                GiaGoc = 150000,
                HinhAnh = "macaron.jpg",
                MoTa = "Hộp 6 bánh macaron giòn ngọt đủ màu sắc và các vị trái cây tự nhiên.",
                MoTaChiTiet = "Hộp quà tặng Macaron 6 chiếc gồm 6 hương vị tinh tế: Dâu tây, Matcha Nhật Bản, Chocolate đen, Chanh dây, Việt quất và Vani Madagascar. Vỏ bánh giòn xốp bên ngoài, dẻo dai bên trong cùng lớp nhân ganache sánh mịn tan ngay trên đầu lưỡi.",
                ThanhPhan = "Bột hạnh nhân xay mịn, đường bột cao cấp, lòng trắng trứng tiệt trùng, bơ hạt dẻ, sô cô la Callebaut, chiết xuất trái cây tự nhiên.",
                BaoQuan = "Bảo quản ngăn mát tủ lạnh dùng trong 5 ngày. Đem ra nhiệt độ phòng khoảng 10 phút trước khi thưởng thức.",
                KichThuoc = "Hộp 6 chiếc có nơ thắt sang trọng thích hợp làm quà tặng",
                Sao = 5,
                DaBan = 185,
                Hot = false,
                DanhMuc = dmMacaron
            };
            var sp4 = new SanPham
            {
                TenSanPham = "Bánh Mousse Xoài Nhiệt Đới",
                Gia = 55000,
                GiaGoc = 65000,
                HinhAnh = "mousse-xoai.jpg",
                MoTa = "Bánh mousse mát lạnh vị chua ngọt thanh mát từ xoài cát Hòa Lộc.",
                MoTaChiTiet = "Chiếc bánh mousse thanh mát là lựa chọn tuyệt vời cho những ai yêu thích vị chua ngọt tự nhiên của trái cây nhiệt đới. Lớp mousse vàng ươm núng nính làm từ sốt xoài cát tươi nguyên chất, bên dưới là đế bánh bông lan mềm mịn và lớp thạch gương xoài bóng bẩy bên trên.",
                ThanhPhan = "Thịt xoài cát tươi, gelatin lá Đức, kem whipping tươi, sữa chua không đường, đế bông lan vani, đường mía.",
                BaoQuan = "Bảo quản liên tục trong ngăn mát tủ lạnh từ 1 - 4°C. Dùng ngon nhất trong vòng 2 ngày.",
                KichThuoc = "Cúp bánh tam giác trọng lượng 120g",
                Sao = 4,
                DaBan = 312,
                Hot = true,
                DanhMuc = dmMousse
            };
            var sp5 = new SanPham
            {
                TenSanPham = "Bánh Kem Chocolate Truffle",
                Gia = 280000,
                GiaGoc = 320000,
                HinhAnh = "banh-chocolate.jpg",
                MoTa = "Vị chocolate đen 70% Bỉ đậm đà, sang trọng cho các bữa tiệc sinh nhật.",
                MoTaChiTiet = "Bánh Kem Chocolate Truffle là tuyệt tác dành riêng cho các tín đồ mê sô-cô-la đích thực. Lớp ganache bóng loáng phủ bên ngoài lớp kem mousse chocolate đen 70% từ vương quốc Bỉ, xen kẽ với các tầng cốt bánh ẩm mượt đậm đà, đắng nhẹ hậu vị ngọt ngào.",
                ThanhPhan = "Chocolate đen nguyên chất 70% Bỉ, bột ca cao nguyên chất, kem whipping béo, cốt bánh bông lan chocolate ẩm, rượu rum nhẹ.",
                BaoQuan = "Bảo quản ở nhiệt độ mát 2 - 6°C. Tránh để nơi có ánh nắng trực tiếp hoặc nhiệt độ cao.",
                KichThuoc = "Size 18cm (6 - 8 người) | Tặng kèm trọn bộ nến hoa sen và phụ kiện tiệc",
                Sao = 5,
                DaBan = 198,
                Hot = true,
                DanhMuc = dmKem
            };
            var sp6 = new SanPham
            {
                TenSanPham = "Bánh Tiramisu Ý Cổ Điển",
                Gia = 65000,
                GiaGoc = 75000,
                HinhAnh = "tiramisu.jpg",
                MoTa = "Hương vị cà phê nồng nàn hòa quyện phô mai Mascarpone béo ngậy thơm ngon.",
                MoTaChiTiet = "Tiramisu chuẩn vị nước Ý được làm từ phô mai Mascarpone nhập khẩu kết hợp cùng từng chiếc bánh sâm-panh (Ladyfinger) thấm đẫm cà phê espresso đậm đà và chút rượu Marsala thơm nồng. Phía trên rắc một lớp bột cacao đắng tạo nên sự cân bằng hương vị hoàn hảo.",
                ThanhPhan = "Phô mai Mascarpone Ý, bánh Ladyfinger, cà phê Espresso thượng hạng, rượu hương nồng nhẹ, trứng gà tiệt trùng, bột cacao nguyên chất.",
                BaoQuan = "Bảo quản trong ngăn mát 2 - 5°C. Thưởng thức lạnh để cảm nhận rõ từng tầng hương vị béo ngậy.",
                KichThuoc = "Hộp thiếc vintage hoặc hộp mica 150g",
                Sao = 5,
                DaBan = 420,
                Hot = true,
                DanhMuc = dmMousse
            };
            var sp7 = new SanPham
            {
                TenSanPham = "Bánh Mì Sừng Bò Hạnh Nhân",
                Gia = 45000,
                GiaGoc = 55000,
                HinhAnh = "croissant.jpg",
                MoTa = "Croissant phủ sốt kem hạnh nhân béo ngậy và hạt hạnh nhân thái lát giòn rụm.",
                MoTaChiTiet = "Phiên bản nâng cấp đặc biệt của Croissant bơ truyền thống: bánh được quét đẫm một lớp kem hạnh nhân ngọt bùi (Frangipane) từ trong ra ngoài, sau đó rắc ngập tràn hạnh nhân lát nướng thơm vàng giòn rụm.",
                ThanhPhan = "Bột mì Pháp, bơ lạt nguyên chất, bột hạnh nhân, hạnh nhân lát sấy giòn, đường bột trang trí.",
                BaoQuan = "Bảo quản ở nhiệt độ phòng trong 24 giờ hoặc ngăn mát tủ lạnh 3 ngày.",
                KichThuoc = "Trọng lượng 110g / chiếc",
                Sao = 5,
                DaBan = 176,
                Hot = false,
                DanhMuc = dmPastry
            };
            var sp8 = new SanPham
            {
                TenSanPham = "Bánh Kem Dâu Phô Mai Tươi",
                Gia = 260000,
                GiaGoc = 300000,
                HinhAnh = "banh-kem-dau-tay.jpg",
                MoTa = "Sự kết hợp quyến rũ giữa kem phô mai béo ngậy và mứt dâu tây chua thanh.",
                MoTaChiTiet = "Dành cho những bạn thích vị phô mai đậm đà nhưng không hề bị ngấy. Cốt bánh vani xen lẫn lớp phô mai kem mịn màng và dâu tươi cắt hạt lựu, mang đến cảm giác tan chảy ngay khi thưởng thức miếng đầu tiên.",
                ThanhPhan = "Cream cheese cao cấp, kem tươi động vật, dâu tây tươi, sốt dâu nấu thủ công, cốt bông lan mềm mịn.",
                BaoQuan = "Bảo quản tủ lạnh từ 2 - 5°C. Hạn sử dụng trong 48 giờ.",
                KichThuoc = "Size 16cm (4 - 6 người ăn)",
                Sao = 5,
                DaBan = 145,
                Hot = false,
                DanhMuc = dmKem
            };
            db.SanPhams.Add(sp1);
            db.SanPhams.Add(sp2);
            db.SanPhams.Add(sp3);
            db.SanPhams.Add(sp4);
            db.SanPhams.Add(sp5);
            db.SanPhams.Add(sp6);
            db.SanPhams.Add(sp7);
            db.SanPhams.Add(sp8);

            var dh1 = new DonHang
            {
                NguoiDung = khach,
                NgayDat = new DateTime(2026, 10, 10, 14, 30, 0),
                HoTenNguoiNhan = "Trần Mai Anh",
                SoDienThoai = "0918123456",
                DiaChiGiao = "Số 45 Lê Duẩn, Bến Nghé, Quận 1, TP. Hồ Chí Minh",
                GhiChu = "Vui lòng vẽ chữ 'Chúc mừng sinh nhật Mẹ' lên bánh kem giúp mình nhé!",
                PhuongThucThanhToan = "Chuyển khoản QR Ngân hàng (VietQR / Momo)",
                TrangThaiThanhToan = "Đã thanh toán",
                TrangThai = 4,
                PhiShip = 25000,
                GiamGia = 20000,
                TongTien = 320000
            };
            dh1.ChiTietDonHangs.Add(new ChiTietDonHang
            {
                SanPham = sp1,
                TenSanPham = sp1.TenSanPham,
                Gia = sp1.Gia,
                HinhAnh = sp1.HinhAnh,
                SoLuong = 1,
                ThanhTien = 250000
            });
            dh1.ChiTietDonHangs.Add(new ChiTietDonHang
            {
                SanPham = sp6,
                TenSanPham = sp6.TenSanPham,
                Gia = sp6.Gia,
                HinhAnh = sp6.HinhAnh,
                SoLuong = 1,
                ThanhTien = 65000
            });

            var dh2 = new DonHang
            {
                NguoiDung = khach,
                NgayDat = new DateTime(2026, 10, 12, 9, 15, 0),
                HoTenNguoiNhan = "Nguyễn Văn Tuấn",
                SoDienThoai = "0909876543",
                DiaChiGiao = "120 Điện Biên Phủ, Phường 15, Quận Bình Thạnh, TP. Hồ Chí Minh",
                GhiChu = "Giao trước 11h trưa để kịp liên hoan văn phòng",
                PhuongThucThanhToan = "Tiền mặt khi nhận bánh (COD)",
                TrangThaiThanhToan = "Chưa thanh toán",
                TrangThai = 2,
                PhiShip = 15000,
                GiamGia = 0,
                TongTien = 205000
            };
            dh2.ChiTietDonHangs.Add(new ChiTietDonHang
            {
                SanPham = sp2,
                TenSanPham = sp2.TenSanPham,
                Gia = sp2.Gia,
                HinhAnh = sp2.HinhAnh,
                SoLuong = 2,
                ThanhTien = 70000
            });
            dh2.ChiTietDonHangs.Add(new ChiTietDonHang
            {
                SanPham = sp3,
                TenSanPham = sp3.TenSanPham,
                Gia = sp3.Gia,
                HinhAnh = sp3.HinhAnh,
                SoLuong = 1,
                ThanhTien = 120000
            });

            db.DonHangs.Add(dh1);
            db.DonHangs.Add(dh2);

            db.SaveChanges();
        }
    }
}
