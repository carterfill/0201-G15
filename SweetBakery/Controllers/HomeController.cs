using System.Linq;
using System.Web.Mvc;
using SweetBakery.Models;

namespace SweetBakery.Controllers
{
    public class HomeController : Controller
    {
        private ShopDbContext db = new ShopDbContext();

        public ActionResult Index()
        {
            ViewBag.DanhMucs = db.DanhMucs.OrderBy(d => d.MaDanhMuc).ToList();
            var banhNoiBat = db.SanPhams.OrderByDescending(s => s.DaBan).Take(8).ToList();
            return View(banhNoiBat);
        }

        public ActionResult LienHe()
        {
            return View();
        }

        [HttpPost]
        public ActionResult GuiLienHe(string hoTen, string email, string noiDung)
        {
            TempData["ThongBao"] = "Cảm ơn bạn đã gửi tin nhắn! Sweet Bakery sẽ phản hồi trong thời gian sớm nhất.";
            return RedirectToAction("LienHe");
        }
    }
}
