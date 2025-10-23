using DoAn_LTWin.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAn_LTWin.Forms
{
    public partial class ThanhToan : Form
    {
        private List<SanPhamDaChon> danhSachSP;
        private decimal tongTien;
        public ThanhToan(List<SanPhamDaChon> dsSP, decimal tongTien)
        {
            InitializeComponent();
            this.danhSachSP = dsSP;
            this.tongTien = tongTien;
            txtTenNV.Text = UserSession.UserId;
        }

        private void ThanhToan_Load(object sender, EventArgs e)
        {
            dgvSanPham.DataSource = danhSachSP;
            txtTongTien.Text = tongTien.ToString("N0");
            dtpNgayLap.Value = DateTime.Now;
        }

        private void txtTienNhan_TextChanged(object sender, EventArgs e)
        {
            if (decimal.TryParse(txtTienNhan.Text, out decimal tienNhan))
            {
                decimal tienThua = tienNhan - tongTien;
                txtTienThua.Text = tienThua >= 0 ? tienThua.ToString("N0") : "0";
            }
            else
            {
                txtTienThua.Text = "0";
            }
        }

        private void btnXuatHD_Click(object sender, EventArgs e)
        {
            using (var context = new TapHoaContextDB())
            {
                // Lưu khách hàng
                var kh = context.KHACHHANGs.Find(txtMaKH.Text);
                if (kh == null)
                {
                    kh = new KHACHHANG
                    {
                        MaKH = txtMaKH.Text,
                        TenKH = txtTenKH.Text,
                        SDT = txtSDT.Text
                    };
                    context.KHACHHANGs.Add(kh);
                }

                // Lưu hóa đơn
                var hd = new HOADON
                {
                    MaHD = TaoMaHD(),
                    MaKH = txtMaKH.Text,
                    NgayLap = dtpNgayLap.Value,
                    TongTien = tongTien
                };
                context.HOADONs.Add(hd);

                // Lưu chi tiết hóa đơn
                foreach (var sp in danhSachSP)
                {
                    var ct = new CHITIETHOADON
                    {
                        MaCTHD = TaoMaCTHD(),
                        MaHD = hd.MaHD,
                        MaSP = sp.MaSP,
                        SoLuong = sp.SoLuong,
                        DonGia = sp.DonGia
                    };
                    context.CHITIETHOADONs.Add(ct);
                }

                context.SaveChanges();
                MessageBox.Show("Lưu hóa đơn thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            
        }
        private string TaoMaHD()
        {
            using (var context = new TapHoaContextDB())
            {
                // Lấy mã hóa đơn cuối cùng
                var maCuoi = context.HOADONs
                    .OrderByDescending(h => h.MaHD)
                    .Select(h => h.MaHD)
                    .FirstOrDefault();

                if (string.IsNullOrEmpty(maCuoi))
                    return "HD001";

                // Tách số từ mã cuối
                int so = int.Parse(maCuoi.Substring(2));
                return "HD" + (so + 1).ToString("D3");
            }
        }
        private string TaoMaCTHD()
        {
            using (var context = new TapHoaContextDB())
            {
                var maCuoi = context.CHITIETHOADONs
                    .OrderByDescending(ct => ct.MaCTHD)
                    .Select(ct => ct.MaCTHD)
                    .FirstOrDefault();

                if (string.IsNullOrEmpty(maCuoi))
                    return "CT001";

                if (string.IsNullOrEmpty(maCuoi) || maCuoi.Length < 3 || !int.TryParse(maCuoi.Substring(2), out int so))
                {
                    return "CH001";
                }
                return "CH" + (so + 1).ToString("D3");
            }
        }
    }
}
