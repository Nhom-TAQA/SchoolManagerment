using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyTruongHoc.User;
using System.Threading;

namespace QuanLyTruongHoc
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
            pnMain.Controls.Clear();
            pnMain.Controls.Add(new Home());
        }

        private void btTeacher_Click(object sender, EventArgs e)
        {
            pnMain.Controls.Clear();
            pnMain.Controls.Add(new TeacherUC(pnMain.Width, pnMain.Height));
        }

        private void btStudent_Click(object sender, EventArgs e)
        {
          
        }

        private void btClass_Click(object sender, EventArgs e)
        {
            pnMain.Controls.Clear();
            pnMain.Controls.Add(new ClassUC());
        }

        private void btHomeroomTeacher_Click(object sender, EventArgs e)
        {
            pnMain.Controls.Clear();
            pnMain.Controls.Add(new HomeroomTeacherUC());
        }

        private void btStudentInClass_Click(object sender, EventArgs e)
        {
            pnMain.Controls.Clear();
            pnMain.Controls.Add(new StudentInClassUC());
        }

        private void btLogout_Click(object sender, EventArgs e)
        {
            Thread thr = new Thread(ShowLogin);
            thr.Start();
            this.Close();
        }
        void ShowLogin()
        {
            Login login = new Login();
            login.ShowDialog();
        }

        private void btHome_Click(object sender, EventArgs e)
        {
            pnMain.Controls.Clear();
            pnMain.Controls.Add(new Home());
        }
    }
}
