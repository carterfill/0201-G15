using System.Security.Cryptography;
using System.Text;

namespace SweetBakery.Models
{
    public static class BaoMat
    {
        public static string BamMatKhau(string matKhau)
        {
            SHA256 sha = SHA256.Create();
            byte[] duLieu = sha.ComputeHash(Encoding.UTF8.GetBytes(matKhau));
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < duLieu.Length; i++)
            {
                sb.Append(duLieu[i].ToString("x2"));
            }
            return sb.ToString();
        }
    }
}
