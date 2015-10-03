using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace VRMS.App_Code.DAL
{
    class DBLib
    {
        //Khai báo biến thành viên
        string strConnect;
        private SqlConnection oCnn;
        private SqlCommand oCmd;
        private bool isOpen; //Kiểm tra tình trạng kết nối

        //Phương thức khởi tạo
        public DBLib()
        {
            //Khai báo chuỗi kết nối
            strConnect = ConfigurationManager.ConnectionStrings["VRMSConnect"].ConnectionString;

            //Khởi tạo đối tượng SqlConnection
            oCnn = new SqlConnection(strConnect);
            //Khởi tạo đối tượng SqlCommand
            oCmd = new SqlCommand();
            oCmd.Connection = oCnn;
        }

        //Phương thức mở kết nối CSDL
        public void Open()
        {
            if (isOpen)
                return;
            if (oCnn.State != ConnectionState.Open)
            {
                oCnn.Open();
                isOpen = true;
            }
        }

        //Phương thức đóng kết nối
        public void Close()
        {
            oCmd.Connection.Close();
            isOpen = false;
        }

        //Phương thức truyền tham số với tên tham số và giá trị
        public void AddParameter(string paraName, object paraValue)
        {
            SqlParameter para = new SqlParameter();
            para.ParameterName = paraName;
            para.Value = paraValue;
            oCmd.Parameters.Add(para);
        }

        //Phương thức thực thi câu lệnh SQL với câu lệnh Sql và kiểu câu lệnh
        public int ExecuteNonQuery(string cmdText, CommandType cmdType)
        {
            try
            {
                this.Open();
                oCmd.CommandText = cmdText;
                oCmd.CommandType = cmdType;
                return oCmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public SqlDataReader ExecuteReader(string cmdText, CommandType cmdType)
        {
            try
            {
                //Mở kết nối
                this.Open();
                oCmd.CommandText = cmdText;
                oCmd.CommandType = cmdType;
                return oCmd.ExecuteReader();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public object ExecuteScalar(string cmdText, CommandType cmdType)
        {
            try
            {
                //Mở kết nối
                this.Open();
                oCmd.CommandText = cmdText;
                oCmd.CommandType = cmdType;
                return oCmd.ExecuteScalar();
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Phương thức điền dư liệu vào DataTable
        public DataTable FillDataTable(string cmdText, CommandType cmdType)
        {
            DataTable table = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(oCmd);
            SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
            try
            {
                oCmd.CommandText = cmdText;
                oCmd.CommandType = cmdType;
                adapter.Fill(table);
                adapter.Dispose();
            }
            catch (Exception)
            {

                throw;
            }
            return table;
        }
        //Phương thức điền dữ liệu vào DataTable với câu lệnh, kiểu câu lệnh, mảng tham số
        public DataTable FillDataTable(string cmdText, CommandType cmdType,
            string[] arrayPara, object[] arrayValue, SqlDbType[] arrayDbType)
        {
            DataTable table = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(oCmd);
            SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
            try
            {
                oCmd.CommandText = cmdText;
                oCmd.CommandType = cmdType;
                SqlParameter para;
                for (int i = 0; i < arrayPara.Length; i++)
                {
                    para = new  SqlParameter();
                    para.ParameterName = arrayPara[i];
                    para.Value = arrayValue[i];
                    para.SqlDbType = arrayDbType[i];
                    oCmd.Parameters.Add(para);
                }
                adapter.Fill(table);
                adapter.Dispose();
            }
            catch (Exception)
            {

                throw;
            }
            return table;
        }
    }
}
