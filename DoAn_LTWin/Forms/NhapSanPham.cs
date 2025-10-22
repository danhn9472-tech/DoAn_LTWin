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
    public partial class NhapSanPham : Form
    {
        private mainMenu menu;
        public NhapSanPham(mainMenu main)
        {
            InitializeComponent();
            this.menu = main;
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
    }
}
