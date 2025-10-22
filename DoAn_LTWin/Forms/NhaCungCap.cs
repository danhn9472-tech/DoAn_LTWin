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
        }

        private void button1_Click(object sender, EventArgs e)
        {
            menu.openChildForm1(new Forms.NhapSanPham(menu), sender);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            menu.openChildForm1(new Forms.SanPham(menu), sender);
        }
    }
}
