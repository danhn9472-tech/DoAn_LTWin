using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAn_LTWin
{
    public class HoaDonSession
    {
        public static string MaHD { get; set; }
        public static string TenSP { get; set; }
        public static int SoLuong { get; set; }
        public static decimal DonGia { get; set; }
        public static void Clear()
        {
            MaHD = null;
            TenSP = null;
            SoLuong = 0;
            DonGia = 0;
        }
    }
}
