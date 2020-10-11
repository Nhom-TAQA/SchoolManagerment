using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using QuanLyTruongHoc.EF;
using QuanLyTruongHoc.Function;

namespace QuanLyTruongHoc.User
{
    public partial class TeacherUC : UserControl
    {
        int width;
        int height;
        public TeacherUC(int _width, int _height)
        {
            width = _width;
            height = _height;
            InitializeComponent();
            List<TeacherEF> listTeacher = new TeacherFt().SelectAll();
            Load(listTeacher);
        }
        void Load(List<TeacherEF> listTeacher)
        {
            dgView.Rows.Clear();
            int index = 1;
            foreach (TeacherEF item in listTeacher)
            {
                string sex = item.Sex == true ? "Nam" : "Nu";
                dgView.Rows.Add(index.ToString(), item.TeacherCode, item.FullName, sex, String.Format("{0:dd/MM/yyyy}", item.DateOfBirth));
                index++;
            }
        }
        private void btAdd_Click(object sender, EventArgs e)
        {
            if (txbCode.Text == "" || txbName.Text == "")
            {
                return;
            }
            if (ArrByte_Anh == null)
            {
                MessageBox.Show("Hãy thêm ảnh bằng cách nháy đúp vào khung ảnh.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            string TeacherCode = txbCode.Text;
            TeacherEF _Teacher = new TeacherFt().SelectAll().Where(x => x.TeacherCode == Int32.Parse(TeacherCode)).FirstOrDefault();
            if (_Teacher != null)
            {
                MessageBox.Show("Mã giáo viên đã tồn tại", "Thông báo", MessageBoxButtons.OK);
                return;
            }
            TeacherEF Teacher = new TeacherEF();
            Teacher.TeacherCode = Int32.Parse(TeacherCode);
            Teacher.FullName = txbName.Text;
            Teacher.Sex = cbSex.SelectedIndex == 0 ? true : false;
            Teacher.DateOfBirth = dtDateOfBirth.Value;
            Teacher.Address = txbAddress.Text;
            Teacher.Avatar = ArrByte_Anh;
            bool result = new TeacherFt().Insert(Teacher);
            if (result == true)
            {
                List<TeacherEF> listTeacher = new TeacherFt().SelectAll();
                Load(listTeacher);
                MessageBox.Show("Thêm thành công giáo viên", "Thông báo");
            }
            else
            {
                MessageBox.Show("Thêm không thành công giáo viên", "Thông báo");
            }
        }

        private void btEdit_Click(object sender, EventArgs e)
        {
            if (txbCode.Text == "" || txbName.Text == "")
            {
                return;
            }
            if (ArrByte_Anh == null)
            {
                MessageBox.Show("Hãy thêm ảnh bằng cách nháy đúp vào khung ảnh.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            string TeacherCode = txbCode.Text;
            TeacherEF Teacher = new TeacherEF();
            Teacher.TeacherCode = Int32.Parse(TeacherCode);
            Teacher.FullName = txbName.Text;
            Teacher.Sex = cbSex.SelectedIndex == 0 ? true : false;
            Teacher.DateOfBirth = dtDateOfBirth.Value;
            Teacher.Address = txbAddress.Text;
            Teacher.Avatar = ArrByte_Anh;
            bool result = new TeacherFt().Update(Teacher);
            if (result == true)
            {
                List<TeacherEF> listTeacher = new TeacherFt().SelectAll();
                Load(listTeacher);
                MessageBox.Show("Sửa thành công giáo viên", "Thông báo");
            }
            else
            {
                MessageBox.Show("Sửa không thành công giáo viên", "Thông báo");
            }
        }

        private void btDelete_Click(object sender, EventArgs e)
        {
            if (txbCode.Text == "" || txbName.Text == "")
            {
                return;
            }
            string TeacherCode = txbCode.Text;
            TeacherEF Teacher = new TeacherEF();
            Teacher.TeacherCode = Int32.Parse(TeacherCode);
            Teacher.FullName = txbName.Text;
            Teacher.Sex = cbSex.SelectedIndex == 0 ? true : false;
            Teacher.DateOfBirth = dtDateOfBirth.Value;
            Teacher.Address = txbAddress.Text;
            Teacher.Avatar = ArrByte_Anh;
            bool result = new TeacherFt().Delete(Teacher);
            if (result == true)
            {
                List<TeacherEF> listTeacher = new TeacherFt().SelectAll();
                Load(listTeacher);
                MessageBox.Show("Xóa thành công giáo viên", "Thông báo");
            }
            else
            {
                MessageBox.Show("Xóa không thành công giáo viên", "Thông báo");
            }
        }

        private void btSearch_Click(object sender, EventArgs e)
        {
            if(Text.Text == "")
            {
                return;
            }
            string text = Text.Text;
            List<TeacherEF> listTeacher = new TeacherFt().SelectAll().Where(x => x.FullName == text || x.TeacherCode.ToString() == text || x.Address == text).ToList();
            Load(listTeacher);
        }

        private void dgView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                return;
            }
            string TeacherCode = dgView.Rows[e.RowIndex].Cells["TeacherCode"].Value.ToString();
            TeacherEF Teacher = new TeacherFt().SelectAll().Where(x => x.TeacherCode.ToString() == TeacherCode).ToList().FirstOrDefault();
            txbCode.Text = TeacherCode;
            txbName.Text = Teacher.FullName;
            dtDateOfBirth.Value = Teacher.DateOfBirth;
            cbSex.SelectedIndex = Teacher.Sex == true ? 0 : 1;
            ArrByte_Anh = Teacher.Avatar;
            picAvt.Image = ImageHandle.ByteToImage(ArrByte_Anh);
            txbAddress.Text = Teacher.Address;
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
