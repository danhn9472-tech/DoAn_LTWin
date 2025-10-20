using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAn_LTWin
{
    public partial class mainMenu : Form
    {
        private Button currentButton;
        private int tempIndex;
        private Form activeForm;
        public mainMenu()
        {
            InitializeComponent();
            btnTrangChu.BackColor = Color.FromArgb(55, 53, 62);
            btnTrangChu.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

        }
        private void ActiveButton(object btnSender)
        {
            if (btnSender != null)
            {
               if(btnSender != null)
                {
                    DisableButton();
                    currentButton = (Button)btnSender;
                    currentButton.BackColor = Color.FromArgb(55, 53, 62);
                    currentButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                }
            }
        }
        private void DisableButton()
        {
            foreach (Control previousBtn in panelMenu.Controls)
            {
                if (previousBtn.GetType() == typeof(Button))
                {
                    previousBtn.BackColor = Color.FromArgb(68, 68, 78);
                    previousBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                }
            }
        }
        private void openChildForm(Form childForm, object btnSender)
        {
            if (activeForm != null)
            {
                activeForm.Close();
            }    
            ActiveButton(btnSender);
            activeForm = childForm;
            childForm.TopLevel = false; 
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            this.panelDesktop.Controls.Add(childForm);
            this.panelDesktop.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
            
        }
        private void btnTrangChu_Click(object sender, EventArgs e)
        {
            ActiveButton(sender);
            if (activeForm != null)
            {
                activeForm.Close();
            }
        }
        private void btnBanHang_Click(object sender, EventArgs e)
        {
            openChildForm(new Forms.BanHang(), sender);
        }

        private void btnSanPham_Click(object sender, EventArgs e)
        {
            openChildForm(new Forms.SanPham(), sender);
        }

        private void btnNhapHang_Click(object sender, EventArgs e)
        {
            openChildForm(new Forms.NhapHang(), sender);
        }

        private void btnNhanVien_Click(object sender, EventArgs e)
        {
            openChildForm(new Forms.NhanVien(), sender);
        }

        private void btnKhachHang_Click(object sender, EventArgs e)
        {
            openChildForm(new Forms.KhachHang(), sender);
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            this.Hide();
            login.Show();
        }

    }
}
