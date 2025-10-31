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
    public partial class ThongKe2 : Form
    {
        private mainMenu menu;
        public ThongKe2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            LoadComboBoxData();
            LoadSanPham();
        }

        private void LoadComboBoxData()
        {
            using (var db = new TapHoaContextDB())
            {
                // Load sản phẩm
                var sanphamList = db.SANPHAMs
                    .Select(sp => new { sp.MaSP, sp.TenSP })
                    .ToList();
                cmbSP.DataSource = sanphamList;
                cmbSP.DisplayMember = "TenSP";
                cmbSP.ValueMember = "MaSP";
                cmbSP.SelectedIndex = -1;

                // Tạo danh sách Ngày - Tháng - Năm
                cmbNgay.DataSource = Enumerable.Range(1, 31).ToList();
                cmbThang.DataSource = Enumerable.Range(1, 12).ToList();
                cmbNam.DataSource = Enumerable.Range(2020, 6).ToList(); // 2020–2025

                cmbNgay.SelectedIndex = -1;
                cmbThang.SelectedIndex = -1;
                cmbNam.SelectedIndex = -1;
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            try
            {
                using (var db = new TapHoaContextDB())
                {
                    // FIXED: Include cả SANPHAM và HOADON, không trùng lặp
                    var result = db.CHITIETHOADONs
                        .Include("SANPHAM")
                        .Include("HOADON")
                        .AsEnumerable(); // sang LINQ to Objects để xử lý dễ hơn

                    // lọc sản phẩm nếu có chọn
                    if (cmbSP.SelectedIndex != -1)
                    {
                        string masp = cmbSP.SelectedValue.ToString();
                        result = result.Where(x => x.MaSP == masp);
                    }

                    // lọc năm - FIXED: Thêm kiểm tra HasValue
                    if (cmbNam.SelectedIndex != -1)
                    {
                        int nam = (int)cmbNam.SelectedItem;
                        result = result.Where(x => x.HOADON != null &&
                                                  x.HOADON.NgayLap.HasValue &&
                                                  x.HOADON.NgayLap.Value.Year == nam);
                    }

                    // lọc tháng - FIXED: Thêm kiểm tra HasValue
                    if (cmbThang.SelectedIndex != -1)
                    {
                        int thang = (int)cmbThang.SelectedItem;
                        result = result.Where(x => x.HOADON != null &&
                                                  x.HOADON.NgayLap.HasValue &&
                                                  x.HOADON.NgayLap.Value.Month == thang);
                    }

                    // lọc ngày - FIXED: Thêm điều kiện lọc theo ngày
                    if (cmbNgay.SelectedIndex != -1)
                    {
                        int ngay = (int)cmbNgay.SelectedItem;
                        result = result.Where(x => x.HOADON != null &&
                                                  x.HOADON.NgayLap.HasValue &&
                                                  x.HOADON.NgayLap.Value.Day == ngay);
                    }

                    // Gom nhóm theo sản phẩm
                    var thongke = result
                        .Where(x => x.SANPHAM != null) // Đảm bảo SANPHAM không null
                        .GroupBy(x => new { x.MaSP, x.SANPHAM.TenSP })
                        .Select(g => new
                        {
                            MSP = g.Key.MaSP,
                            TSP = g.Key.TenSP,
                            SLB = g.Sum(x => x.SoLuong ?? 0),
                            DT = g.Sum(x => (x.SoLuong ?? 0) * (x.SANPHAM.DonGia ?? 0))
                        })
                        .OrderByDescending(x => x.SLB)
                        .ToList();

                    // lọc theo Top nếu có nhập
                    if (!string.IsNullOrWhiteSpace(txtTop.Text))
                    {
                        if (int.TryParse(txtTop.Text, out int topN) && topN > 0)
                        {
                            thongke = thongke.Take(topN).ToList();
                        }
                        else
                        {
                            MessageBox.Show("Vui lòng nhập số Top hợp lệ!", "Cảnh báo",
                                          MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }

                    dgvThongKe.DataSource = thongke;

                    // Hiển thị thông báo nếu không có dữ liệu
                    if (thongke.Count == 0)
                    {
                        MessageBox.Show("Không có dữ liệu thống kê phù hợp!", "Thông báo",
                                      MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi thống kê: {ex.Message}\n\nChi tiết: {ex.InnerException?.Message}",
                              "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadSanPham()
        {
            using (var db = new TapHoaContextDB())
            {
                // Lấy danh sách sản phẩm từ DB
                var listSP = db.SANPHAMs
                    .Select(sp => new { sp.MaSP, sp.TenSP })
                    .ToList();

                // Gán dữ liệu cho ComboBox
                cmbSP.DataSource = listSP;
                cmbSP.DisplayMember = "TenSP";
                cmbSP.ValueMember = "MaSP";

                cmbSP.SelectedIndex = -1;
            }
        }

        private void btnMoi_Click(object sender, EventArgs e)
        {
            cmbSP.SelectedIndex = -1;
            cmbNgay.SelectedIndex = -1;
            cmbNam.SelectedIndex = -1;
            cmbThang.SelectedIndex = -1;
            txtTop.Clear();
            dgvThongKe.DataSource = new List<object>();
        }

        private void txtTop_TextChanged(object sender, EventArgs e)
        {
        }
    }
}