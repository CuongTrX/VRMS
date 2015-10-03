using System;
using System.Data;

namespace VRMS.App_Code.DAL
{
    public class PermissionDAL
    {
        DBLib db;

        //Phương thức khởi tạo
        public PermissionDAL() { }

        //Phương thức lấy dữ liệu từ bảng 
        public DataTable getPermission()
        {
            DataTable table = new DataTable();
            try
            {
                db = new DBLib();

                table = db.FillDataTable("sp_SelectPermission", CommandType.StoredProcedure);
               
            }
            catch (Exception)
            {

                throw;
            }
            return table;
        }
    }
}
