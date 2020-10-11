using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyTruongHoc.EF
{
    public class AccountEF
    {
        private int _ID;
        private string _Username;
        private string _Password;
        public AccountEF()
        {
            ID = 0;
            _Username = "";
            _Password = "";
        }
        public enum AccountFields
        {
            ID,
            UserName, 
            Password
        }

        public int ID { get => _ID; set => _ID = value; }
        public string Username { get => _Username; set => _Username = value; }
        public string Password { get => _Password; set => _Password = value; }
    }
}
