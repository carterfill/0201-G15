using System.Data.Entity;

namespace SweetBakery.Models
{
    public class ShopDbContext : DbContext
    {
        public ShopDbContext() : base("SweetBakeryConnection")
        {
        }

        public DbSet<DanhMuc> DanhMucs { get; set; }
        public DbSet<SanPham> SanPhams { get; set; }
        public DbSet<NguoiDung> NguoiDungs { get; set; }
        public DbSet<DonHang> DonHangs { get; set; }
        public DbSet<ChiTietDonHang> ChiTietDonHangs { get; set; }
    }
}
