using QuanLyTruongHoc.EF;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyTruongHoc.Function
{
    public class StudentFt
    {
        ConnectToDB sql = new ConnectToDB();
        public bool Insert(StudentEF ef)
        {
            bool result = false;
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "[dbo].[StudentInsert]";
            cmd.CommandType = CommandType.StoredProcedure;

            try
            {
                sql.OpenConnect();
                cmd.Connection = sql.connect;

                cmd.Parameters.AddWithValue("@StudentCode", ef.StudentCode);
                cmd.Parameters.AddWithValue("@FullName", ef.FullName);
                cmd.Parameters.AddWithValue("@DateOfBirth", ef.DateOfBirth);
                cmd.Parameters.AddWithValue("@Sex", ef.Sex);
                cmd.Parameters.AddWithValue("@Address", ef.Address);
                cmd.Parameters.Add(new SqlParameter("@Avatar", SqlDbType.Image)).Value = ef.Avatar;

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
        public bool Update(StudentEF ef)
        {
            bool result = false;
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "[dbo].[StudentUpdate]";
            cmd.CommandType = CommandType.StoredProcedure;

            try
            {
                sql.OpenConnect();
                cmd.Connection = sql.connect;

                cmd.Parameters.AddWithValue("@StudentCode", ef.StudentCode);
                cmd.Parameters.AddWithValue("@FullName", ef.FullName);
                cmd.Parameters.AddWithValue("@DateOfBirth", ef.DateOfBirth);
                cmd.Parameters.AddWithValue("@Sex", ef.Sex);
                cmd.Parameters.AddWithValue("@Address", ef.Address);
                cmd.Parameters.Add(new SqlParameter("@Avatar", SqlDbType.Image)).Value = ef.Avatar;

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
        public bool Delete(StudentEF ef)
        {
            bool result = false;
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "[dbo].[StudentDelete]";
            cmd.CommandType = CommandType.StoredProcedure;

            try
            {
                sql.OpenConnect();
                cmd.Connection = sql.connect;

                cmd.Parameters.AddWithValue("@StudentCode", ef.StudentCode);

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
        public List<StudentEF> SelectAll()
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[StudentSelectAll]";
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {

                sql.OpenConnect();
                // Use connection object of base class
                sqlCommand.Connection = sql.connect;

                IDataReader dataReader = sqlCommand.ExecuteReader();

                return PopulateObjectsFromReader(dataReader);

            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lấy tất cả: ", ex);
            }
            finally
            {
                sql.CloseConnect();
                sqlCommand.Dispose();
            }
        }

        internal void PopulateBusinessObjectFromReader(StudentEF businessObject, IDataReader dataReader)
        {
            businessObject.StudentCode = dataReader.GetInt32(dataReader.GetOrdinal(StudentEF.StudentFields.StudentCode.ToString()));
            if (!dataReader.IsDBNull(dataReader.GetOrdinal(StudentEF.StudentFields.FullName.ToString())))
            {
                businessObject.FullName = dataReader.GetString(dataReader.GetOrdinal(StudentEF.StudentFields.FullName.ToString()));
            }
            if (!dataReader.IsDBNull(dataReader.GetOrdinal(StudentEF.StudentFields.DateOfBirth.ToString())))
            {
                businessObject.DateOfBirth = dataReader.GetDateTime(dataReader.GetOrdinal(StudentEF.StudentFields.DateOfBirth.ToString()));
            }
            if (!dataReader.IsDBNull(dataReader.GetOrdinal(StudentEF.StudentFields.Sex.ToString())))
            {
                businessObject.Sex = dataReader.GetBoolean(dataReader.GetOrdinal(StudentEF.StudentFields.Sex.ToString()));
            }
            if (!dataReader.IsDBNull(dataReader.GetOrdinal(StudentEF.StudentFields.Address.ToString())))
            {
                businessObject.Address = dataReader.GetString(dataReader.GetOrdinal(StudentEF.StudentFields.Address.ToString()));
            }
            if (!dataReader.IsDBNull(dataReader.GetOrdinal(StudentEF.StudentFields.Avatar.ToString())))
            {
                int length = (int)dataReader.GetBytes(dataReader.GetOrdinal(StudentEF.StudentFields.Avatar.ToString()), 0, null, 0, 0);
                businessObject.Avatar = new byte[length];
                dataReader.GetBytes(dataReader.GetOrdinal(StudentEF.StudentFields.Avatar.ToString()), 0, businessObject.Avatar, 0, length);
            }
        }
        internal List<StudentEF> PopulateObjectsFromReader(IDataReader dataReader)
        {
            List<StudentEF> list = new List<StudentEF>();

            while (dataReader.Read())
            {
                StudentEF businessObject = new StudentEF();
                PopulateBusinessObjectFromReader(businessObject, dataReader);
                list.Add(businessObject);
            }
            return list;
        }
    }
}
