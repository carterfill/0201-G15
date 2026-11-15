using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using SweetBakery.Models;

namespace SweetBakery.Controllers
{
    public class QuanLyKhoHangController : Controller
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

            ViewBag.DanhSachTon = db.SanPhams
                .Where(s => s.SoLuongTon > 0)
                .OrderBy(s => s.TenSanPham)
                .ToList();
            ViewBag.DanhSachCanNhap = db.SanPhams
                .Where(s => s.SoLuongTon == 0)
                .OrderBy(s => s.TenSanPham)
                .ToList();
            return View();
        }
    }
}
