using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using SweetBakery.Models;

namespace SweetBakery.Controllers
{
    public class QuanLyNguoiDungController : Controller
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

            var nguoiDungs = db.NguoiDungs
                .Where(n => n.VaiTro == "admin")
                .OrderBy(n => n.MaNguoiDung)
                .ToList();
            return View(nguoiDungs);
        }

        public ActionResult Them()
        {
            if (!LaAdmin())
            {
                return RedirectToAction("DangNhap", "TaiKhoan");
            }
            return View();
        }

        [HttpPost]
        public ActionResult Them(NguoiDung nguoiDung)
        {
            if (!LaAdmin())
            {
                return RedirectToAction("DangNhap", "TaiKhoan");
            }

            if (db.NguoiDungs.Any(n => n.Email == nguoiDung.Email))
            {
                ModelState.AddModelError("Email", "Email này đã được sử dụng, vui lòng dùng email khác");
            }

            if (ModelState.IsValid)
            {
                nguoiDung.VaiTro = "admin";
                nguoiDung.MatKhau = BaoMat.BamMatKhau(nguoiDung.MatKhau);
                db.NguoiDungs.Add(nguoiDung);
                db.SaveChanges();
                TempData["ThongBao"] = "Đã thêm tài khoản quản trị [" + nguoiDung.HoTen + "] thành công!";
                return RedirectToAction("Index");
            }
            return View(nguoiDung);
        }

        public ActionResult Sua(int? id)
        {
            if (!LaAdmin())
            {
                return RedirectToAction("DangNhap", "TaiKhoan");
            }
            if (id == null)
            {
                return HttpNotFound();
            }

            var nguoiDung = db.NguoiDungs.Find(id.Value);
            if (nguoiDung == null || nguoiDung.VaiTro != "admin")
            {
                return HttpNotFound();
            }
            return View(nguoiDung);
        }

        [HttpPost]
        public ActionResult Sua(NguoiDung nguoiDung, string matKhauMoi)
        {
            if (!LaAdmin())
            {
                return RedirectToAction("DangNhap", "TaiKhoan");
            }

            if (db.NguoiDungs.Any(n => n.Email == nguoiDung.Email && n.MaNguoiDung != nguoiDung.MaNguoiDung))
            {
                ModelState.AddModelError("Email", "Email này đã được sử dụng, vui lòng dùng email khác");
            }

            if (!string.IsNullOrEmpty(matKhauMoi) && matKhauMoi.Length < 6)
            {
                ModelState.AddModelError("MatKhau", "Mật khẩu mới phải có ít nhất 6 ký tự");
            }

            if (ModelState.IsValid)
            {
                var nguoiDungCu = db.NguoiDungs.Find(nguoiDung.MaNguoiDung);
                if (nguoiDungCu == null)
                {
                    return HttpNotFound();
                }

                nguoiDungCu.HoTen = nguoiDung.HoTen;
                nguoiDungCu.Email = nguoiDung.Email;
                nguoiDungCu.SoDienThoai = nguoiDung.SoDienThoai;
                nguoiDungCu.DiaChi = nguoiDung.DiaChi;
                if (!string.IsNullOrEmpty(matKhauMoi))
                {
                    nguoiDungCu.MatKhau = BaoMat.BamMatKhau(matKhauMoi);
                }
                db.SaveChanges();
                TempData["ThongBao"] = "Đã cập nhật tài khoản [" + nguoiDung.HoTen + "] thành công!";
                return RedirectToAction("Index");
            }
            return View(nguoiDung);
        }

        [HttpPost]
        public ActionResult Xoa(int id)
        {
            if (!LaAdmin())
            {
                return RedirectToAction("DangNhap", "TaiKhoan");
            }

            var nguoiDung = db.NguoiDungs.Find(id);
            if (nguoiDung == null)
            {
                return HttpNotFound();
            }

            if (id == (int)Session["MaNguoiDung"])
            {
                TempData["ThongBao"] = "Không thể xóa tài khoản bạn đang đăng nhập!";
                return RedirectToAction("Index");
            }

            if (db.DonHangs.Any(d => d.MaNguoiDung == id))
            {
                TempData["ThongBao"] = "Không thể xóa tài khoản [" + nguoiDung.HoTen + "] vì đã có đơn hàng liên quan!";
                return RedirectToAction("Index");
            }

            db.NguoiDungs.Remove(nguoiDung);
            db.SaveChanges();
            TempData["ThongBao"] = "Đã xóa tài khoản quản trị [" + nguoiDung.HoTen + "] thành công!";
            return RedirectToAction("Index");
        }
    }
}
