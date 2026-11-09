using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SweetBakery.Models
{
    public class SanPham
    {
        [Key]
        public int MaSanPham { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập tên bánh")]
        [StringLength(150)]
        [Display(Name = "Tên bánh")]
        public string TenSanPham { get; set; }

        [StringLength(1000)]
        [Display(Name = "Mô tả ngắn")]
        [DataType(DataType.MultilineText)]
        public string MoTa { get; set; }

        [Display(Name = "Mô tả chi tiết")]
        [DataType(DataType.MultilineText)]
        public string MoTaChiTiet { get; set; }

        [Display(Name = "Thành phần")]
        [DataType(DataType.MultilineText)]
        public string ThanhPhan { get; set; }

        [StringLength(500)]
        [Display(Name = "Hướng dẫn bảo quản")]
        [DataType(DataType.MultilineText)]
        public string BaoQuan { get; set; }

        [StringLength(255)]
        [Display(Name = "Quy cách / Kích thước")]
        public string KichThuoc { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập giá bán")]
        [Column(TypeName = "decimal")]
        [Range(1000, 100000000, ErrorMessage = "Giá bán phải từ 1.000 đ đến 100.000.000 đ")]
        [Display(Name = "Giá bán")]
        public decimal Gia { get; set; }

        [Column(TypeName = "decimal")]
        [Range(0, 100000000, ErrorMessage = "Giá gốc không hợp lệ")]
        [Display(Name = "Giá gốc")]
        public decimal? GiaGoc { get; set; }

        [StringLength(255)]
        [Display(Name = "Hình ảnh")]
        public string HinhAnh { get; set; }

        [Range(1, 5, ErrorMessage = "Số sao phải từ 1 đến 5")]
        [Display(Name = "Đánh giá")]
        public int Sao { get; set; }

        [Display(Name = "Đã bán")]
        public int DaBan { get; set; }

        [Display(Name = "Bán chạy")]
        public bool Hot { get; set; }

        [Required(ErrorMessage = "Vui lòng chọn danh mục")]
        [Display(Name = "Danh mục")]
        public int MaDanhMuc { get; set; }

        public virtual DanhMuc DanhMuc { get; set; }
    }
}
