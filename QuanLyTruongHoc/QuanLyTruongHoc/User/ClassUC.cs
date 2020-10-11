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
    public partial class ClassUC : UserControl
    {
        public ClassUC()
        {
            InitializeComponent();
            List<ClassEF> listClass = new ClassFt().SelectAll();
            Load(listClass);
        }

        void Load(List<ClassEF> listClass)
        {
            dgView.Rows.Clear();
            int index = 1;
            foreach (ClassEF item in listClass)
            {
                string TypeClass = item.Type == true ? "Lớp đại trà" : "Lớp chọn";
                dgView.Rows.Add(index.ToString(), item.ClassCode, TypeClass);
                index++;
            }
        }

        private void dgView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                return;
            }
            txbClass.Text = dgView.Rows[e.RowIndex].Cells["ClassCode"].Value.ToString();
            cbType.SelectedIndex = dgView.Rows[e.RowIndex].Cells["ClassCode"].Value.ToString() == "Cơ bản" ? 0 : 1;
        }

        private void btAdd_Click(object sender, EventArgs e)
        {
            if (txbClass.Text == "")
            {
                return;
            }
            if (cbType.Text == "")
            {
                return;
            }
            ClassEF ef = new ClassEF();
            ef.ClassCode = txbClass.Text;
            ef.Type = cbType.SelectedIndex == 0 ? true : false;
            bool result = new ClassFt().Insert(ef);
            if (result == true)
            {
                List<ClassEF> listClass = new ClassFt().SelectAll();
                Load(listClass);
                MessageBox.Show("Thêm lớp học thành công");
            }
            else
            {
                MessageBox.Show("Thêm lớp học thất bại");
            }
        }

        private void btEdit_Click(object sender, EventArgs e)
        {
            if (txbClass.Text == "")
            {
                return;
            }
            if (cbType.Text == "")
            {
                return;
            }
            ClassEF ef = new ClassEF();
            ef.ClassCode = txbClass.Text;
            ef.Type = cbType.SelectedIndex == 0 ? true : false;
            bool result = new ClassFt().Update(ef);
            if (result == true)
            {
                List<ClassEF> listClass = new ClassFt().SelectAll();
                Load(listClass);
                MessageBox.Show("Sửa lớp học thành công");
            }
            else
            {
                MessageBox.Show("Sửa lớp học thất bại");
            }
        }

        private void btDelete_Click(object sender, EventArgs e)
        {
            if (txbClass.Text == "")
            {
                return;
            }
            if (cbType.Text == "")
            {
                return;
            }
            ClassEF ef = new ClassEF();
            ef.ClassCode = txbClass.Text;
            ef.Type = cbType.SelectedIndex == 0 ? true : false;
            bool result = new ClassFt().Delete(ef);
            if (result == true)
            {
                List<ClassEF> listClass = new ClassFt().SelectAll();
                Load(listClass);
                MessageBox.Show("Xóa lớp học thành công");
            }
            else
            {
                MessageBox.Show("Xóa lớp học thất bại");
            }
        }

        private void btSearch_Click(object sender, EventArgs e)
        {
            string search = txbText.Text;
            if (search == "")
            {
                return;
            }
            List<ClassEF> ListResult = new ClassFt().SelectAll().Where(x => x.ClassCode == search).ToList();
            Load(ListResult);
        }
    }
}
