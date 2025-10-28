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
    public partial class NhaCungCap : Form
    {
        private mainMenu menu;
        public NhaCungCap(mainMenu main)
        {
            InitializeComponent();
            this.menu = main;
            TapHoaContextDB context = new TapHoaContextDB();
            List<NHACUNGCAP> listNCC = context.NHACUNGCAPs.ToList();
            BindGrid(listNCC);
        }
        private void BindGrid(List<NHACUNGCAP> listNCC)
        {
            dgvNCC.Rows.Clear();
            foreach (var item in listNCC)
            {
                int index = dgvNCC.Rows.Add();
                dgvNCC.Rows[index].Cells[0].Value = item.MaNCC;
                dgvNCC.Rows[index].Cells[1].Value = item.TenNCC;
                dgvNCC.Rows[index].Cells[2].Value = item.DiaChi;
                dgvNCC.Rows[index].Cells[3].Value = item.SDT;
                dgvNCC.Rows[index].Cells[4].Value = item.Email;
            }
        }

        private void btnNhapSP_Click(object sender, EventArgs e)
        {
            menu.openChildForm1(new Forms.NhapSanPham(menu), sender);
        }

        private void btnQLSP_Click(object sender, EventArgs e)
        {
            menu.openChildForm1(new Forms.SanPham(menu), sender);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if(txtMaNCC.Text == "" || txtNameNCC.Text == "" || txtDiaChi.Text == "" || txtSDT.Text == "" || txtEmail.Text == "")
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin nhà cung cấp.");
                return;
            }
            int rowCheck = dgvNCC.RowCount;
            for (int i = 0; i < rowCheck - 1; i++)
            {
                if (dgvNCC.Rows[i].Cells[0].Value.ToString() == txtMaNCC.Text)
                {
                    MessageBox.Show("Nhà cung cấp đã tồn tại. Vui lòng thay đổi thông tin.");
                    return;
                }
            }
            NHACUNGCAP newNCC = new NHACUNGCAP
            {
                MaNCC = txtMaNCC.Text,
                TenNCC = txtNameNCC.Text,
                DiaChi = txtDiaChi.Text,
                SDT = txtSDT.Text,
                Email = txtEmail.Text
            };
            MessageBox.Show("Thêm nhà cung cấp thành công!");
            TapHoaContextDB context = new TapHoaContextDB();
            List<NHACUNGCAP> listNCC = context.NHACUNGCAPs.ToList();
            context.NHACUNGCAPs.Add(newNCC);
            context.SaveChanges();
            BindGrid(listNCC);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            TapHoaContextDB context = new TapHoaContextDB();
            List<NHACUNGCAP> listNCC = context.NHACUNGCAPs.ToList();
            int rowCheck = dgvNCC.RowCount;
            for (int i = 0; i < rowCheck - 1; i++)
            {
                if (dgvNCC.Rows[i].Cells[0].Value.ToString() == txtMaNCC.Text)
                {
                    var nccToUpdate = context.NHACUNGCAPs.SingleOrDefault(sp => sp.MaNCC == txtMaNCC.Text);
                    if (nccToUpdate != null)
                    {
                        nccToUpdate.TenNCC = txtNameNCC.Text;
                        nccToUpdate.DiaChi = txtDiaChi.Text;
                        nccToUpdate.SDT = txtSDT.Text;
                        nccToUpdate.Email = txtEmail.Text;
                        context.SaveChanges();
                        BindGrid(listNCC);
                        MessageBox.Show("Cập nhật sản phẩm thành công!");
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy sản phẩm để cập nhật.");
                    }
                }
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {

        }

        private void dgvNCC_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvNCC.CurrentRow != null && dgvNCC.CurrentRow.Index >= 0)
            {
                DataGridViewRow row = dgvNCC.CurrentRow;

                txtMaNCC.Text = Convert.ToString(row.Cells[0].Value);
                txtNameNCC.Text = Convert.ToString(row.Cells[1].Value);
                txtDiaChi.Text = Convert.ToString(row.Cells[2].Value);
                txtSDT.Text = Convert.ToString(row.Cells[3].Value);
                txtEmail.Text = Convert.ToString(row.Cells[4].Value);
            }
        }
    }
}
