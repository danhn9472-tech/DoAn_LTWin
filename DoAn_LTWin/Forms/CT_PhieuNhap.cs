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
    public partial class CT_PhieuNhap : Form
    {
        private mainMenu menu;
        public CT_PhieuNhap(mainMenu main)
        {
            InitializeComponent();
            this.menu = main;
        }

        private void btnChiTiet_Click(object sender, EventArgs e)
        {
            menu.openChildForm1(new Forms.NhapSanPham(menu), sender);
        }
    }
}
