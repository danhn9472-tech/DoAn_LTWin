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
    public partial class NhanVien : Form
    {
        private TapHoaContextDB context = new TapHoaContextDB();
        public NhanVien()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void NhanVien_Load(object sender, EventArgs e)
        {
            try
            {
                cmdChucVu.Items.Clear();
                cmdChucVu.Items.Add("Quản lý");
                cmdChucVu.Items.Add("Nhân viên kho");
                cmdChucVu.Items.Add("Nhân viên bán hàng");
                cmdChucVu.Items.Add("Bảo vệ");
                cmdChucVu.Items.Add("— Chọn chức vụ —");
                cmdChucVu.SelectedIndex = cmdChucVu.Items.Count - 1;
                rbtnNam.Checked = true;
                List<NHANVIEN> dsNhanVien = context.NHANVIENs.ToList();

                BindGrid(dsNhanVien);
                // Chọn dòng đầu tiên nếu có dữ liệu
                if (dgvNhanVien.Rows.Count > 0)
                {
                    dgvNhanVien.Rows[0].Selected = true;
                    dgvNhanVien.CellClick += dgvNhanVien_CellContentClick;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối CSDL. Chi tiết: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void BindGrid(List<NHANVIEN> dsNhanVien)
        {
            dgvNhanVien.Rows.Clear();
            foreach (var nv in dsNhanVien)
            {
                int index = dgvNhanVien.Rows.Add();
                dgvNhanVien.Rows[index].Cells[0].Value = nv.MaNV;
                dgvNhanVien.Rows[index].Cells[1].Value = nv.TenNV;
                dgvNhanVien.Rows[index].Cells[2].Value = nv.GioiTinh;
                dgvNhanVien.Rows[index].Cells[3].Value = nv.NgaySinh?.ToString("dd/MM/yyyy");
                dgvNhanVien.Rows[index].Cells[4].Value = nv.DiaChi;
                dgvNhanVien.Rows[index].Cells[5].Value = nv.SDT;
                dgvNhanVien.Rows[index].Cells[6].Value = nv.ChucVu;
                dgvNhanVien.Rows[index].Cells[7].Value = nv.TaiKhoan;
                dgvNhanVien.Rows[index].Cells[8].Value = nv.MatKhau;
            }
        }
        private void ResetForm()
        {
            txtMaNV.Clear();
            txtNameNV.Clear();
            rbtnNam.Checked = true;
            dpickNgaySinh.Value = DateTime.Now;
            txtDiaChi.Clear();
            txtSDT.Clear();
            cmdChucVu.SelectedItem = "— Chọn chức vụ —";
            txtTaiKhoan.Clear();
            txtPassword.Clear();

        }
        private void dgvNhanVien_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Kiểm tra chỉ số dòng hợp lệ
            if (e.RowIndex >= 0 && e.RowIndex < dgvNhanVien.Rows.Count)
            {
                DataGridViewRow row = dgvNhanVien.Rows[e.RowIndex];

                txtMaNV.Text = row.Cells[0].Value?.ToString();
                txtNameNV.Text = row.Cells[1].Value?.ToString();

                string gioiTinh = row.Cells[2].Value?.ToString();
                if (gioiTinh == "Nam")
                    rbtnNam.Checked = true;
                else
                    dbtnNu.Checked = true;

                if (DateTime.TryParse(row.Cells[3].Value?.ToString(), out DateTime ngaySinh))
                    dpickNgaySinh.Value = ngaySinh;
                else
                    dpickNgaySinh.Value = DateTime.Now;

                txtDiaChi.Text = row.Cells[4].Value?.ToString();
                txtSDT.Text = row.Cells[5].Value?.ToString();
                cmdChucVu.SelectedItem = row.Cells[6].Value?.ToString();
                txtTaiKhoan.Text = row.Cells[7].Value?.ToString();
                txtPassword.Text = row.Cells[8].Value?.ToString();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                NHANVIEN nv = new NHANVIEN()
                {
                    MaNV = txtMaNV.Text.Trim(),
                    TenNV = txtNameNV.Text.Trim(),
                    GioiTinh = rbtnNam.Checked ? "Nam" : "Nữ",
                    NgaySinh = dpickNgaySinh.Value,
                    DiaChi = txtDiaChi.Text.Trim(),
                    SDT = txtSDT.Text.Trim(),
                    ChucVu = cmdChucVu.SelectedItem?.ToString(),
                    TaiKhoan = txtTaiKhoan.Text.Trim(),
                    MatKhau = txtPassword.Text.Trim()
                };

                context.NHANVIENs.Add(nv);
                context.SaveChanges();
                MessageBox.Show("Thêm nhân viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                BindGrid(context.NHANVIENs.ToList());
                ResetForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm nhân viên: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                string maNV = txtMaNV.Text.Trim();
                var nv = context.NHANVIENs.FirstOrDefault(x => x.MaNV == maNV);
                if (nv != null)
                {
                    nv.TenNV = txtNameNV.Text.Trim();
                    nv.GioiTinh = rbtnNam.Checked ? "Nam" : "Nữ";
                    nv.NgaySinh = dpickNgaySinh.Value;
                    nv.DiaChi = txtDiaChi.Text.Trim();
                    nv.SDT = txtSDT.Text.Trim();
                    nv.ChucVu = cmdChucVu.SelectedItem?.ToString();
                    nv.TaiKhoan = txtTaiKhoan.Text.Trim();
                    nv.MatKhau = txtPassword.Text.Trim();

                    context.SaveChanges();
                    MessageBox.Show("Cập nhật thông tin thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    BindGrid(context.NHANVIENs.ToList());
                    ResetForm();
                }
                else
                {
                    MessageBox.Show("Không tìm thấy nhân viên để cập nhật!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            try
            {
                string maNV = txtMaNV.Text.Trim();
                var nv = context.NHANVIENs.FirstOrDefault(x => x.MaNV == maNV);
                if (nv != null)
                {
                    var confirm = MessageBox.Show("Bạn có chắc muốn xóa nhân viên này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (confirm == DialogResult.Yes)
                    {
                        context.NHANVIENs.Remove(nv);
                        context.SaveChanges();
                        MessageBox.Show("Xóa nhân viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        BindGrid(context.NHANVIENs.ToList());
                        ResetForm();
                    }
                }
                else
                {
                    MessageBox.Show("Không tìm thấy nhân viên để xóa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
