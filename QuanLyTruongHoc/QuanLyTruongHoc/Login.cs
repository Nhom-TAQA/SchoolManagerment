using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyTruongHoc.EF;
using QuanLyTruongHoc.Function;
using System.Threading;

namespace QuanLyTruongHoc
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            txbPassword.UseSystemPasswordChar = true;
        }

        private void btLogin_Click(object sender, EventArgs e)
        {
            if (txbPassword.Text == "" || txbUsername.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin đăng nhập!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            string username = txbUsername.Text;
            List<AccountEF> listResults = new AccountFt().SelectAll().Where(x => x.Username == username).ToList();
            if (listResults == null)
            {
                MessageBox.Show("Tên đăng nhập không tồn tại!", "Thông báo", MessageBoxButtons.OK);
            }
            else
            {
                string password = txbPassword.Text;
                AccountEF result = listResults.Where(x => x.Password == password).FirstOrDefault();
                if (result == null)
                {
                    MessageBox.Show("Mật khẩu không chính xác!", "Thông báo", MessageBoxButtons.OK);
                }
                else
                {
                    Thread thr = new Thread(DisplayNewForm);
                    thr.Start();
                    this.Close();
                }
            }
        }
        void DisplayNewForm()
        {
            Main form = new Main();
            form.ShowDialog();
        }

        private void cbShowPassword_CheckedChanged_1(object sender, EventArgs e)
        {
            if (cbShowPassword.Checked)
            {
                txbPassword.UseSystemPasswordChar = false;
            }
            else
            {
                txbPassword.UseSystemPasswordChar = true;
            }
        }
    }
}
