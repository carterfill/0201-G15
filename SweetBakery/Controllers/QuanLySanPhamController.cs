using System;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SweetBakery.Models;

namespace SweetBakery.Controllers
{
    public class QuanLySanPhamController : Controller
    {
        private ShopDbContext db = new ShopDbContext();

        private bool LaAdmin()
        {
            return Session["VaiTro"] as string == "admin";
        }

        public ActionResult Index(string tuKhoa, int? maDanhMuc, string sapXep, int? trang)
        {
            if (!LaAdmin())
            {
                return RedirectToAction("DangNhap", "TaiKhoan");
            }

            var sanPhams = db.SanPhams.AsQueryable();

            if (!string.IsNullOrEmpty(tuKhoa))
            {
                sanPhams = sanPhams.Where(s => s.TenSanPham.Contains(tuKhoa));
            }

            if (maDanhMuc.HasValue)
            {
                sanPhams = sanPhams.Where(s => s.MaDanhMuc == maDanhMuc.Value);
            }

            if (sapXep == "ten-az")
            {
                sanPhams = sanPhams.OrderBy(s => s.TenSanPham);
            }
            else if (sapXep == "ten-za")
            {
                sanPhams = sanPhams.OrderByDescending(s => s.TenSanPham);
            }
            else if (sapXep == "gia-tang")
            {
                sanPhams = sanPhams.OrderBy(s => s.Gia);
            }
            else if (sapXep == "gia-giam")
            {
                sanPhams = sanPhams.OrderByDescending(s => s.Gia);
            }
            else if (sapXep == "ban-chay")
            {
                sanPhams = sanPhams.OrderByDescending(s => s.DaBan);
            }
            else
            {
                sanPhams = sanPhams.OrderByDescending(s => s.MaSanPham);
            }

            int soLuongMoiTrang = 10;
            int tongSoSanPham = sanPhams.Count();
            int tongSoTrang = (int)Math.Ceiling((double)tongSoSanPham / soLuongMoiTrang);
            int trangHienTai = trang ?? 1;
            if (trangHienTai < 1)
            {
                trangHienTai = 1;
            }
            if (trangHienTai > tongSoTrang && tongSoTrang > 0)
            {
                trangHienTai = tongSoTrang;
            }

            var ketQua = sanPhams.Skip((trangHienTai - 1) * soLuongMoiTrang).Take(soLuongMoiTrang).ToList();

            ViewBag.DanhMucs = db.DanhMucs.OrderBy(d => d.MaDanhMuc).ToList();
            ViewBag.TuKhoa = tuKhoa;
            ViewBag.MaDanhMuc = maDanhMuc;
            ViewBag.SapXep = sapXep;
            ViewBag.TrangHienTai = trangHienTai;
            ViewBag.TongSoTrang = tongSoTrang;
            ViewBag.TongSoSanPham = tongSoSanPham;

            return View(ketQua);
        }

        public ActionResult Them()
        {
            if (!LaAdmin())
            {
                return RedirectToAction("DangNhap", "TaiKhoan");
            }

            ViewBag.DanhMucs = db.DanhMucs.OrderBy(d => d.TenDanhMuc).ToList();
            return View();
        }

        [HttpPost]
        public ActionResult Them(SanPham sanPham, HttpPostedFileBase hinhAnhFile)
        {
            if (!LaAdmin())
            {
                return RedirectToAction("DangNhap", "TaiKhoan");
            }

            if (sanPham.GiaGoc.HasValue && sanPham.GiaGoc.Value <= 0)
            {
                sanPham.GiaGoc = null;
            }

            if (ModelState.IsValid)
            {
                sanPham.HinhAnh = LuuHinhAnh(hinhAnhFile, "croissant.jpg");
                db.SanPhams.Add(sanPham);
                db.SaveChanges();
                TempData["ThongBao"] = "Đã thêm bánh [" + sanPham.TenSanPham + "] thành công!";
                return RedirectToAction("Index");
            }

            ViewBag.DanhMucs = db.DanhMucs.OrderBy(d => d.TenDanhMuc).ToList();
            return View(sanPham);
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

            var sanPham = db.SanPhams.Find(id.Value);
            if (sanPham == null)
            {
                return HttpNotFound();
            }

            ViewBag.DanhMucs = db.DanhMucs.OrderBy(d => d.TenDanhMuc).ToList();
            return View(sanPham);
        }

        [HttpPost]
        public ActionResult Sua(SanPham sanPham, HttpPostedFileBase hinhAnhFile)
        {
            if (!LaAdmin())
            {
                return RedirectToAction("DangNhap", "TaiKhoan");
            }

            if (sanPham.GiaGoc.HasValue && sanPham.GiaGoc.Value <= 0)
            {
                sanPham.GiaGoc = null;
            }

            if (ModelState.IsValid)
            {
                var sanPhamCu = db.SanPhams.Find(sanPham.MaSanPham);
                if (sanPhamCu == null)
                {
                    return HttpNotFound();
                }

                sanPham.HinhAnh = LuuHinhAnh(hinhAnhFile, sanPhamCu.HinhAnh);

                db.Entry(sanPhamCu).CurrentValues.SetValues(sanPham);
                db.SaveChanges();
                TempData["ThongBao"] = "Đã cập nhật bánh [" + sanPham.TenSanPham + "] thành công!";
                return RedirectToAction("Index");
            }

            ViewBag.DanhMucs = db.DanhMucs.OrderBy(d => d.TenDanhMuc).ToList();
            return View(sanPham);
        }

        [HttpPost]
        public ActionResult Xoa(int id)
        {
            if (!LaAdmin())
            {
                return RedirectToAction("DangNhap", "TaiKhoan");
            }

            var sanPham = db.SanPhams.Find(id);
            if (sanPham == null)
            {
                return HttpNotFound();
            }

            if (db.ChiTietDonHangs.Any(c => c.MaSanPham == id))
            {
                TempData["ThongBao"] = "Không thể xóa bánh [" + sanPham.TenSanPham + "] vì đã có trong đơn hàng của khách!";
                return RedirectToAction("Index");
            }

            db.SanPhams.Remove(sanPham);
            db.SaveChanges();
            TempData["ThongBao"] = "Đã xóa bánh [" + sanPham.TenSanPham + "] thành công!";
            return RedirectToAction("Index");
        }

        private string LuuHinhAnh(HttpPostedFileBase hinhAnhFile, string hinhAnhCu)
        {
            if (hinhAnhFile != null && hinhAnhFile.ContentLength > 0)
            {
                var duoiFile = Path.GetExtension(hinhAnhFile.FileName).ToLower();
                if (duoiFile == ".jpg" || duoiFile == ".jpeg" || duoiFile == ".png" || duoiFile == ".gif")
                {
                    var tenFile = Path.GetFileName(hinhAnhFile.FileName);
                    var duongDan = Server.MapPath("~/Content/images/" + tenFile);
                    hinhAnhFile.SaveAs(duongDan);
                    return tenFile;
                }
            }
            return hinhAnhCu;
        }
    }
}
