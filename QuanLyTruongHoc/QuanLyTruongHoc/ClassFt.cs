using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyTruongHoc.EF;
using System.Data;
using System.Data.SqlClient;

namespace QuanLyTruongHoc.Function
{
    public class ClassFt
    {
        ConnectToDB sql = new ConnectToDB();
        public bool Insert(ClassEF ef)
        {
            bool result = false;
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "[dbo].[ClassInsert]";
            cmd.CommandType = CommandType.StoredProcedure;

            try
            {
                sql.OpenConnect();
                cmd.Connection = sql.connect;

                cmd.Parameters.AddWithValue("@ClassCode", ef.ClassCode);
                cmd.Parameters.AddWithValue("@Type", ef.Type);

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
        public bool Update(ClassEF ef)
        {
            bool result = false;
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "[dbo].[ClassUpdate]";
            cmd.CommandType = CommandType.StoredProcedure;

            try
            {
                sql.OpenConnect();
                cmd.Connection = sql.connect;

                cmd.Parameters.AddWithValue("@ClassCode", ef.ClassCode);
                cmd.Parameters.AddWithValue("@Type", ef.Type);

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
        public bool Delete(ClassEF ef)
        {
            bool result = false;
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "[dbo].[ClassDelete]";
            cmd.CommandType = CommandType.StoredProcedure;

            try
            {
                sql.OpenConnect();
                cmd.Connection = sql.connect;

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
        public List<ClassEF> SelectAll()
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[ClassSelectAll]";
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
                throw new Exception("Lỗi khi lấy tất cả lớp học: ", ex);
            }
            finally
            {
                sql.CloseConnect();
                sqlCommand.Dispose();
            }
        }

        internal void PopulateBusinessObjectFromReader(ClassEF businessObject, IDataReader dataReader)
        {
            businessObject.ClassCode = dataReader.GetString(dataReader.GetOrdinal(ClassEF.ClassFields.ClassCode.ToString()));
            if (!dataReader.IsDBNull(dataReader.GetOrdinal(ClassEF.ClassFields.Type.ToString())))
            {
                businessObject.Type = dataReader.GetBoolean(dataReader.GetOrdinal(ClassEF.ClassFields.Type.ToString()));
            }
        }
        internal List<ClassEF> PopulateObjectsFromReader(IDataReader dataReader)
        {
            List<ClassEF> list = new List<ClassEF>();

            while (dataReader.Read())
            {
                ClassEF businessObject = new ClassEF();
                PopulateBusinessObjectFromReader(businessObject, dataReader);
                list.Add(businessObject);
            }
            return list;
        }
    }
}
