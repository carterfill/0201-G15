using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SweetBakery.Models
{
    public class ChiTietDonHang
    {
        [Key]
        public int MaChiTiet { get; set; }

        public int MaDonHang { get; set; }

        public virtual DonHang DonHang { get; set; }

        public int MaSanPham { get; set; }

        public virtual SanPham SanPham { get; set; }

        [StringLength(150)]
        public string TenSanPham { get; set; }

        [Column(TypeName = "decimal")]
        public decimal Gia { get; set; }

        [StringLength(255)]
        public string HinhAnh { get; set; }

        public int SoLuong { get; set; }

        [Column(TypeName = "decimal")]
        public decimal ThanhTien { get; set; }
    }
}
