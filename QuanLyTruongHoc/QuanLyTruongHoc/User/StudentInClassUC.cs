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
    public partial class StudentInClassUC : UserControl
    {
        public StudentInClassUC()
        {
            InitializeComponent();
            List<StudentInClassEF> listStudentInClass = new StudentInClassFt().SelectAll();
            Load(listStudentInClass);
        }
        void Load(List<StudentInClassEF> listStudentInClass)
        {
            dgView.Rows.Clear();
            int index = 1;
            foreach (StudentInClassEF item in listStudentInClass)
            {
                StudentEF Student = new StudentFt().SelectAll().Where(x => x.StudentCode == item.StudentCode).ToList().FirstOrDefault();
                dgView.Rows.Add(index.ToString(), item.ClassCode, Student.StudentCode, Student.FullName, item.SchoolYear);
                index++;
            }
        }

        private void dgView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                return;
            }
            string ClassCode = dgView.Rows[e.RowIndex].Cells["ClassCode"].Value.ToString();
            string StudentCode = dgView.Rows[e.RowIndex].Cells["StudentCode"].Value.ToString();
            StudentInClassEF ef = new StudentInClassFt().SelectAll().Where(x => x.StudentCode.ToString() == StudentCode && x.ClassCode == ClassCode).FirstOrDefault();
            StudentEF student = new StudentFt().SelectAll().Where(x => x.StudentCode.ToString() == StudentCode).FirstOrDefault();
            ClassEF _class = new ClassFt().SelectAll().Where(x => x.ClassCode == ClassCode).FirstOrDefault();
            txbClass.Text = _class.ClassCode;
            txbStudentCode.Text = student.StudentCode.ToString();
            txbSchoolYear.Text = ef.SchoolYear;
            txbType.Text = _class.Type == true ? "Lớp chọn" : "Lớp đại trà";
            txbStudentName.Text = student.FullName;
        }

        private void btAdd_Click(object sender, EventArgs e)
        {
            if (txbClass.Text == "" || txbStudentCode.Text == "")
            {
                return;
            }
            StudentInClassEF _ef = new StudentInClassEF();
            _ef = new StudentInClassFt().SelectAll().Where(x => x.ClassCode == txbClass.Text && x.StudentCode.ToString() == txbStudentCode.Text).FirstOrDefault();
            if (_ef != null)
            {
                MessageBox.Show("Đối tượng đã tồn tại");
                return;
            }
            ClassEF _class = new ClassFt().SelectAll().Where(x => x.ClassCode == txbClass.Text).FirstOrDefault();
            if (_class == null)
            {
                MessageBox.Show("Lớp không tồn tại");
                return;
            }
            StudentEF _student = new StudentFt().SelectAll().Where(x => x.StudentCode.ToString() == txbStudentCode.Text).FirstOrDefault();
            if (_student == null)
            {
                MessageBox.Show("Học sinh không tồn tại");
                return;
            }
            StudentInClassEF ef = new StudentInClassEF();
            ef.ClassCode = txbClass.Text;
            ef.StudentCode = Int32.Parse(txbStudentCode.Text);
            ef.SchoolYear = txbSchoolYear.Text;
            bool result = new StudentInClassFt().Insert(ef);
            if (result == true)
            {
                List<StudentInClassEF> listStudentInClass = new StudentInClassFt().SelectAll();
                Load(listStudentInClass);
                MessageBox.Show("Thêm thành công.");
            }
            else
            {
                MessageBox.Show("Thêm không thành công");
            }
        }

        private void btEdit_Click(object sender, EventArgs e)
        {
            if (txbClass.Text == "" || txbStudentCode.Text == "")
            {
                return;
            }
            StudentInClassEF _ef = new StudentInClassEF();
            _ef = new StudentInClassFt().SelectAll().Where(x => x.ClassCode == txbClass.Text && x.StudentCode.ToString() == txbStudentCode.Text).FirstOrDefault();
            if (_ef == null)
            {
                MessageBox.Show("Đối tượng không tồn tại");
                return;
            }
            ClassEF _class = new ClassFt().SelectAll().Where(x => x.ClassCode == txbClass.Text).FirstOrDefault();
            if (_class == null)
            {
                MessageBox.Show("Lớp không tồn tại");
                return;
            }
            StudentEF _student = new StudentFt().SelectAll().Where(x => x.StudentCode.ToString() == txbStudentCode.Text).FirstOrDefault();
            if (_student == null)
            {
                MessageBox.Show("Học sinh không tồn tại");
                return;
            }
            _ef.SchoolYear = txbSchoolYear.Text;
            bool result = new StudentInClassFt().Update(_ef);
            if (result == true)
            {
                List<StudentInClassEF> listStudentInClass = new StudentInClassFt().SelectAll();
                Load(listStudentInClass);
                MessageBox.Show("Sửa thành công");
            }
            else
            {
                MessageBox.Show("Sửa không thành công");
            }
        }

        private void btDelete_Click(object sender, EventArgs e)
        {
            if (txbClass.Text == "" || txbStudentCode.Text == "")
            {
                return;
            }
            StudentInClassEF _ef = new StudentInClassEF();
            _ef = new StudentInClassFt().SelectAll().Where(x => x.ClassCode == txbClass.Text && x.StudentCode.ToString() == txbStudentCode.Text).FirstOrDefault();
            if (_ef == null)
            {
                MessageBox.Show("Đối tượng không tồn tại");
         Ft().SelectAll().Where(x => x.StudentCode.ToString() == txbStudentCode.Text).FirstOrDefault();
            if (_student == null)
            {
                MessageBox.Show("Học sinh không tồn tại");
                return;
            }
            _ef.SchoolYear = txbSchoolYear.Text;
            bool result = new StudentInClassFt().Delete(_ef);
            if (result == true)
            {
                List<StudentInClassEF> listStudentInClass = new StudentInClassFt().SelectAll();
                Load(listStudentInClass);
                MessageBox.Show("Xóa thành công");
            }
            else
            {
                MessageBox.Show("Xóa không thành công");
            }
        }

        private void btSearch_Click(object sender, EventArgs e)
        {
            if (Text.Text == "")
            {
                MessageBox.Show("Nhập từ cần tìm kiếm");
                return;
            }
            string text = Text.Text;
            List<StudentInClassEF> listResults = new StudentInClassFt().SelectAll().Where(x => x.ClassCode == text || x.StudentCode.ToString() == text || x.SchoolYear == text).ToList();
            Load(listResults);
        }
    }
}
