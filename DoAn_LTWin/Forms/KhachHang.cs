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
    public partial class KhachHang : Form
    {
        TapHoaContextDB context = new TapHoaContextDB();
        public KhachHang()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void KhachHang_Load(object sender, EventArgs e)
        {
            try
            {
                List<KHACHHANG> dsKhachHang = context.KHACHHANGs.ToList();
                BindGrid(dsKhachHang);
                // Chọn dòng đầu tiên nếu có dữ liệu
                if (dgvKH.Rows.Count > 0)
                {
                    dgvKH.Rows[0].Selected = true;
                    dgvKH.CellClick += dgvKH_CellContentClick;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối CSDL. Chi tiết: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void BindGrid(List<KHACHHANG> dgvKHang)
        {
            dgvKH.Rows.Clear();
            foreach (var kh in dgvKHang)
            {
                int index = dgvKH.Rows.Add();
                dgvKH.Rows[index].Cells[0].Value = kh.MaKH;
                dgvKH.Rows[index].Cells[1].Value = kh.TenKH;
                dgvKH.Rows[index].Cells[2].Value = kh.Email;
                dgvKH.Rows[index].Cells[3].Value = kh.DiaChi;
                dgvKH.Rows[index].Cells[4].Value = kh.SDT;
            }

        }
        private void ResetForm()
        {
            txtMaKH.Clear();
            txtTenKH.Clear();
            txtDiaChi.Clear();
            txtSDT.Clear();
            txtEmail.Clear();
            txtTimSDT.Clear();

        }

        private void dgvKH_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dgvKH.Rows.Count)
            {
                DataGridViewRow row = dgvKH.Rows[e.RowIndex];

                txtMaKH.Text = row.Cells[0].Value?.ToString();
                txtTenKH.Text = row.Cells[1].Value?.ToString();
                txtEmail.Text = row.Cells[2].Value?.ToString();
                txtDiaChi.Text = row.Cells[3].Value?.ToString();
                txtSDT.Text = row.Cells[4].Value?.ToString();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                KHACHHANG kh = new KHACHHANG()
                {
                    MaKH = txtMaKH.Text.Trim(),
                    TenKH = txtTenKH.Text.Trim(),
                    Email = txtEmail.Text.Trim(),
                    DiaChi = txtDiaChi.Text.Trim(),
                    SDT = txtSDT.Text.Trim()
                };

                context.KHACHHANGs.Add(kh);
                context.SaveChanges();
                MessageBox.Show("Thêm khách hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                BindGrid(context.KHACHHANGs.ToList());
                ResetForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm khách hàng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                string maKH = txtMaKH.Text.Trim();
                var kh = context.KHACHHANGs.FirstOrDefault(x => x.MaKH == maKH);
                if (kh != null)
                {
                    kh.TenKH = txtTenKH.Text.Trim();
                    kh.Email = txtEmail.Text.Trim();
                    kh.DiaChi = txtDiaChi.Text.Trim();
                    kh.SDT = txtSDT.Text.Trim();

                    context.SaveChanges();
                    MessageBox.Show("Cập nhật thông tin thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    BindGrid(context.KHACHHANGs.ToList());
                    ResetForm();
                }
                else
                {
                    MessageBox.Show("Không tìm thấy khách hàng để cập nhật!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            try
            {
                string sdtTimStr = txtTimSDT.Text.Trim();

                if (string.IsNullOrEmpty(sdtTimStr))
                {
                    MessageBox.Show("Vui lòng nhập số điện thoại cần tìm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }


                var ketQua = context.KHACHHANGs
                              .Where(kh => kh.SDT == sdtTimStr)
                              .ToList();

                if (ketQua.Count > 0)
                {
                    BindGrid(ketQua);
                }
                else
                {
                    MessageBox.Show("Không tìm thấy khách hàng nào với số điện thoại này!", "Kết quả", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dgvKH.Rows.Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tìm kiếm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
