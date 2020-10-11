using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyTruongHoc.EF
{
    public class ClassEF
    {
        private string _ClassCode;
        private bool _Type;
        public enum ClassFields
        {
            ClassCode,
            Type
        }

        public string ClassCode { get => _ClassCode; set => _ClassCode = value; }
        public bool Type { get => _Type; set => _Type = value; }
    }
}
