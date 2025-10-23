using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAn_LTWin
{
    public class HoaDonGet
    {
        public class HoaDonInfo
        {
            public string MaHD { get; set; }
            public DateTime NgayLap { get; set; }
            public string MaNV { get; set; }
            public decimal TongTien { get; set; }
        }
        public class ChiTietHoaDonInfo
        {
            public string MaHD { get; set; }
            public string MaSP { get; set; }
            public int SoLuong { get; set; }
            public decimal DonGia { get; set; }
            public decimal ThanhTien { get; set; }
        }
    }
}
