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
                FillTTCombobox();
                BindGrid(listSanPham);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void loadAnh( string avatarFileName)
        {
            string imgPath = Path.Combine(Path.Combine(Application.StartupPath, "Images", avatarFileName.Trim() + ".jpg"));
            if (!string.IsNullOrEmpty(avatarFileName) && File.Exists(imgPath))
            {
                picSanPham.Image = Image.FromFile(imgPath);
            }
            else picSanPham.Image = Image.FromFile(Path.Combine(Application.StartupPath, "Images", "no_image.png")); ;
        }

        private void FillNCCCombobox(List<NHACUNGCAP> listNCC)
        {
            cmbNCC.DataSource = listNCC;
            cmbNCC.DisplayMember = "TenNCC";
            cmbNCC.ValueMember = "MaNCC";
            cmbNCC.SelectedIndex = -1;
        }
        private void FillTTCombobox()
        {
            cmbTT.Items.Add("Kinh doanh");
            cmbTT.Items.Add("Ngưng kinh doanh");
            cmbTT.SelectedIndex = -1;
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
                cmbNCC.SelectedValue = Convert.ToString(row.Cells[5].Value);
                cmbTT.Text = Convert.ToString(row.Cells[6].Value);
                loadAnh(txtMaSP.Text);  
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

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtTenSP.Text == "" || txtDonVi.Text == "" || txtGia.Text == "" || txtSoluong.Text == "" || cmbNCC.SelectedIndex == -1 || cmbTT.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin");
                return;
            }

            int rowCheck = dgvSanPham.RowCount;
            for (int i = 0; i < rowCheck - 1; i++)
            {
                if (dgvSanPham.Rows[i].Cells[0].Value.ToString() == txtMaSP.Text)
                {
                    MessageBox.Show("Mã sản phẩm đã tồn tại. Vui lòng sử dụng mã khác.");
                    return;
                }
            }
            //Lưu ảnh vào file Images
            string imagesFolder = Path.Combine(Application.StartupPath, "Images");
            if (!Directory.Exists(imagesFolder))
            {
                Directory.CreateDirectory(imagesFolder);
            }
            string fileName = $"{txtMaSP.Text}{Path.GetExtension(selectedImagePath)}";
            string destPath = Path.Combine(imagesFolder, fileName);
            File.Copy(selectedImagePath, destPath, true); // Ghi đè nếu trùng

            SANPHAM newSP = new SANPHAM
            {
                MaSP = txtMaSP.Text,
                TenSP = txtTenSP.Text,
                DonViTinh = txtDonVi.Text,
                DonGia = decimal.Parse(txtGia.Text),
                SoLuongTon = int.Parse(txtSoluong.Text),
                MaNCC = cmbNCC.SelectedValue.ToString(),
                TrangThai = cmbTT.SelectedItem.ToString(),
                Avatar = fileName
            };
            MessageBox.Show("Thêm sản phẩm thành công!");
            TapHoaContextDB context = new TapHoaContextDB();
            List<SANPHAM> listSanPham = context.SANPHAMs.ToList();
            context.SANPHAMs.Add(newSP);
            context.SaveChanges();
            BindGrid(listSanPham);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            TapHoaContextDB context = new TapHoaContextDB();
            List<SANPHAM> listSanPham = context.SANPHAMs.ToList();
            int rowCheck = dgvSanPham.RowCount;
            string imagesFolder = Path.Combine(Application.StartupPath, "Images");
            if (!Directory.Exists(imagesFolder))
            {
                Directory.CreateDirectory(imagesFolder);
            }
            string fileName = $"{txtMaSP.Text}{Path.GetExtension(selectedImagePath)}";
            string destPath = Path.Combine(imagesFolder, fileName);
            File.Copy(selectedImagePath, destPath, true);
            for (int i=0; i<rowCheck - 1; i++)
            {
                if(dgvSanPham.Rows[i].Cells[0].Value.ToString() == txtMaSP.Text)
                {
                    var spToUpdate = context.SANPHAMs.SingleOrDefault(sp => sp.MaSP == txtMaSP.Text);
                    if (spToUpdate != null)
                    {
                        spToUpdate.TenSP = txtTenSP.Text;
                        spToUpdate.DonViTinh = txtDonVi.Text;
                        spToUpdate.DonGia = decimal.Parse(txtGia.Text);
                        spToUpdate.SoLuongTon = int.Parse(txtSoluong.Text);
                        spToUpdate.MaNCC = cmbNCC.SelectedValue.ToString();
                        spToUpdate.TrangThai = cmbTT.SelectedItem.ToString();
                        spToUpdate.Avatar = fileName;
                        context.SaveChanges();
                        BindGrid(listSanPham);
                        MessageBox.Show("Cập nhật sản phẩm thành công!");
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy sản phẩm để cập nhật.");
                    }
                }
            }
        }

        private void checkbox1_CheckedChanged(object sender, EventArgs e)
        {
            TapHoaContextDB context = new TapHoaContextDB();
            List<SANPHAM> listSanPham = context.SANPHAMs.ToList();
            if (checkbox1.Checked)
            {
                listSanPham = listSanPham.Where(sp => sp.TrangThai.Trim().ToLower() == "ngung kinh doanh").ToList();
            }
            else
            {
                listSanPham = context.SANPHAMs.ToList();
            }
            BindGrid(listSanPham);
        }
    }
}
