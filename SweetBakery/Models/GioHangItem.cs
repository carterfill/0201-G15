namespace SweetBakery.Models
{
    public class GioHangItem
    {
        public int MaSanPham { get; set; }
        public int SoLuong { get; set; }
    }

    public class MonTrongGio
    {
        public SanPham SanPham { get; set; }
        public int SoLuong { get; set; }

        public decimal ThanhTien
        {
            get { return SanPham.Gia * SoLuong; }
        }
    }
}
