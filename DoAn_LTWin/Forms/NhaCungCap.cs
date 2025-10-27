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

        }
    }
}
