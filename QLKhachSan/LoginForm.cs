using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLKhachSan
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtUser.Text == "admin" && txtPassword.Text == "admin")
            {
                HomeForm homePage = new HomeForm();
                homePage.Visible = true;
            }
            else
            {
                MessageBox.Show("Tên truy cập hoặc mật khẩu sai");
            }
        }

        private void lilbTaiKhoan_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("Tên truy cập: admin\n" +
               "Mật khẩu: admin");
        }

        private void lilbAbout_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //Process.Start(Application.StartupPath + "\\Huong_dan\\index.html");
            Process.Start(Application.StartupPath.Replace("\\bin\\Debug", "\\HDSD\\index.html"));
        }
    }
}
