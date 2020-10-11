using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using QuanLyTruongHoc.EF;

namespace QuanLyTruongHoc.Function
{
    public class HomeroomTeacherFt
    {
        ConnectToDB sql = new ConnectToDB();
        public bool Insert(HomeroomTeacherEF ef)
        {
            bool result = false;
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "[dbo].[HomeroomTeacherInsert]";
            cmd.CommandType = CommandType.StoredProcedure;

            try
            {
                sql.OpenConnect();
                cmd.Connection = sql.connect;
                
                cmd.Parameters.AddWithValue("@TeacherCode", ef.TeacherCode);
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
        public bool Update(HomeroomTeacherEF ef)
        {
            bool result = false;
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "[dbo].[HomeroomTeacherUpdate]";
            cmd.CommandType = CommandType.StoredProcedure;

            try
            {
                sql.OpenConnect();
                cmd.Connection = sql.connect;

                cmd.Parameters.AddWithValue("@TeacherCode", ef.TeacherCode);
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
        public bool Delete(HomeroomTeacherEF ef)
        {
            bool result = false;
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "[dbo].[HomeroomTeacherDelete]";
            cmd.CommandType = CommandType.StoredProcedure;

            try
            {
                sql.OpenConnect();
                cmd.Connection = sql.connect;

                cmd.Parameters.AddWithValue("@TeacherCode", ef.TeacherCode);
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
        public List<HomeroomTeacherEF> SelectAll()
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[HomeroomTeacherSelectAll]";
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

        internal void PopulateBusinessObjectFromReader(HomeroomTeacherEF businessObject, IDataReader dataReader)
        {
            businessObject.TeacherCode = dataReader.GetInt32(dataReader.GetOrdinal(HomeroomTeacherEF.HomeroomTeacherFields.TeacherCode.ToString()));
            if (!dataReader.IsDBNull(dataReader.GetOrdinal(HomeroomTeacherEF.HomeroomTeacherFields.ClassCode.ToString())))
            {
                businessObject.ClassCode = dataReader.GetString(dataReader.GetOrdinal(HomeroomTeacherEF.HomeroomTeacherFields.ClassCode.ToString()));
            }
            if (!dataReader.IsDBNull(dataReader.GetOrdinal(HomeroomTeacherEF.HomeroomTeacherFields.SchoolYear.ToString())))
            {
                businessObject.SchoolYear = dataReader.GetString(dataReader.GetOrdinal(HomeroomTeacherEF.HomeroomTeacherFields.SchoolYear.ToString()));
            }
        }
        internal List<HomeroomTeacherEF> PopulateObjectsFromReader(IDataReader dataReader)
        {
            List<HomeroomTeacherEF> list = new List<HomeroomTeacherEF>();

            while (dataReader.Read())
            {
                HomeroomTeacherEF businessObject = new HomeroomTeacherEF();
                PopulateBusinessObjectFromReader(businessObject, dataReader);
                list.Add(businessObject);
            }
            return list;
        }
    }
}
