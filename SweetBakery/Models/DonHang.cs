using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SweetBakery.Models
{
    public class DonHang
    {
        [Key]
        public int MaDonHang { get; set; }

        public int MaNguoiDung { get; set; }

        public virtual NguoiDung NguoiDung { get; set; }

        [Display(Name = "Ngày đặt")]
        public DateTime NgayDat { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập họ tên người nhận")]
        [StringLength(100)]
        [Display(Name = "Họ tên người nhận")]
        public string HoTenNguoiNhan { get; set; }

        [StringLength(15)]
        [Display(Name = "Số điện thoại")]
        public string SoDienThoai { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập địa chỉ nhận bánh")]
        [StringLength(255)]
        [Display(Name = "Địa chỉ nhận hàng")]
        public string DiaChiGiao { get; set; }

        [StringLength(500)]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Ghi chú")]
        public string GhiChu { get; set; }

        [StringLength(100)]
        [Display(Name = "Phương thức thanh toán")]
        public string PhuongThucThanhToan { get; set; }

        [StringLength(100)]
        [Display(Name = "Trạng thái thanh toán")]
        public string TrangThaiThanhToan { get; set; }

        [Display(Name = "Trạng thái đơn")]
        public int TrangThai { get; set; }

        [Column(TypeName = "decimal")]
        [Display(Name = "Phí giao hàng")]
        public decimal PhiShip { get; set; }

        [Column(TypeName = "decimal")]
        [Display(Name = "Giảm giá")]
        public decimal GiamGia { get; set; }

        [Column(TypeName = "decimal")]
        [Display(Name = "Tổng tiền")]
        public decimal TongTien { get; set; }

        public virtual ICollection<ChiTietDonHang> ChiTietDonHangs { get; set; } = new List<ChiTietDonHang>();
    }
}
