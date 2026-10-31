using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using SweetBakery.Models;

namespace SweetBakery.Controllers
{
    public class QuanLyDanhMucController : Controller
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

            var danhMucs = db.DanhMucs.OrderBy(d => d.MaDanhMuc).ToList();
            return View(danhMucs);
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
        public ActionResult Them(DanhMuc danhMuc)
        {
            if (!LaAdmin())
            {
                return RedirectToAction("DangNhap", "TaiKhoan");
            }

            if (ModelState.IsValid)
            {
                db.DanhMucs.Add(danhMuc);
                db.SaveChanges();
                TempData["ThongBao"] = "Đã thêm danh mục [" + danhMuc.TenDanhMuc + "] thành công!";
                return RedirectToAction("Index");
            }
            return View(danhMuc);
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

            var danhMuc = db.DanhMucs.Find(id.Value);
            if (danhMuc == null)
            {
                return HttpNotFound();
            }
            return View(danhMuc);
        }

        [HttpPost]
        public ActionResult Sua(DanhMuc danhMuc)
        {
            if (!LaAdmin())
            {
                return RedirectToAction("DangNhap", "TaiKhoan");
            }

            if (ModelState.IsValid)
            {
                db.Entry(danhMuc).State = EntityState.Modified;
                db.SaveChanges();
                TempData["ThongBao"] = "Đã cập nhật danh mục [" + danhMuc.TenDanhMuc + "] thành công!";
                return RedirectToAction("Index");
            }
            return View(danhMuc);
        }

        [HttpPost]
        public ActionResult Xoa(int id)
        {
            if (!LaAdmin())
            {
                return RedirectToAction("DangNhap", "TaiKhoan");
            }

            var danhMuc = db.DanhMucs.Find(id);
            if (danhMuc == null)
            {
                return HttpNotFound();
            }

            if (db.SanPhams.Any(s => s.MaDanhMuc == id))
            {
                TempData["ThongBao"] = "Không thể xóa danh mục [" + danhMuc.TenDanhMuc + "] vì còn có sản phẩm! Hãy xóa hoặc chuyển các bánh sang danh mục khác trước.";
                return RedirectToAction("Index");
            }

            db.DanhMucs.Remove(danhMuc);
            db.SaveChanges();
            TempData["ThongBao"] = "Đã xóa danh mục [" + danhMuc.TenDanhMuc + "] thành công!";
            return RedirectToAction("Index");
        }
    }
}
