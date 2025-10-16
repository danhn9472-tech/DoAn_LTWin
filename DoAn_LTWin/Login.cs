using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Text;

namespace DoAn_LTWin
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();

        }
        
        private void Login_Load(object sender, EventArgs e)
        {
            SetPlaceholder(txtUser, "Nhập tên đăng nhập:",false);
            SetPlaceholder(txtPass, "Nhập mật khẩu:",true);
        }
        private void SetPlaceholder(TextBox tb, string placeholder,bool isPassword)
        {
            tb.Text = placeholder;
            tb.ForeColor = Color.Gray;
            tb.Font = new Font(tb.Font.FontFamily, 20);
            tb.Enter += (s, e) =>
            {
                if (tb.Text == placeholder)
                {
                    tb.Text = "";
                    tb.ForeColor = Color.Black;
                    if(isPassword)
                    {
                        tb.PasswordChar='*';
                    }
                }
            };

            tb.Leave += (s, e) =>
            {
                if (string.IsNullOrWhiteSpace(tb.Text))
                {
                    tb.Text = placeholder;
                    tb.ForeColor = Color.Gray;
                    if(isPassword)
                    {
                        tb.PasswordChar = '\0';
                    }
                }
            };
        }
    }
}
