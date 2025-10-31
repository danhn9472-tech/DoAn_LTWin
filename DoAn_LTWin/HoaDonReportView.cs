using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAn_LTWin
{
    internal class HoaDonReportView
    {
        public string MaHD { get; set; }
        public string MaKH { get; set; }
        public string TenKH { get; set; }
        public string SDT { get; set; }
        public string MaNV { get; set; }
        public DateTime? NgayLap { get; set; }
        public string MaSP { get; set; }
        public string TenSP { get; set; }
        public int? SoLuong { get; set; }
        public decimal? DonGia { get; set; }
        public decimal? TongHang { get; set; }
        public decimal GiamGia { get; set; }
        public decimal ThanhToan { get; set; }
    }
}
