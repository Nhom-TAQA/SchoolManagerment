using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyTruongHoc.EF
{
    public class HomeroomTeacherEF
    {
        private int _TeacherCode;
        private string _ClassCode;
        private string _SchoolYear;
        public enum HomeroomTeacherFields
        {
            TeacherCode,
            ClassCode,
            SchoolYear
        }

        public int TeacherCode { get => _TeacherCode; set => _TeacherCode = value; }
        public string ClassCode { get => _ClassCode; set => _ClassCode = value; }
        public string SchoolYear { get => _SchoolYear; set => _SchoolYear = value; }
    }
}
