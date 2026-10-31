using System;
using System.Linq;
using System.Web.Mvc;
using SweetBakery.Models;

namespace SweetBakery.Controllers
{
    public class SanPhamController : Controller
    {
        private ShopDbContext db = new ShopDbContext();

        public ActionResult DanhSach(string tuKhoa, int? maDanhMuc, string khoangGia, string sapXep, int? trang)
        {
            var sanPhams = db.SanPhams.AsQueryable();

            if (!string.IsNullOrEmpty(tuKhoa))
            {
                sanPhams = sanPhams.Where(s => s.TenSanPham.Contains(tuKhoa) || s.MoTa.Contains(tuKhoa));
            }

            if (maDanhMuc.HasValue)
            {
                sanPhams = sanPhams.Where(s => s.MaDanhMuc == maDanhMuc.Value);
            }

            if (khoangGia == "duoi-50")
            {
                sanPhams = sanPhams.Where(s => s.Gia < 50000);
            }
            else if (khoangGia == "50-150")
            {
                sanPhams = sanPhams.Where(s => s.Gia >= 50000 && s.Gia <= 150000);
            }
            else if (khoangGia == "tren-150")
            {
                sanPhams = sanPhams.Where(s => s.Gia > 150000);
            }

            if (sapXep == "gia-tang")
            {
                sanPhams = sanPhams.OrderBy(s => s.Gia);
            }
            else if (sapXep == "gia-giam")
            {
                sanPhams = sanPhams.OrderByDescending(s => s.Gia);
            }
            else if (sapXep == "ten-az")
            {
                sanPhams = sanPhams.OrderBy(s => s.TenSanPham);
            }
            else
            {
                sanPhams = sanPhams.OrderByDescending(s => s.DaBan);
            }

            int soLuongMoiTrang = 9;
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
            ViewBag.KhoangGia = khoangGia;
            ViewBag.SapXep = sapXep;
            ViewBag.TrangHienTai = trangHienTai;
            ViewBag.TongSoTrang = tongSoTrang;
            ViewBag.TongSoSanPham = tongSoSanPham;

            return View(ketQua);
        }

        public ActionResult ChiTiet(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            var sanPham = db.SanPhams.Find(id.Value);
            if (sanPham == null)
            {
                return HttpNotFound();
            }

            var sanPhamLienQuan = db.SanPhams
                .Where(s => s.MaDanhMuc == sanPham.MaDanhMuc && s.MaSanPham != sanPham.MaSanPham)
                .OrderByDescending(s => s.DaBan)
                .Take(3)
                .ToList();
            if (sanPhamLienQuan.Count == 0)
            {
                sanPhamLienQuan = db.SanPhams
                    .Where(s => s.MaSanPham != sanPham.MaSanPham)
                    .OrderByDescending(s => s.DaBan)
                    .Take(3)
                    .ToList();
            }

            ViewBag.SanPhamLienQuan = sanPhamLienQuan;
            return View(sanPham);
        }
    }
}
