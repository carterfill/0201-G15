using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using SweetBakery.Models;

namespace SweetBakery.Controllers
{
    public class DonHangController : Controller
    {
        private ShopDbContext db = new ShopDbContext();

        private List<GioHangItem> LayGioHang()
        {
            var gioHang = Session["GioHang"] as List<GioHangItem>;
            if (gioHang == null)
            {
                gioHang = new List<GioHangItem>();
                Session["GioHang"] = gioHang;
            }
            return gioHang;
        }

        private List<MonTrongGio> LayDanhSachMon()
        {
            var dsMon = new List<MonTrongGio>();
            foreach (var item in LayGioHang())
            {
                var sanPham = db.SanPhams.Find(item.MaSanPham);
                if (sanPham != null)
                {
                    var mon = new MonTrongGio();
                    mon.SanPham = sanPham;
                    mon.SoLuong = item.SoLuong;
                    dsMon.Add(mon);
                }
            }
            return dsMon;
        }

        private decimal TinhTien(List<MonTrongGio> dsMon)
        {
            decimal tamTinh = 0;
            foreach (var mon in dsMon)
            {
                tamTinh += mon.ThanhTien;
            }

            decimal phiShip = 20000;
            decimal giamGia = 0;
            if (tamTinh >= 200000)
            {
                phiShip = 0;
            }

            var maGiamGia = Session["MaGiamGia"] as string;
            if (maGiamGia == "SWEET20")
            {
                giamGia = 20000;
            }
            else if (maGiamGia == "FREESHIP")
            {
                phiShip = 0;
            }

            ViewBag.TamTinh = tamTinh;
            ViewBag.PhiShip = phiShip;
            ViewBag.GiamGia = giamGia;

            return tamTinh + phiShip - giamGia;
        }

        private bool DaDangNhap()
        {
            return Session["MaNguoiDung"] != null;
        }

        public ActionResult DatHang()
        {
            if (!DaDangNhap())
            {
                TempData["ThongBao"] = "Vui lòng đăng nhập để đặt hàng!";
                return RedirectToAction("DangNhap", "TaiKhoan");
            }

            var dsMon = LayDanhSachMon();
            if (dsMon.Count == 0)
            {
                TempData["ThongBao"] = "Giỏ hàng đang trống! Hãy chọn bánh trước khi đặt hàng.";
                return RedirectToAction("Index", "GioHang");
            }

            int maNguoiDung = (int)Session["MaNguoiDung"];
            var nguoiDung = db.NguoiDungs.Find(maNguoiDung);

            ViewBag.TongTien = TinhTien(dsMon);
            ViewBag.DsMon = dsMon;
            return View(nguoiDung);
        }

        [HttpPost]
        public ActionResult DatHang(string hoTenNguoiNhan, string soDienThoai, string diaChiGiao, string ghiChu, string phuongThuc)
        {
            if (!DaDangNhap())
            {
                return RedirectToAction("DangNhap", "TaiKhoan");
            }

            var dsMon = LayDanhSachMon();
            if (dsMon.Count == 0)
            {
                TempData["ThongBao"] = "Giỏ hàng đang trống! Hãy chọn bánh trước khi đặt hàng.";
                return RedirectToAction("Index", "GioHang");
            }

            if (string.IsNullOrEmpty(hoTenNguoiNhan) || string.IsNullOrEmpty(diaChiGiao))
            {
                TempData["ThongBao"] = "Vui lòng nhập đầy đủ họ tên và địa chỉ nhận bánh!";
                return RedirectToAction("DatHang");
            }

            int maNguoiDung = (int)Session["MaNguoiDung"];
            decimal tongTien = TinhTien(dsMon);

            string tenPhuongThuc = "Tiền mặt khi nhận bánh (COD)";
            string trangThaiThanhToan = "Chưa thanh toán";
            if (phuongThuc == "QR")
            {
                tenPhuongThuc = "Chuyển khoản QR Ngân hàng (VietQR / Momo)";
                trangThaiThanhToan = "Chờ quét mã QR thanh toán";
            }
            else if (phuongThuc == "ATM")
            {
                tenPhuongThuc = "Thẻ ATM / Thẻ tín dụng Visa, Mastercard";
                trangThaiThanhToan = "Đã thanh toán Online";
            }

            var donHang = new DonHang
            {
                MaNguoiDung = maNguoiDung,
                NgayDat = DateTime.Now,
                HoTenNguoiNhan = hoTenNguoiNhan,
                SoDienThoai = soDienThoai,
                DiaChiGiao = diaChiGiao,
                GhiChu = ghiChu,
                PhuongThucThanhToan = tenPhuongThuc,
                TrangThaiThanhToan = trangThaiThanhToan,
                TrangThai = 1,
                PhiShip = ViewBag.PhiShip,
                GiamGia = ViewBag.GiamGia,
                TongTien = tongTien
            };
            db.DonHangs.Add(donHang);
            db.SaveChanges();

            foreach (var mon in dsMon)
            {
                var chiTiet = new ChiTietDonHang
                {
                    MaDonHang = donHang.MaDonHang,
                    MaSanPham = mon.SanPham.MaSanPham,
                    TenSanPham = mon.SanPham.TenSanPham,
                    Gia = mon.SanPham.Gia,
                    HinhAnh = mon.SanPham.HinhAnh,
                    SoLuong = mon.SoLuong,
                    ThanhTien = mon.ThanhTien
                };
                db.ChiTietDonHangs.Add(chiTiet);
            }
            db.SaveChanges();

            Session["GioHang"] = null;
            Session.Remove("MaGiamGia");

            return RedirectToAction("XacNhan", new { id = donHang.MaDonHang });
        }

        public ActionResult XacNhan(int? id)
        {
            if (!DaDangNhap())
            {
                return RedirectToAction("DangNhap", "TaiKhoan");
            }
            if (id == null)
            {
                return HttpNotFound();
            }

            var donHang = db.DonHangs.Find(id.Value);
            if (donHang == null || (donHang.MaNguoiDung != (int)Session["MaNguoiDung"] && Session["VaiTro"] as string != "admin"))
            {
                return HttpNotFound();
            }

            return View(donHang);
        }

        public ActionResult LichSu()
        {
            if (!DaDangNhap())
            {
                TempData["ThongBao"] = "Vui lòng đăng nhập để xem lịch sử mua hàng!";
                return RedirectToAction("DangNhap", "TaiKhoan");
            }

            int maNguoiDung = (int)Session["MaNguoiDung"];
            var dsDonHang = db.DonHangs
                .Where(d => d.MaNguoiDung == maNguoiDung)
                .OrderByDescending(d => d.NgayDat)
                .ToList();

            return View(dsDonHang);
        }

        public ActionResult ChiTiet(int? id)
        {
            if (!DaDangNhap())
            {
                return RedirectToAction("DangNhap", "TaiKhoan");
            }
            if (id == null)
            {
                return HttpNotFound();
            }

            var donHang = db.DonHangs.Find(id.Value);
            if (donHang == null || (donHang.MaNguoiDung != (int)Session["MaNguoiDung"] && Session["VaiTro"] as string != "admin"))
            {
                return HttpNotFound();
            }

            return View(donHang);
        }
    }
}
