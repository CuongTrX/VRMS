using System.Data;

namespace VRMS.App_Code.BLL
{
    public class PermissionBLL
    {
        //Phương thức khởi tạo
        public PermissionBLL() { }
        DAL.PermissionDAL dal = new DAL.PermissionDAL();

        //Phương thức lấy dữ liệu từ bảng 
        public DataTable getPermission()
        {
            return dal.getPermission();
        }
    }
}
