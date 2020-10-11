using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyTruongHoc.EF
{
    public class StudentInClassEF
    {
        private int _StudentCode;
        private string _ClassCode;
        private string _SchoolYear;
        public enum StudentInClassFields
        {
            StudentCode,
            ClassCode,
            SchoolYear
        }

        public int StudentCode { get => _StudentCode; set => _StudentCode = value; }
        public string ClassCode { get => _ClassCode; set => _ClassCode = value; }
        public string SchoolYear { get => _SchoolYear; set => _SchoolYear = value; }
    }
}
