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
    public class StudentInClassFt
    {
        ConnectToDB sql = new ConnectToDB();
        public bool Insert(StudentInClassEF ef)
        {
            bool result = false;
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "[dbo].[StudentInClassInsert]";
            cmd.CommandType = CommandType.StoredProcedure;

            try
            {
                sql.OpenConnect();
                cmd.Connection = sql.connect;

                cmd.Parameters.AddWithValue("@StudentCode", ef.StudentCode);
                cmd.Parameters.AddWithValue("@ClassCode", ef.ClassCode);
                cmd.Parameters.AddWithValue("@SchoolYear", ef.SchoolYear);

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
        public bool Update(StudentInClassEF ef)
        {
            bool result = false;
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "[dbo].[StudentInClassUpdate]";
            cmd.CommandType = CommandType.StoredProcedure;

            try
            {
                sql.OpenConnect();
                cmd.Connection = sql.connect;

                cmd.Parameters.AddWithValue("@StudentCode", ef.StudentCode);
                cmd.Parameters.AddWithValue("@ClassCode", ef.ClassCode);
                cmd.Parameters.AddWithValue("@SchoolYear", ef.SchoolYear);

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
        public bool Delete(StudentInClassEF ef)
        {
            bool result = false;
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "[dbo].[StudentInClassDelete]";
            cmd.CommandType = CommandType.StoredProcedure;

            try
            {
                sql.OpenConnect();
                cmd.Connection = sql.connect;

                cmd.Parameters.AddWithValue("@StudentCode", ef.StudentCode);
                cmd.Parameters.AddWithValue("@ClassCode", ef.ClassCode);

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
        public List<StudentInClassEF> SelectAll()
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[StudentInClassSelectAll]";
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

        internal void PopulateBusinessObjectFromReader(StudentInClassEF businessObject, IDataReader dataReader)
        {
            businessObject.StudentCode = dataReader.GetInt32(dataReader.GetOrdinal(StudentInClassEF.StudentInClassFields.StudentCode.ToString()));
            if (!dataReader.IsDBNull(dataReader.GetOrdinal(StudentInClassEF.StudentInClassFields.ClassCode.ToString())))
            {
                businessObject.ClassCode = dataReader.GetString(dataReader.GetOrdinal(StudentInClassEF.StudentInClassFields.ClassCode.ToString()));
            }
            if (!dataReader.IsDBNull(dataReader.GetOrdinal(StudentInClassEF.StudentInClassFields.SchoolYear.ToString())))
            {
                businessObject.SchoolYear = dataReader.GetString(dataReader.GetOrdinal(StudentInClassEF.StudentInClassFields.SchoolYear.ToString()));
            }
        }
        internal List<StudentInClassEF> PopulateObjectsFromReader(IDataReader dataReader)
        {
            List<StudentInClassEF> list = new List<StudentInClassEF>();

            while (dataReader.Read())
            {
                StudentInClassEF businessObject = new StudentInClassEF();
                PopulateBusinessObjectFromReader(businessObject, dataReader);
                list.Add(businessObject);
            }
            return list;
        }
    }
}
