using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using SweetBakery.Models;

namespace SweetBakery.Controllers
{
    public class QuanLyKhachHangController : Controller
    {
        private ShopDbContext db = new ShopDbContext();

        private bool LaAdmin()
        {
            return Session["VaiTro"] as string == "admin";
        }

        public ActionResult Index()
        {
            if (!LaAdmin())
            {
                return RedirectToAction("DangNhap", "TaiKhoan");
            }

            var khachHangs = db.NguoiDungs
                .Where(n => n.VaiTro == "khach")
                .OrderBy(n => n.MaNguoiDung)
                .ToList();
            return View(khachHangs);
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

            var khachHang = db.NguoiDungs.Find(id.Value);
            if (khachHang == null || khachHang.VaiTro != "khach")
            {
                return HttpNotFound();
            }

            ViewBag.DonHangs = db.DonHangs
                .Where(d => d.MaNguoiDung == id.Value)
                .OrderByDescending(d => d.NgayDat)
                .ToList();
            return View(khachHang);
        }
    }
}
