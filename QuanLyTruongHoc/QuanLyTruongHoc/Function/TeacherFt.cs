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
    class TeacherFt
    {
        ConnectToDB sql = new ConnectToDB();
        public bool Insert(TeacherEF ef)
        {
            bool result = false;
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "[dbo].[TeacherInsert]";
            cmd.CommandType = CommandType.StoredProcedure;

            try
            {
                sql.OpenConnect();
                cmd.Connection = sql.connect;

                cmd.Parameters.AddWithValue("@TeacherCode", ef.TeacherCode);
                cmd.Parameters.AddWithValue("@FullName", ef.FullName);
                cmd.Parameters.AddWithValue("@DateOfBirth", ef.DateOfBirth);
                int sex = ef.Sex == true ? 1 : 0;
                cmd.Parameters.AddWithValue("@Sex", sex);
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
        public bool Update(TeacherEF ef)
        {
            bool result = false;
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "[dbo].[TeacherUpdate]";
            cmd.CommandType = CommandType.StoredProcedure;

            try
            {
                sql.OpenConnect();
                cmd.Connection = sql.connect;

                cmd.Parameters.AddWithValue("@TeacherCode", ef.TeacherCode);
                cmd.Parameters.AddWithValue("@FullName", ef.FullName);
                cmd.Parameters.AddWithValue("@DateOfBirth", ef.DateOfBirth);
                int sex = ef.Sex == true ? 1 : 0;
                cmd.Parameters.AddWithValue("@Sex", sex);
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
        public bool Delete(TeacherEF ef)
        {
            bool result = false;
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "[dbo].[TeacherDelete]";
            cmd.CommandType = CommandType.StoredProcedure;

            try
            {
                sql.OpenConnect();
                cmd.Connection = sql.connect;

                cmd.Parameters.AddWithValue("@TeacherCode", ef.TeacherCode);

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
        public List<TeacherEF> SelectAll()
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[TeacherSelectAll]";
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

        internal void PopulateBusinessObjectFromReader(TeacherEF businessObject, IDataReader dataReader)
        {
            businessObject.TeacherCode = dataReader.GetInt32(dataReader.GetOrdinal(TeacherEF.TeacherFields.TeacherCode.ToString()));
            if (!dataReader.IsDBNull(dataReader.GetOrdinal(TeacherEF.TeacherFields.FullName.ToString())))
            {
                businessObject.FullName = dataReader.GetString(dataReader.GetOrdinal(TeacherEF.TeacherFields.FullName.ToString()));
            }
            if (!dataReader.IsDBNull(dataReader.GetOrdinal(TeacherEF.TeacherFields.DateOfBirth.ToString())))
            {
                businessObject.DateOfBirth = dataReader.GetDateTime(dataReader.GetOrdinal(TeacherEF.TeacherFields.DateOfBirth.ToString()));
            }
            if (!dataReader.IsDBNull(dataReader.GetOrdinal(TeacherEF.TeacherFields.Sex.ToString())))
            {
                businessObject.Sex = dataReader.GetBoolean(dataReader.GetOrdinal(TeacherEF.TeacherFields.Sex.ToString()));
            }
            if (!dataReader.IsDBNull(dataReader.GetOrdinal(TeacherEF.TeacherFields.Address.ToString())))
            {
                businessObject.Address = dataReader.GetString(dataReader.GetOrdinal(TeacherEF.TeacherFields.Address.ToString()));
            }
            if (!dataReader.IsDBNull(dataReader.GetOrdinal(TeacherEF.TeacherFields.Avatar.ToString())))
            {
                int length = (int)dataReader.GetBytes(dataReader.GetOrdinal(TeacherEF.TeacherFields.Avatar.ToString()), 0, null, 0, 0);
                businessObject.Avatar = new byte[length];
                dataReader.GetBytes(dataReader.GetOrdinal(TeacherEF.TeacherFields.Avatar.ToString()), 0, businessObject.Avatar, 0, length);
            }
        }
        internal List<TeacherEF> PopulateObjectsFromReader(IDataReader dataReader)
        {
            List<TeacherEF> list = new List<TeacherEF>();

            while (dataReader.Read())
            {
                TeacherEF businessObject = new TeacherEF();
                PopulateBusinessObjectFromReader(businessObject, dataReader);
                list.Add(businessObject);
            }
            return list;
        }
    }
}
