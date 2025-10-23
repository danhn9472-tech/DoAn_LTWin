using DoAn_LTWin.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAn_LTWin.Forms
{
    public partial class BanHang : Form
    {
        private mainMenu menu;
        public BanHang(mainMenu main)
        {
            InitializeComponent();
            this.menu = main;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dgvBanHang.CurrentRow != null)
            {
                dgvBanHang.Rows.RemoveAt(dgvBanHang.CurrentRow.Index);
                TinhTongTien();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            List<SanPhamDaChon> danhSachSP = new List<SanPhamDaChon>();

            foreach (DataGridViewRow row in dgvBanHang.Rows)
            {
                if (row.Cells[0].Value != null) // tránh dòng trống
                {
                    int soLuong = Convert.ToInt32(row.Cells[2].Value);
                    decimal thanhTien = Convert.ToDecimal(row.Cells[3].Value);
                    decimal donGia = thanhTien / soLuong;

                    danhSachSP.Add(new SanPhamDaChon
                    {
                        MaSP = row.Cells[0].Value.ToString(),
                        TenSP = row.Cells[1].Value.ToString(),
                        SoLuong = soLuong,
                        DonGia = donGia
                    });
                }
            }
            decimal tongTien = 0;
            foreach (var sp in danhSachSP)
            {
                tongTien += sp.SoLuong * sp.DonGia;
            }

            menu.openChildForm1(new ThanhToan(danhSachSP, tongTien),sender);
        }

        private void BanHang_Load(object sender, EventArgs e)
        {
            using (var context = new TapHoaContextDB())
            {
                var danhSachSP = context.SANPHAMs
                    .Where(sp => sp.TrangThai == "Còn kinh doanh")
                    .ToList();

                cmbTenSP.DataSource = danhSachSP;
                cmbTenSP.DisplayMember = "TenSP";
                cmbTenSP.ValueMember = "MaSP";
            }
        }
        private void TinhTongTien()
        {
            decimal tongTien = 0;
            foreach (DataGridViewRow row in dgvBanHang.Rows)
            {
                if (row.Cells[3].Value != null)
                {
                    tongTien += Convert.ToDecimal(row.Cells[3].Value);
                }
            }

            txtTongTien.Text = tongTien.ToString("N0") + " VNĐ";
        }

        private void cmbTenSP_SelectedIndexChanged(object sender, EventArgs e)
        {
            var sp = cmbTenSP.SelectedItem as SANPHAM;

            if (sp != null)
            {
                txtMaSP.Text = sp.MaSP;
                txtGia.Text = sp.DonGia?.ToString("N0") ?? "0";


                string path = Path.Combine(Application.StartupPath, "Images", sp.Avatar);
                picItem.Image = File.Exists(path) ? Image.FromFile(path) : null;
                picItem.SizeMode = PictureBoxSizeMode.Zoom;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int soLuong = int.Parse(txtSoluong.Text);
            decimal donGia = decimal.Parse(txtGia.Text);
            decimal thanhTien = donGia * soLuong;

            dgvBanHang.Rows.Add(txtMaSP.Text, cmbTenSP.Text, soLuong, thanhTien);
            TinhTongTien();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dgvBanHang.CurrentRow != null)
            {
                int index = dgvBanHang.CurrentRow.Index;
                int soLuong = int.Parse(txtSoluong.Text);
                decimal donGia = decimal.Parse(txtGia.Text);
                decimal thanhTien = donGia * soLuong;

                dgvBanHang.Rows[index].SetValues(txtMaSP.Text, cmbTenSP.Text, soLuong, thanhTien);
                TinhTongTien();
            }
        }
    }
}
