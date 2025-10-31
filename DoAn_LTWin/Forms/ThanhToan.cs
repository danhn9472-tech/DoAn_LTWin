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
        public string maHD;
        public decimal tongTienHD = 0;
        private mainMenu menu;

        public ThanhToan(mainMenu main)
        {
            InitializeComponent();
            this.menu = main;
        }

        private void ThanhToan_Load(object sender, EventArgs e)
        {
            // Chỉ tạo mã HD mới nếu chưa có
            if (string.IsNullOrEmpty(maHD))
            {
                maHD = TaoMaHD();
                txtMaHD.Text = maHD;
            }

            txtTongTien.Text = tongTienHD.ToString("N0") + " VNĐ";
            dtpNgayLap.Value = DateTime.Now;
            txtMaNV.Text = UserSession.UserId;
            dtpNgayLap.Format = DateTimePickerFormat.Custom;
            dtpNgayLap.CustomFormat = "dd/MM/yyyy HH:mm:ss";
            dtpNgayLap.ShowUpDown = true;
        }

        public void LoadChiTietHoaDon()
        {
            using (TapHoaContextDB context = new TapHoaContextDB())
            {
                List<CHITIETHOADON> dsSanPham = context.CHITIETHOADONs
                    .Where(ct => ct.MaHD == txtMaHD.Text)
                    .ToList();
                BindGrid(dsSanPham);
                // Cập nhật tổng tiền
                var hd = context.HOADONs.FirstOrDefault(h => h.MaHD == txtMaHD.Text);
                if (hd != null)
                {
                    txtTongTien.Text = hd.TongTien.ToString("N0") + " VNĐ";
                }
            }
        }

        private void BindGrid(List<CHITIETHOADON> dsSanPham)
        {
            using (TapHoaContextDB context = new TapHoaContextDB())
            {
                dgvSanPham.Rows.Clear();
                foreach (var item in dsSanPham)
                {
                    int index = dgvSanPham.Rows.Add();
                    dgvSanPham.Rows[index].Cells[0].Value = item.MaSP;
                    var sp = context.SANPHAMs.FirstOrDefault(s => s.MaSP == item.MaSP);
                    dgvSanPham.Rows[index].Cells[1].Value = sp.TenSP;
                    dgvSanPham.Rows[index].Cells[2].Value = item.SoLuong;
                    dgvSanPham.Rows[index].Cells[3].Value = item.DonGia;
                }
            }
        }

        private void txtTienNhan_TextChanged(object sender, EventArgs e)
        {
            if (decimal.TryParse(txtTienNhan.Text, out decimal tienNhan))
            {
                using(var context = new TapHoaContextDB())
                {
                    var hd = context.HOADONs.FirstOrDefault(h => h.MaHD == maHD);
                    if (hd != null)
                    {
                        decimal tienThua = tienNhan - hd.TongTien;
                        txtTienThua.Text = tienThua >= 0 ? tienThua.ToString("N0") : "0";
                    }
                }
            }
            else
            {
                txtTienThua.Text = "0";
            }
        }

        private void btnXuatHD_Click(object sender, EventArgs e)
        {
            //rptForm rpt = new rptForm(txtMaHD.Text);
            //rpt.ShowDialog();
            MessageBox.Show("In hóa đơn thành công.");
        }
        private string TaoMaHD()
        {
            using (var context = new TapHoaContextDB())
            {
                var maCuoi = context.HOADONs
                    .OrderByDescending(h => h.MaHD)
                    .Select(h => h.MaHD)
                    .FirstOrDefault();

                if (string.IsNullOrEmpty(maCuoi))
                    return "HD001";

                int so = int.Parse(maCuoi.Substring(2));
                return "HD" + (so + 1).ToString("D3").Trim();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TapHoaContextDB context = new TapHoaContextDB();
            var hd = context.HOADONs.FirstOrDefault(h => h.MaHD == maHD);

            if (hd == null)
            {
                HOADON hoadon = new HOADON()
                {
                    MaHD = maHD,
                    MaNV = txtMaNV.Text,
                    NgayLap = dtpNgayLap.Value,
                    TongTien = 0
                };
                context.HOADONs.Add(hoadon);
                context.SaveChanges();
            }

            menu.openChildForm1(new Forms.BanHang(menu, maHD), sender);
        }

        private void txtSDT_Enter(object sender, EventArgs e)
        {
            string sdt = txtSDT.Text.Trim();
            if (sdt.Length < 6)
            {
                txtMaKH.Text = "";
                txtTenKH.Text = "";
                return;
            }
            using (var context = new TapHoaContextDB())
            {
                var kh = context.KHACHHANGs.FirstOrDefault(k => k.SDT == sdt);

                if (kh != null)
                {
                    MessageBox.Show("Áp dụng giảm giá 3% cho hóa đơn.");
                    txtMaKH.Text = kh.MaKH;
                    txtTenKH.Text = kh.TenKH;
                    var hd = context.HOADONs.FirstOrDefault(h => h.MaHD == maHD);
                    hd.MaKH = kh.MaKH;
                    hd.TongTien = hd.TongTien-hd.TongTien*0.03m;
                    context.SaveChanges();
                    txtTongTien.Text = hd.TongTien.ToString("N0") + " VNĐ";

                }
                else
                {
                    txtMaKH.Text = "";
                    txtTenKH.Text = "";
                }
            }
        }
    }
}