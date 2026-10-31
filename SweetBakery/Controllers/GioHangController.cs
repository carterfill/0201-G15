using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using SweetBakery.Models;

namespace SweetBakery.Controllers
{
    public class GioHangController : Controller
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

        public ActionResult Index()
        {
            var gioHang = LayGioHang();
            var dsMon = new List<MonTrongGio>();
            foreach (var item in gioHang)
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
            ViewBag.MaGiamGia = Session["MaGiamGia"] as string;
            return View(dsMon);
        }

        [HttpPost]
        public ActionResult Them(int id, int soLuong = 1, bool muaNgay = false)
        {
            var sanPham = db.SanPhams.Find(id);
            if (sanPham == null)
            {
                return HttpNotFound();
            }
            if (soLuong < 1)
            {
                soLuong = 1;
            }

            var gioHang = LayGioHang();
            var item = gioHang.FirstOrDefault(g => g.MaSanPham == id);
            if (item != null)
            {
                item.SoLuong += soLuong;
            }
            else
            {
                gioHang.Add(new GioHangItem { MaSanPham = id, SoLuong = soLuong });
            }

            TempData["ThongBao"] = "Đã thêm [" + sanPham.TenSanPham + "] vào giỏ hàng! 🛒";

            if (muaNgay)
            {
                return RedirectToAction("DatHang", "DonHang");
            }
            return RedirectToAction("Index", "GioHang");
        }

        [HttpPost]
        public ActionResult CapNhat(int id, int soLuong)
        {
            var gioHang = LayGioHang();
            var item = gioHang.FirstOrDefault(g => g.MaSanPham == id);
            if (item != null)
            {
                if (soLuong < 1)
                {
                    soLuong = 1;
                }
                if (soLuong > 99)
                {
                    soLuong = 99;
                }
                item.SoLuong = soLuong;
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Xoa(int id)
        {
            var gioHang = LayGioHang();
            var item = gioHang.FirstOrDefault(g => g.MaSanPham == id);
            if (item != null)
            {
                gioHang.Remove(item);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult XoaTatCa()
        {
            LayGioHang().Clear();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult ApDungVoucher(string maVoucher)
        {
            var ma = (maVoucher ?? "").Trim().ToUpper();
            if (ma == "SWEET20")
            {
                Session["MaGiamGia"] = ma;
                TempData["ThongBao"] = "Áp dụng mã SWEET20 thành công: Giảm 20.000 đ!";
            }
            else if (ma == "FREESHIP")
            {
                Session["MaGiamGia"] = ma;
                TempData["ThongBao"] = "Áp dụng mã FREESHIP thành công: Miễn phí vận chuyển!";
            }
            else
            {
                TempData["ThongBao"] = "Mã giảm giá không hợp lệ hoặc đã hết hạn! Thử mã: SWEET20 hoặc FREESHIP";
            }
            return RedirectToAction("Index");
        }
    }
}
