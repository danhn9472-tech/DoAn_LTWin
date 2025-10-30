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
        private string maHoaDon;
        private mainMenu menu;

        public BanHang(mainMenu main, string maHD)
        {
            InitializeComponent();
            menu = main;
            maHoaDon = maHD;
        }

        private void BanHang_Load(object sender, EventArgs e)
        {
            // Load danh sách sản phẩm vào combobox
            using (var context = new TapHoaContextDB())
            {
                var danhSachSP = context.SANPHAMs
                    .Where(sp => sp.TrangThai == "Còn kinh doanh")
                    .ToList();

                cmbTenSP.DataSource = danhSachSP;
                cmbTenSP.DisplayMember = "TenSP";
                cmbTenSP.ValueMember = "MaSP";

                // Load chi tiết hóa đơn hiện tại
                List<CHITIETHOADON> listCT = context.CHITIETHOADONs
                    .Where(ct => ct.MaHD == maHoaDon)
                    .ToList();
                BindGrid(listCT);
            }

            txtSoluong.Text = "1";
            TinhTongTien();
        }

        private void BindGrid(List<CHITIETHOADON> listCT)
        {
            using (TapHoaContextDB context = new TapHoaContextDB())
            {
                dgvBanHang.Rows.Clear();
                foreach (var item in listCT)
                {
                    int index = dgvBanHang.Rows.Add();
                    dgvBanHang.Rows[index].Cells[0].Value = item.MaSP;
                    var sp = context.SANPHAMs.FirstOrDefault(s => s.MaSP == item.MaSP);
                    dgvBanHang.Rows[index].Cells[1].Value = sp?.TenSP;
                    dgvBanHang.Rows[index].Cells[2].Value = item.SoLuong;
                    dgvBanHang.Rows[index].Cells[3].Value = item.DonGia * item.SoLuong;
                }
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
                    return "CTHD001";

                if (maCuoi.Length < 4 || !int.TryParse(maCuoi.Substring(4), out int so))
                {
                    return "CTHD001";
                }
                return "CTHD" + (so + 1).ToString("D3");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaSP.Text))
            {
                MessageBox.Show("Vui lòng chọn sản phẩm cần xóa");
                return;
            }

            DialogResult result = MessageBox.Show(
                $"Bạn có chắc muốn xóa sản phẩm này?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (result == DialogResult.Yes)
            {
                using (TapHoaContextDB context = new TapHoaContextDB())
                {
                    var hdToDelete = context.CHITIETHOADONs
                        .FirstOrDefault(ct => ct.MaSP == txtMaSP.Text && ct.MaHD == maHoaDon);
                    var sptoDelete = context.SANPHAMs
                        .FirstOrDefault(sp => sp.MaSP == txtMaSP.Text);

                    if (hdToDelete != null && sptoDelete != null)
                    {
                        sptoDelete.SoLuongTon += hdToDelete.SoLuong ?? 0;
                        context.CHITIETHOADONs.Remove(hdToDelete);
                        context.SaveChanges();

                        BindGrid(context.CHITIETHOADONs.Where(ct => ct.MaHD == maHoaDon).ToList());
                        TinhTongTien();
                        txtMaSP.Clear();
                        txtSoluong.Clear();

                        MessageBox.Show("Xóa thành công!");
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy sản phẩm cần xóa.");
                    }
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // Quay về ThanhToan - truyền menu và giữ nguyên maHD
            var thanhToanForm = menu.panelDesktop.Controls.OfType<ThanhToan>().FirstOrDefault();

            if (thanhToanForm != null)
            {
                // Nếu form ThanhToan đã tồn tại, chỉ cần show lại
                thanhToanForm.maHD = maHoaDon;
                menu.openChildForm1(thanhToanForm, sender);
            }
            else
            {
                // Tạo mới và truyền maHD
                var newThanhToan = new ThanhToan(menu);
                newThanhToan.maHD = maHoaDon;
                menu.openChildForm1(newThanhToan, sender);
            }
        }

        private void TinhTongTien()
        {
            decimal tongTien = 0;
            foreach (DataGridViewRow row in dgvBanHang.Rows)
            {
                if (row.Cells[3].Value != null)
                {
                    decimal thanhTien = Convert.ToDecimal(row.Cells[3].Value);
                    tongTien += thanhTien;
                }
            }

            using (TapHoaContextDB context = new TapHoaContextDB())
            {
                var hd = context.HOADONs.FirstOrDefault(p => p.MaHD == maHoaDon);
                if (hd != null)
                {
                    hd.TongTien = tongTien;
                    context.SaveChanges();
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
            if (string.IsNullOrEmpty(cmbTenSP.Text) || string.IsNullOrEmpty(txtSoluong.Text))
            {
                MessageBox.Show("Vui lòng nhập đủ thông tin");
                return;
            }

            // Kiểm tra sản phẩm đã có trong giỏ hàng chưa
            int rowCheck = dgvBanHang.RowCount;
            for (int i = 0; i < rowCheck - 1; i++)
            {
                if (dgvBanHang.Rows[i].Cells[0].Value?.ToString() == txtMaSP.Text)
                {
                    MessageBox.Show("Sản phẩm đã có trong giỏ hàng. Vui lòng thêm sản phẩm khác.");
                    return;
                }
            }

            using (TapHoaContextDB context = new TapHoaContextDB())
            {
                SANPHAM sp = context.SANPHAMs.FirstOrDefault(s => s.MaSP == txtMaSP.Text);

                if (sp == null)
                {
                    MessageBox.Show("Không tìm thấy sản phẩm");
                    return;
                }

                int soLuongMua = int.Parse(txtSoluong.Text);

                if (sp.SoLuongTon < soLuongMua)
                {
                    MessageBox.Show($"Không đủ hàng trong kho. Số lượng tồn: {sp.SoLuongTon}");
                    return;
                }

                CHITIETHOADON newCTHD = new CHITIETHOADON()
                {
                    MaCTHD = TaoMaCTHD(),
                    MaHD = maHoaDon,
                    MaSP = txtMaSP.Text,
                    SoLuong = soLuongMua,
                    DonGia = sp.DonGia ?? 0
                };

                sp.SoLuongTon -= soLuongMua;
                context.CHITIETHOADONs.Add(newCTHD);
                context.SaveChanges();

                BindGrid(context.CHITIETHOADONs.Where(ct => ct.MaHD == maHoaDon).ToList());
                TinhTongTien();
                txtSoluong.Text = "1";
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaSP.Text))
            {
                MessageBox.Show("Vui lòng chọn sản phẩm cần cập nhật");
                return;
            }

            using (TapHoaContextDB context = new TapHoaContextDB())
            {
                var hdToUpdate = context.CHITIETHOADONs
                    .FirstOrDefault(h => h.MaSP == txtMaSP.Text && h.MaHD == maHoaDon);
                var spToUpdate = context.SANPHAMs
                    .FirstOrDefault(sp => sp.MaSP == txtMaSP.Text);

                if (hdToUpdate != null && spToUpdate != null)
                {
                    // Hoàn trả số lượng cũ
                    spToUpdate.SoLuongTon += hdToUpdate.SoLuong ?? 0;

                    // Cập nhật số lượng mới
                    int soLuongMoi = int.Parse(txtSoluong.Text);
                    hdToUpdate.SoLuong = soLuongMoi;

                    // Trừ số lượng mới
                    spToUpdate.SoLuongTon -= soLuongMoi;

                    context.SaveChanges();

                    BindGrid(context.CHITIETHOADONs.Where(ct => ct.MaHD == maHoaDon).ToList());
                    TinhTongTien();
                    MessageBox.Show("Cập nhật thành công!");
                }
                else
                {
                    MessageBox.Show("Không tìm thấy sản phẩm cần cập nhật.");
                }
            }
        }

        private void dgvBanHang_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvBanHang.CurrentRow != null && dgvBanHang.CurrentRow.Index >= 0)
            {
                DataGridViewRow row = dgvBanHang.CurrentRow;

                if (row.Cells[0].Value != null)
                {
                    txtMaSP.Text = row.Cells[0].Value.ToString();

                    // Tìm và chọn sản phẩm trong combobox
                    using (var context = new TapHoaContextDB())
                    {
                        var sp = context.SANPHAMs.FirstOrDefault(s => s.MaSP == txtMaSP.Text);
                        if (sp != null)
                        {
                            cmbTenSP.SelectedValue = sp.MaSP;
                        }
                    }

                    txtSoluong.Text = row.Cells[2].Value?.ToString() ?? "1";
                }
            }
        }
    }
}