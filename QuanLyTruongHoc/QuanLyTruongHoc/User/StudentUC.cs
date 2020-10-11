using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyTruongHoc.EF;
using QuanLyTruongHoc.Function;

namespace QuanLyTruongHoc.User
{
    public partial class StudentUC : UserControl
    {
        public StudentUC()
        {
            InitializeComponent();
            List<StudentEF> listStudent = new StudentFt().SelectAll();
            Load(listStudent);
        }
        void Load(List<StudentEF> listStudent)
        {
            dgView.Rows.Clear();
            int index = 1;
            foreach (StudentEF item in listStudent)
            {
                dgView.Rows.Add(index.ToString(), null, item.StudentCode, item.Sex, item.DateOfBirth.ToShortDateString());
                index++;
            }
        }
        private void btAdd_Click(object sender, EventArgs e)
        {
            if (txbCode.Text == "" || txbName.Text == "")
            {
                return;
            }
            string StudentCode = txbCode.Text;
            StudentEF _Student = new StudentFt().SelectAll().Where(x => x.StudentCode.ToString() == StudentCode).FirstOrDefault();
            if (_Student != null)
            {
                MessageBox.Show("Mã học sinh đã tồn tại", "Thông báo", MessageBoxButtons.OK);
                return;
            }
            StudentEF Student = new StudentEF();
            Student.StudentCode = Int32.Parse(StudentCode);
            Student.FullName = txbName.Text;
            Student.Sex = cbSex.SelectedIndex == 0 ? true : false;
            Student.DateOfBirth = dtDateOfBirth.Value;
            Student.Address = txbAddress.Text;
            bool result = new StudentFt().Insert(Student);
            if (result == true)
            {
                MessageBox.Show("Thêm thành công học sinh", "Thông báo");
            }
            else
            {
                MessageBox.Show("Thêm không thành công học sinh", "Thông báo");
            }
        }

        private void btEdit_Click(object sender, EventArgs e)
        {
            if (txbCode.Text == "" || txbName.Text == "")
            {
                return;
            }
            string StudentCode = txbCode.Text;
            StudentEF Student = new StudentEF();
            Student.StudentCode = Int32.Parse(StudentCode);
            Student.FullName = txbName.Text;
            Student.Sex = cbSex.SelectedIndex == 0 ? true : false;
            Student.DateOfBirth = dtDateOfBirth.Value;
            Student.Address = txbAddress.Text;
            bool result = new StudentFt().Update(Student);
            if (result == true)
            {
                MessageBox.Show("Sửa thành công học sinh", "Thông báo");
            }
            else
            {
                MessageBox.Show("Sửa không thành công học sinh", "Thông báo");
            }
        }

        private void btDelete_Click(object sender, EventArgs e)
        {
            if (txbCode.Text == "" || txbName.Text == "")
            {
                return;
            }
            string StudentCode = txbCode.Text;
            StudentEF Student = new StudentEF();
            Student.StudentCode = Int32.Parse(StudentCode);
            Student.FullName = txbName.Text;
            Student.Sex = cbSex.SelectedIndex == 0 ? true : false;
            Student.DateOfBirth = dtDateOfBirth.Value;
            Student.Address = txbAddress.Text;
            bool result = new StudentFt().Delete(Student);
            if (result == true)
            {
                MessageBox.Show("Xóa thành công học sinh", "Thông báo");
            }
            else
            {
                MessageBox.Show("Xóa không thành công học sinh", "Thông báo");
            }
        }

        private void btSearch_Click(object sender, EventArgs e)
        {
            if (Text.Text == "")
            {
                return;
            }
            string text = Text.Text;
            List<StudentEF> listStudent = new StudentFt().SelectAll().Where(x => x.FullName == text || x.StudentCode.ToString() == text || x.Address == text).ToList();
            Load(listStudent);
        }

        private void dgView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                return;
            }
            string StudentCode = dgView.Rows[e.RowIndex].Cells["StudentCode"].Value.ToString();
            StudentEF Student = new StudentFt().SelectAll().Where(x => x.StudentCode.ToString() == StudentCode).ToList().FirstOrDefault();
            txbCode.Text = StudentCode;
            txbName.Text = Student.FullName;
            dtDateOfBirth.Value = Student.DateOfBirth;
            cbSex.SelectedIndex = Student.Sex == true ? 0 : 1;
        }
    }
}
