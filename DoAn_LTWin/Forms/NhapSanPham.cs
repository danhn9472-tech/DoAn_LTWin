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
    public partial class NhapSanPham : Form
    {
        private mainMenu menu;
        public NhapSanPham(mainMenu main)
        {
            InitializeComponent();
            this.menu = main;
            TapHoaContextDB context = new TapHoaContextDB();
            List<PHIEUNHAP> listPN = context.PHIEUNHAPs.ToList();
            List<NHACUNGCAP> listNCC = context.NHACUNGCAPs.ToList();
            FillNCCCombobox(listNCC);
            BindGrid(listPN);
        }
        private void FillNCCCombobox(List<NHACUNGCAP> listNCC)
        {
            cmbNCC.DataSource = listNCC;
            cmbNCC.DisplayMember = "TenNCC";
            cmbNCC.ValueMember = "MaNCC";
            cmbNCC.SelectedIndex = -1;
        }
        private void BindGrid(List<PHIEUNHAP> listPN)
        {
            dgvPN.Rows.Clear();
            foreach (var item in listPN)
            {
                int index = dgvPN.Rows.Add();
                dgvPN.Rows[index].Cells[0].Value = item.MaPN;
                dgvPN.Rows[index].Cells[1].Value = item.MaNCC;
                dgvPN.Rows[index].Cells[2].Value = item.MaNV;
                dgvPN.Rows[index].Cells[3].Value = item.NgayNhap;
                dgvPN.Rows[index].Cells[4].Value = item.TongTien;
            }
        }

        private void btnQLSanPham_Click(object sender, EventArgs e)
        {
            menu.openChildForm1(new Forms.SanPham(menu), sender);
        }

        private void btnNCC_Click(object sender, EventArgs e)
        {
            menu.openChildForm1(new Forms.NhaCungCap(menu), sender);
        }

        private void btnChiTiet_Click(object sender, EventArgs e)
        {
            menu.openChildForm1(new Forms.CT_PhieuNhap(menu), sender);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtMaPN.Text == "" || cmbNCC.SelectedIndex == -1 || txtMaNV.Text == "" )
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin");
                return;
            }
            PHIEUNHAP newPN = new PHIEUNHAP
            {
                MaPN = txtMaPN.Text,
                MaNCC = cmbNCC.SelectedValue.ToString(),
                MaNV = txtMaNV.Text,
                NgayNhap = dtpPN.Value,
                TongTien = 0
            }; 
        }

        private void NhapSanPham_Load(object sender, EventArgs e)
        {
            txtTongTien.Text = "0";
            dtpPN.Format = DateTimePickerFormat.Custom; 
            dtpPN.CustomFormat = "dd/MM/yyyy HH:mm:ss"; 
            dtpPN.ShowUpDown = true;
            dtpTimKiem.Format = DateTimePickerFormat.Custom; 
            dtpTimKiem.CustomFormat = "dd/MM/yyyy HH:mm:ss"; 
            dtpTimKiem.ShowUpDown = true;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            BindGrid(new TapHoaContextDB().PHIEUNHAPs.ToList());

        }

        private void dtpTimKiem_ValueChanged(object sender, EventArgs e)
        {
            using (TapHoaContextDB context = new TapHoaContextDB())
            {
                DateTime selectedDate = dtpPN.Value.Date; 
                List<PHIEUNHAP> listPN = context.PHIEUNHAPs
                    .Where(p => p.NgayNhap.HasValue && p.NgayNhap.Value.Date == selectedDate)
                    .ToList();
                BindGrid(listPN);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            TapHoaContextDB context = new TapHoaContextDB();
            List<PHIEUNHAP> listPN = context.PHIEUNHAPs.ToList();
            int rowCheck = dgvPN.RowCount;
            for (int i = 0; i < rowCheck - 1; i++)
            {
                if (dgvPN.Rows[i].Cells[0].Value.ToString() == txtMaPN.Text)
                {
                    var spToUpdate = context.PHIEUNHAPs.SingleOrDefault(pn => pn.MaPN == txtMaPN.Text);
                    if (spToUpdate != null)
                    {
                        spToUpdate.MaNCC = cmbNCC.SelectedValue.ToString();
                        spToUpdate.MaNV = txtMaNV.Text;
                        spToUpdate.NgayNhap = dtpPN.Value;
                        context.SaveChanges();
                        BindGrid(listPN);
                        MessageBox.Show("Cập nhật phiếu nhập thành công!");
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy phiếu cần cập nhật.");
                    }
                }
            }
        }

        private void dgvPN_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvPN.CurrentRow != null && dgvPN.CurrentRow.Index >= 0)
            {
                DataGridViewRow row = dgvPN.CurrentRow;
                txtMaPN.Text = Convert.ToString(row.Cells[0].Value);
                cmbNCC.SelectedValue = Convert.ToString(row.Cells[1].Value);
                txtMaNV.Text = Convert.ToString(row.Cells[2].Value);
                dtpPN.Value = Convert.ToDateTime(row.Cells[3].Value);
                txtTongTien.Text = Convert.ToString(row.Cells[4].Value);
            }
        }
    }
}
