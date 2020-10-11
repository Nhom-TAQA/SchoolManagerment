using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyTruongHoc.EF;

namespace QuanLyTruongHoc.Function
{
    public class AccountFt
    {
        ConnectToDB sql = new ConnectToDB();
        public bool Insert(AccountEF ef)
        {
            bool result = false;
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "[dbo].[AccountInsert]";
            cmd.CommandType = CommandType.StoredProcedure;

            try
            {
                sql.OpenConnect();
                cmd.Connection = sql.connect;

                cmd.Parameters.AddWithValue("@username", ef.Username);
                cmd.Parameters.AddWithValue("@password", ef.Password);

                cmd.ExecuteNonQuery();
                result = true;
            }
            catch
            {
                result = false;
            }
            finally
            {
                sql.CloseConnect();
                cmd.Dispose();
            }
            return result;
        }
        public bool Update(AccountEF ef)
        {
            bool result = false;
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "[dbo].[AccountUpdate]";
            cmd.CommandType = CommandType.StoredProcedure;

            try
            {
                sql.OpenConnect();
                cmd.Connection = sql.connect;

                cmd.Parameters.AddWithValue("@ID", ef.ID);
                cmd.Parameters.AddWithValue("@username", ef.Username);
                cmd.Parameters.AddWithValue("@password", ef.Password);

                cmd.ExecuteNonQuery();
                result = true;
            }
            catch
            {
                result = false;
            }
            finally
            {
                sql.CloseConnect();
                cmd.Dispose();
            }
            return result;
        }
        public bool Delete(AccountEF ef)
        {
            bool result = false;
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "[dbo].[AccountDelete]";
            cmd.CommandType = CommandType.StoredProcedure;

            try
            {
                sql.OpenConnect();
                cmd.Connection = sql.connect;

                cmd.Parameters.AddWithValue("@ID", ef.ID);

                cmd.ExecuteNonQuery();
                result = true;
            }
            catch
            {
                result = false;
            }
            finally
            {
                sql.CloseConnect();
                cmd.Dispose();
            }
            return result;
        }
        public List<AccountEF> SelectAll()
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[AccountSelectAll]";
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {

                sql.OpenConnect();
                // Use connection object of base Account
                sqlCommand.Connection = sql.connect;

                IDataReader dataReader = sqlCommand.ExecuteReader();

                return PopulateObjectsFromReader(dataReader);

            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lấy tất cả tài khoản: ", ex);
            }
            finally
            {
                sql.CloseConnect();
                sqlCommand.Dispose();
            }
        }

        internal void PopulateBusinessObjectFromReader(AccountEF businessObject, IDataReader dataReader)
        {
            businessObject.ID = dataReader.GetInt32(dataReader.GetOrdinal(AccountEF.AccountFields.ID.ToString()));
            
            if (!dataReader.IsDBNull(dataReader.GetOrdinal(AccountEF.AccountFields.UserName.ToString())))
            {
                businessObject.Username = dataReader.GetString(dataReader.GetOrdinal(AccountEF.AccountFields.UserName.ToString()));
            }

            if (!dataReader.IsDBNull(dataReader.GetOrdinal(AccountEF.AccountFields.Password.ToString())))
            {
                businessObject.Password = dataReader.GetString(dataReader.GetOrdinal(AccountEF.AccountFields.Password.ToString()));
            }
        }
        internal List<AccountEF> PopulateObjectsFromReader(IDataReader dataReader)
        {
            List<AccountEF> list = new List<AccountEF>();

            while (dataReader.Read())
            {
                AccountEF businessObject = new AccountEF();
                PopulateBusinessObjectFromReader(businessObject, dataReader);
                list.Add(businessObject);
            }
            return list;
        }
    }
}
