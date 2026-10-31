using System.Linq;
using System.Web.Mvc;
using SweetBakery.Models;

namespace SweetBakery.Controllers
{
    public class TaiKhoanController : Controller
    {
        private ShopDbContext db = new ShopDbContext();

        public ActionResult DangNhap()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DangNhap(string email, string matKhau)
        {
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(matKhau))
            {
                ViewBag.Loi = "Vui lòng nhập đầy đủ Email và Mật khẩu!";
                return View();
            }

            var matKhauBam = BaoMat.BamMatKhau(matKhau);
            var nguoiDung = db.NguoiDungs.FirstOrDefault(n => n.Email == email && n.MatKhau == matKhauBam);

            if (nguoiDung == null)
            {
                ViewBag.Loi = "Email hoặc mật khẩu không đúng! Vui lòng thử lại.";
                return View();
            }

            Session["MaNguoiDung"] = nguoiDung.MaNguoiDung;
            Session["HoTen"] = nguoiDung.HoTen;
            Session["VaiTro"] = nguoiDung.VaiTro;

            TempData["ThongBao"] = "Đăng nhập thành công! Xin chào " + nguoiDung.HoTen + " 👋";

            if (nguoiDung.VaiTro == "admin")
            {
                return RedirectToAction("Index", "QuanLySanPham");
            }
            return RedirectToAction("Index", "Home");
        }

        public ActionResult DangKy()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DangKy(NguoiDung nguoiDung, string xacNhanMatKhau)
        {
            if (string.IsNullOrEmpty(xacNhanMatKhau))
            {
                ModelState.AddModelError("XacNhanMatKhau", "Vui lòng nhập lại mật khẩu");
            }
            else if (xacNhanMatKhau != nguoiDung.MatKhau)
            {
                ModelState.AddModelError("XacNhanMatKhau", "Mật khẩu nhập lại không khớp");
            }

            var emailDaTonTai = db.NguoiDungs.Any(n => n.Email == nguoiDung.Email);
            if (emailDaTonTai)
            {
                ModelState.AddModelError("Email", "Email này đã được đăng ký, vui lòng dùng email khác");
            }

            if (ModelState.IsValid)
            {
                nguoiDung.VaiTro = "khach";
                nguoiDung.MatKhau = BaoMat.BamMatKhau(nguoiDung.MatKhau);
                db.NguoiDungs.Add(nguoiDung);
                db.SaveChanges();

                Session["MaNguoiDung"] = nguoiDung.MaNguoiDung;
                Session["HoTen"] = nguoiDung.HoTen;
                Session["VaiTro"] = nguoiDung.VaiTro;

                TempData["ThongBao"] = "Đăng ký thành viên thành công! Chào mừng bạn đến với Sweet Bakery 🎂";
                return RedirectToAction("Index", "Home");
            }

            return View(nguoiDung);
        }

        public ActionResult DangXuat()
        {
            Session.Clear();
            return RedirectToAction("Index", "Home");
        }
    }
}
