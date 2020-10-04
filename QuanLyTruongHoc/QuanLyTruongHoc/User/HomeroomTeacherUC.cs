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
    public partial class HomeroomTeacherUC : UserControl
    {
        public HomeroomTeacherUC()
        {
            InitializeComponent();
            List<HomeroomTeacherEF> listResults = new List<HomeroomTeacherEF>();
            listResults = new HomeroomTeacherFt().SelectAll();
            Load(listResults);
        }
        void Load(List<HomeroomTeacherEF> listResults)
        {
            dgView.Rows.Clear();
            int index = 1;
            foreach (var item in listResults)
            {
                TeacherEF teacher = new TeacherFt().SelectAll().Where(x => x.TeacherCode == item.TeacherCode).FirstOrDefault();
                dgView.Rows.Add(index.ToString(), item.ClassCode, teacher.TeacherCode, teacher.FullName, item.SchoolYear);
                index++;
            }
        }
        private void btAdd_Click(object sender, EventArgs e)
        {
            if (txbClass.Text == "" || txbTeacherCode.Text == "" || txbSchoolYear.Text == "")
            {
                return;
            }
            HomeroomTeacherEF _ef = new HomeroomTeacherEF();
            _ef = new HomeroomTeacherFt().SelectAll().Where(x => x.ClassCode == txbClass.Text && x.TeacherCode.ToString() == txbTeacherCode.Text).FirstOrDefault();
            if (_ef != null)
            {
                MessageBox.Show("");
                return;
            }
            ClassEF _class = new ClassFt().SelectAll().Where(x => x.ClassCode == txbClass.Text).FirstOrDefault();
            if (_class != null)
            {
                MessageBox.Show("");
                return;
            }
            TeacherEF _teacher = new TeacherFt().SelectAll().Where(x => x.TeacherCode.ToString() == txbTeacherCode.Text).FirstOrDefault();
            if (_teacher != null)
            {
                MessageBox.Show("");
                return;
            }
            HomeroomTeacherEF ef = new HomeroomTeacherEF();
            ef.ClassCode = txbClass.Text;
            ef.TeacherCode = Int32.Parse(txbTeacherCode.Text);
            ef.SchoolYear = txbSchoolYear.Text;
            bool result = new HomeroomTeacherFt().Insert(ef);
            if (result == true)
            {
                MessageBox.Show("");
            }
            else
            {
                MessageBox.Show("");
            }
        }

        private void btEdit_Click(object sender, EventArgs e)
        {
            if (txbClass.Text == "" || txbTeacherCode.Text == "" || txbSchoolYear.Text == "")
            {
                return;
            }
            HomeroomTeacherEF _ef = new HomeroomTeacherEF();
            _ef = new HomeroomTeacherFt().SelectAll().Where(x => x.ClassCode == txbClass.Text && x.TeacherCode.ToString() == txbTeacherCode.Text).FirstOrDefault();
            if (_ef == null)
            {
                MessageBox.Show("");
                return;
            }
            _ef.SchoolYear = txbSchoolYear.Text;
            bool result = new HomeroomTeacherFt().Update(_ef);
            if (result == true)
            {
                MessageBox.Show("");
            }
            else
            {
                MessageBox.Show("");
            }
        }

        private void btDelete_Click(object sender, EventArgs e)
        {
            if (txbClass.Text == "" || txbTeacherCode.Text == "" || txbSchoolYear.Text == "")
            {
                return;
            }
            HomeroomTeacherEF _ef = new HomeroomTeacherEF();
            _ef = new HomeroomTeacherFt().SelectAll().Where(x => x.ClassCode == txbClass.Text && x.TeacherCode.ToString() == txbTeacherCode.Text).FirstOrDefault();
            if (_ef == null)
            {
                MessageBox.Show("");
                return;
            }
            bool result = new HomeroomTeacherFt().Delete(_ef);
            if (result == true)
            {
                MessageBox.Show("");
            }
            else
            {
                MessageBox.Show("");
            }
        }

        private void btSearch_Click(object sender, EventArgs e)
        {
            if (Text.Text == "")
            {
                MessageBox.Show("");
                return;
            }
            string text = Text.Text;
            List<HomeroomTeacherEF> listResults = new List<HomeroomTeacherEF>();
            listResults = new HomeroomTeacherFt().SelectAll().Where(x => x.ClassCode == text || x.TeacherCode.ToString() == text || x.SchoolYear == text).ToList();
            Load(listResults);
        }

        private void dgView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
                return;
            string classCode = dgView.Rows[e.RowIndex].Cells["ClassCode"].Value.ToString();
            string teacherCode = dgView.Rows[e.RowIndex].Cells["TeacherCode"].Value.ToString();
            HomeroomTeacherEF ef = new HomeroomTeacherFt().SelectAll().Where(x => x.TeacherCode.ToString() == teacherCode && x.ClassCode == classCode).FirstOrDefault();
            TeacherEF teacher = new TeacherFt().SelectAll().Where(x => x.TeacherCode.ToString() == teacherCode).FirstOrDefault();
            ClassEF _class = new ClassFt().SelectAll().Where(x => x.ClassCode == classCode).FirstOrDefault();
            txbClass.Text = ef.ClassCode;
            txbTeacherCode.Text = ef.TeacherCode.ToString();
            txbSchoolYear.Text = ef.SchoolYear;
            txbTeacherName.Text = teacher.FullName;
            txbType.Text = _class.Type == true ? "Lớp chọn" : "Lớp đại trà";
        }
    }
}
