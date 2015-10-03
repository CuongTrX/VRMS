using System;
using System.Data;
using System.Data.SqlClient;
using VRMS.App_Code.DAL;
using VRMS.App_Code.DTO;

namespace VRMS.App_Code.BLL
{
    public class UsersBLL
    {
        UsersDAL dalUsers;

        //Phương thức khởi tạo
        public UsersBLL() { }

        //Phương thức thêm dữ liệu vào bảng Khoa
        public bool InsertUser(UsersDTO dtoUsers)
        {
            dalUsers = new UsersDAL();

            try
            {
                return dalUsers.InsertUser(dtoUsers);
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Phương thức lấy dữ liệu từ bảng 
        public DataTable selectUserDetails()
        {
            dalUsers = new UsersDAL();

            try
            {
                return dalUsers.selectUserDetails();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public SqlDataReader selectUserDetailsByID(int IdUser)
        {
            dalUsers = new UsersDAL();

            try
            {
                return dalUsers.selectUserDetailsByID(IdUser);
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Phương thức kiểm tra User
        public SqlDataReader CheckUser(string Username)
        {
            dalUsers = new UsersDAL();
            try
            {
                return dalUsers.CheckUser(Username);
            }
            catch (Exception)
            {

                throw;
            }
        }

        //Phương thức cập nhật dữ liệu bảng Khoa
        public bool UpdateUser(UsersDTO dtoUsers)
        {
            dalUsers = new UsersDAL();

            try
            {
                return dalUsers.UpdateUser(dtoUsers);
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Phương thức xóa dữ liệu bảng Khoa
        public bool DeleteUser(int IdUser)
        {
            dalUsers = new UsersDAL();

            try
            {
                return dalUsers.DeleteUser(IdUser);
            }
            catch (Exception)
            {
                throw;
            }
        }
        
    }
}
