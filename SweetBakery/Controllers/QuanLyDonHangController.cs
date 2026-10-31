using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using SweetBakery.Models;

namespace SweetBakery.Controllers
{
    public class QuanLyDonHangController : Controller
    {
        private ShopDbContext db = new ShopDbContext();

        private bool LaAdmin()
        {
            return Session["VaiTro"] as string == "admin";
        }

        public ActionResult Index(int? trangThai)
        {
            if (!LaAdmin())
            {
                return RedirectToAction("DangNhap", "TaiKhoan");
            }

            var donHangs = db.DonHangs.AsQueryable();
            if (trangThai.HasValue && trangThai.Value >= 1 && trangThai.Value <= 5)
            {
                donHangs = donHangs.Where(d => d.TrangThai == trangThai.Value);
            }

            var ketQua = donHangs.OrderByDescending(d => d.NgayDat).ToList();

            ViewBag.TrangThaiLoc = trangThai;
            ViewBag.DemChoXacNhan = db.DonHangs.Count(d => d.TrangThai == 1);
            return View(ketQua);
        }

        public ActionResult ChiTiet(int? id)
        {
            if (!LaAdmin())
            {
                return RedirectToAction("DangNhap", "TaiKhoan");
            }
            if (id == null)
            {
                return HttpNotFound();
            }

            var donHang = db.DonHangs.Find(id.Value);
            if (donHang == null)
            {
                return HttpNotFound();
            }
            return View(donHang);
        }

        [HttpPost]
        public ActionResult CapNhatTrangThai(int id, int trangThai)
        {
            if (!LaAdmin())
            {
                return RedirectToAction("DangNhap", "TaiKhoan");
            }

            if (trangThai < 1 || trangThai > 5)
            {
                return HttpNotFound();
            }

            var donHang = db.DonHangs.Find(id);
            if (donHang == null)
            {
                return HttpNotFound();
            }

            donHang.TrangThai = trangThai;
            db.SaveChanges();

            TempData["ThongBao"] = "Đã cập nhật đơn #SB-" + donHang.MaDonHang + " sang trạng thái mới!";
            return RedirectToAction("ChiTiet", new { id = donHang.MaDonHang });
        }
    }
}
