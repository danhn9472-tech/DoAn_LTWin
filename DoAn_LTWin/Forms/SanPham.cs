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
using System.IO;

namespace DoAn_LTWin.Forms
{
    public partial class SanPham : Form
    {
        private string selectedImagePath = null;
        private mainMenu menu;
        public SanPham(mainMenu main)
        {
            InitializeComponent();
            this.menu = main;
            try
            {
                TapHoaContextDB context = new TapHoaContextDB();
                List<SANPHAM> listSanPham = context.SANPHAMs.ToList();
                List<NHACUNGCAP> listNCC = context.NHACUNGCAPs.ToList();
                FillNCCCombobox(listNCC);
                BindGrid(listSanPham);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void loadAnh(PictureBox picBox, string avatarFileName)
        {
            if (picSanPham.Image != null)
            {
                picBox.Image.Dispose();
                picBox.Image = null;
            }

            if (string.IsNullOrEmpty(avatarFileName))
            {
                return;
            }

            try
            {
                string fullPath = Path.Combine(Application.StartupPath, "Images", avatarFileName);

                if (File.Exists(fullPath))
                {
                    using (MemoryStream ms = new MemoryStream(File.ReadAllBytes(fullPath)))
                    {
                        picBox.Image = Image.FromStream(ms);
                    }
                }
                else
                {
                    System.Diagnostics.Debug.WriteLine("Không tìm thấy tệp ảnh: " + fullPath);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Lỗi khi tải ảnh: " + ex.Message);
            }
        }

        private void FillNCCCombobox(List<NHACUNGCAP> listNCC)
        {
            cmbNCC.DataSource = listNCC;
            cmbNCC.DisplayMember = "TenNCC";
            cmbNCC.ValueMember = "MaNCC";
            cmbNCC.SelectedIndex = -1;
        }
        private void BindGrid(List<SANPHAM> listSanPham)
        {
            dgvSanPham.Rows.Clear();
            foreach (var item in listSanPham)
            {
                int index = dgvSanPham.Rows.Add();
                dgvSanPham.Rows[index].Cells[0].Value = item.MaSP;
                dgvSanPham.Rows[index].Cells[1].Value = item.TenSP;
                dgvSanPham.Rows[index].Cells[2].Value = item.DonViTinh;
                dgvSanPham.Rows[index].Cells[3].Value = item.DonGia;
                dgvSanPham.Rows[index].Cells[4].Value = item.SoLuongTon;
                dgvSanPham.Rows[index].Cells[5].Value = item.MaNCC;
                dgvSanPham.Rows[index].Cells[6].Value = item.TrangThai;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            menu.openChildForm1(new Forms.NhapSanPham(menu), sender);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            menu.openChildForm1(new Forms.NhaCungCap(menu), sender);
        }

        private void dgvSanPham_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvSanPham.CurrentRow != null && dgvSanPham.CurrentRow.Index >= 0)
            {
                DataGridViewRow row = dgvSanPham.CurrentRow;

                txtMaSP.Text = Convert.ToString(row.Cells[0].Value);
                txtTenSP.Text = Convert.ToString(row.Cells[1].Value);
                txtDonVi.Text = Convert.ToString(row.Cells[2].Value);
                txtGia.Text = Convert.ToString(row.Cells[3].Value);
                txtSoluong.Text = Convert.ToString(row.Cells[4].Value);
                cmbNCC.Text = Convert.ToString(row.Cells[5].Value);
                cmbTT.Text = Convert.ToString(row.Cells[6].Value);
                loadAnh(picSanPham, txtMaSP.Text);
            }
        }

        private void btnChonAanh_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
            ofd.Title = "Chọn một ảnh sản phẩm";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    selectedImagePath = ofd.FileName;
                    picSanPham.Image = Image.FromFile(selectedImagePath);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Không thể mở tệp ảnh: " + ex.Message);
                    selectedImagePath = null; 
                }
            }
        }
    }
}
