using DoAn_LTWin.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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

        private bool AuthenticateUser(string username, string password)
        {
            using (var context = new TapHoaContextDB())
            {
                var user = context.NHANVIENs.FirstOrDefault(u => u.TaiKhoan == username);

                if (user != null)
                {
                    if (user.MatKhau == password)
                    {
                        UserSession.UserName = user.TenNV;
                        UserSession.Role = user.ChucVu;
                        UserSession.UserId = user.MaNV;
                        return true;
                    }
                }
                return false;
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUser.Text?.Trim();
            string password = txtPass.Text ?? "";

            // Treat placeholder as empty
            if (username == "Nhập tên đăng nhập:" || string.IsNullOrWhiteSpace(username) ||
                password == "Nhập mật khẩu:" || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin đăng nhập.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                if (AuthenticateUser(username, password))
                {
                    var mainMenu = new mainMenu();
                    mainMenu.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Tên đăng nhập hoặc mật khẩu không đúng.", "Lỗi đăng nhập", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi kết nối cơ sở dữ liệu.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
    }
}
