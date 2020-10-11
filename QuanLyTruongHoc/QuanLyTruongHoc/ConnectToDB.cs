using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace QuanLyTruongHoc.Function
{
    public class ConnectToDB
    {
        public SqlConnection connect;
        public static string StrConnect= @"Data Source=DESKTOP-70S3NIC\SQLEXPRESS;Initial Catalog=QuanLyTruongHoc;Integrated Security=True";
        public ConnectToDB()
        {
           
        }
        internal void OpenConnect()
        {
            if (connect == null)
            {
                connect = new SqlConnection(StrConnect);
            }
            connect.Open();
        }

        internal void CloseConnect()
        {
            if (connect != null)
            {
                if (connect.State == ConnectionState.Open)
                    connect.Close();
            }
        }
    }
}
