using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyTruongHoc.EF
{
    public class TeacherEF
    {
        private int _TeacherCode;
        private string _FullName;
        private DateTime _DateOfBirth;
        private bool _Sex;
        private string _Address;
        private byte[] _Avatar;
        public enum TeacherFields
        {
            TeacherCode,
            FullName,
            DateOfBirth,
            Sex,
            Address,
            Avatar
        }

        public int TeacherCode { get => _TeacherCode; set => _TeacherCode = value; }
        public string FullName { get => _FullName; set => _FullName = value; }
        public DateTime DateOfBirth { get => _DateOfBirth; set => _DateOfBirth = value; }
        public bool Sex { get => _Sex; set => _Sex = value; }
        public string Address { get => _Address; set => _Address = value; }
        public byte[] Avatar { get => _Avatar; set => _Avatar = value; }
    }
}
