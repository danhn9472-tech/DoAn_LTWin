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
            LoadCustomFont();
        }
        Dictionary<string, FontFamily> fontMap = new Dictionary<string, FontFamily>();
        private void LoadCustomFont()
        {
            // Đường dẫn đến file font (ví dụ trong thư mục project)
            string[] fontPath =
            {
                Application.StartupPath + @"\font\MTO Astro City.ttf"
            };
            PrivateFontCollection privateFonts = new PrivateFontCollection();   
            // Duyệt qua từng font và thêm vào bộ sưu tập
            foreach (var file in fontPath)
            {
                privateFonts.AddFontFile(file);
                var family = privateFonts.Families[privateFonts.Families.Length - 1]; // lấy font vừa thêm cuối cùng
                fontMap[family.Name] = family;
            }
            var actualKey = fontMap.Keys.First();
            label1.Font = new Font(fontMap[actualKey], 25);
        }
        private void Login_Load(object sender, EventArgs e)
        {

        }
    }
}
