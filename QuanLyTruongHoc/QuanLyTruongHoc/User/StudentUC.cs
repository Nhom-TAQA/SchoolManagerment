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
using System.Threading;

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
            foreach(StudentEF item in listStudent)
            {
                string sex = item.Sex == true ? "Nam" : "Nữ";
                dgView.Rows.Add(index.ToString(), item.StudentCode, item.FullName, sex, String.Format("{0:dd/MM/yyyy}",item.DateOfBirth));
                index++;
            }
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
            ArrByte_Anh = Student.Avatar;
            picAvt.Image = User.ImageHandle.ByteToImage(ArrByte_Anh);
            txbAddress.Text = Student.Address;
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
            Student.Avatar = ArrByte_Anh;
            bool result = new StudentFt().Insert(Student);
            if (result == true)
            {
                List<StudentEF> listStudent = new StudentFt().SelectAll();
                Load(listStudent);
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
            Student.Avatar = ArrByte_Anh;
            bool result = new StudentFt().Update(Student);
            if (result == true)
            {
                List<StudentEF> listStudent = new StudentFt().SelectAll();
                Load(listStudent);
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
            Student.Avatar = ArrByte_Anh;
            bool result = new StudentFt().Delete(Student);
            if (result == true)
            {
                List<StudentEF> listStudent = new StudentFt().SelectAll();
                Load(listStudent);
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
        byte[] ArrByte_Anh;
        private void picAvt_DoubleClick(object sender, EventArgs e)
        {
            string filename = "";
            Thread thr = new Thread((ThreadStart)(() =>
            {
                OpenFileDialog open = new OpenFileDialog();
                open.Multiselect = false;
                if (open.ShowDialog() == DialogResult.OK)
                {
                    filename = open.FileName.ToString();
                }
            }));
            thr.SetApartmentState(ApartmentState.STA);
            thr.Start();
            thr.Join();

            if (filename == "")
            {
                return;
            }

            byte[] arrByte = ImageHandle.StringToByte(filename);
            ArrByte_Anh = arrByte;

            picAvt.Image = ImageHandle.ByteToImage(arrByte);
        }

        private void btClear_Click(object sender, EventArgs e)
        {
            picAvt.Image = null;
            txbCode.Text = "";
            txbName.Text = "";
            txbAddress.Text = "";
            cbSex.SelectedIndex = 0;
            ArrByte_Anh = null;
        }
    }
}
