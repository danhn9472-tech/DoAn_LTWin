using DoAn_LTWin.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAn_LTWin.Forms
{
    public partial class ThongKe1 : Form
    {
        private mainMenu menu;
        public ThongKe1(mainMenu menu)
        {
            InitializeComponent();
            this.menu = menu;
        }

        private void SPBCToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ThongKe2 form2 = new ThongKe2();
            form2.ShowDialog();
        }

        private void btnTK_Click(object sender, EventArgs e)
        {
            try
            {
                using (var db = new TapHoaContextDB())
                {
                    // Lấy toàn bộ dữ liệu từ 3 bảng
                    var data = db.CHITIETHOADONs
                        .Include("SANPHAM")
                        .Include("HOADON")
                        .ToList();

                    // Lọc theo sản phẩm (nếu chọn)
                    if (cmbSP.SelectedIndex != -1)
                    {
                        string maSP = cmbSP.SelectedValue.ToString();
                        data = data.Where(x => x.MaSP == maSP).ToList();
                    }

                    // Lọc theo năm
                    if (cmbNam.SelectedIndex != -1)
                    {
                        int nam = (int)cmbNam.SelectedItem;
                        data = data.Where(x => x.HOADON != null &&
                                               x.HOADON.NgayLap.HasValue &&
                                               x.HOADON.NgayLap.Value.Year == nam).ToList();
                    }

                    // Lọc theo tháng
                    if (cmbThang.SelectedIndex != -1)
                    {
                        int thang = (int)cmbThang.SelectedItem;
                        data = data.Where(x => x.HOADON != null &&
                                               x.HOADON.NgayLap.HasValue &&
                                               x.HOADON.NgayLap.Value.Month == thang).ToList();
                    }

                    // Lọc theo ngày
                    if (cmbNgay.SelectedIndex != -1)
                    {
                        int ngay = (int)cmbNgay.SelectedItem;
                        data = data.Where(x => x.HOADON != null &&
                                               x.HOADON.NgayLap.HasValue &&
                                               x.HOADON.NgayLap.Value.Day == ngay).ToList();
                    }

                    // Chuẩn bị dữ liệu hiển thị
                    var result = data
                        .Where(x => x.SANPHAM != null) // Đảm bảo SANPHAM không null
                        .Select(x => new
                        {
                            MSP = x.MaSP,
                            TSP = x.SANPHAM.TenSP,
                            DGia = x.SANPHAM.DonGia ?? 0,
                            SLB = x.SoLuong ?? 0,
                            DT = (x.SoLuong ?? 0) * (x.SANPHAM.DonGia ?? 0),
                            NBan = x.HOADON?.NgayLap
                        }).ToList();

                    // Gán vào DataGridView
                    dgvThongKe.DataSource = result;

                    // Tổng doanh thu - FIXED
                    txtTong.Text = result.Sum(x => x.DT).ToString("N0");

                    // Hiển thị thông báo nếu không có dữ liệu
                    if (result.Count == 0)
                    {
                        MessageBox.Show("Không có dữ liệu thống kê phù hợp!", "Thông báo",
                                      MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi thống kê: {ex.Message}", "Lỗi",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadComboBoxData()
        {
            using (var db = new TapHoaContextDB())
            {
                // Load sản phẩm
                var sanPhams = db.SANPHAMs
                    .Select(sp => new { sp.MaSP, sp.TenSP })
                    .ToList();

                cmbSP.DataSource = sanPhams;
                cmbSP.DisplayMember = "TenSP";
                cmbSP.ValueMember = "MaSP";
                cmbSP.SelectedIndex = -1;
            }

            // Tạo danh sách Ngày - Tháng - Năm
            cmbNgay.DataSource = Enumerable.Range(1, 31).ToList();
            cmbThang.DataSource = Enumerable.Range(1, 12).ToList();
            cmbNam.DataSource = Enumerable.Range(2020, 6).ToList(); // 2020–2025

            cmbNgay.SelectedIndex = -1;
            cmbThang.SelectedIndex = -1;
            cmbNam.SelectedIndex = -1;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadComboBoxData();
            LoadSanPham();
        }

        private void LoadSanPham()
        {
            using (var db = new TapHoaContextDB())
            {
                var listSP = db.SANPHAMs.ToList();

                cmbSP.DataSource = listSP;
                cmbSP.DisplayMember = "TenSP";
                cmbSP.ValueMember = "MaSP";
                cmbSP.SelectedIndex = -1;
            }
        }

        private void btnMoi_Click(object sender, EventArgs e)
        {
            // FIXED: Reset tất cả về -1
            cmbSP.SelectedIndex = -1;
            cmbNgay.SelectedIndex = -1;
            cmbThang.SelectedIndex = -1;
            cmbNam.SelectedIndex = -1;

            txtTong.Text = "";
            dgvThongKe.DataSource = new List<object>();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            menu.openChildForm1(new Forms.ThongKe2(), sender);
        }
    }
}