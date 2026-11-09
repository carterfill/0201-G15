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

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // EF6 provider manifest không nhận "decimal(18, 2)" trong TypeName;
            // cấu hình precision/scale tại đây thay thế.
            modelBuilder.Entity<SanPham>().Property(x => x.Gia).HasPrecision(18, 2);
            modelBuilder.Entity<SanPham>().Property(x => x.GiaGoc).HasPrecision(18, 2);
            modelBuilder.Entity<DonHang>().Property(x => x.PhiShip).HasPrecision(18, 2);
            modelBuilder.Entity<DonHang>().Property(x => x.GiamGia).HasPrecision(18, 2);
            modelBuilder.Entity<DonHang>().Property(x => x.TongTien).HasPrecision(18, 2);
            modelBuilder.Entity<ChiTietDonHang>().Property(x => x.Gia).HasPrecision(18, 2);
            modelBuilder.Entity<ChiTietDonHang>().Property(x => x.ThanhTien).HasPrecision(18, 2);

            base.OnModelCreating(modelBuilder);
        }
    }
}
