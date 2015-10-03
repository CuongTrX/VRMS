using System;
using System.Data;
using System.Data.SqlClient;
using VRMS.App_Code.DTO;

namespace VRMS.App_Code.DAL
{
    public class UsersDAL
    {
        DBLib db;

        //Phương thức khởi tạo
        public UsersDAL() { }

        //Phương thức thêm dữ liệu vào bảng 
        public bool InsertUser(UsersDTO dto)
        {
            db = new DBLib();

            try
            {
                db.AddParameter("@Fullname", dto.Fullname);
                db.AddParameter("@Username", dto.Username);
                db.AddParameter("@Password", func.pHash(dto.Password));
                db.AddParameter("@IdPermission", dto.IdPermission);
                return db.ExecuteNonQuery("sp_InsertUser", CommandType.StoredProcedure) > 0;
            }
            catch (Exception)
            {

                throw;
            }
        }

        //Phương thức lấy dữ liệu từ bảng 
        public DataTable selectUserDetails()
        {
            db = new DBLib();
            try
            {
                return db.FillDataTable("sp_SelectUserDetails", CommandType.StoredProcedure);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public SqlDataReader selectUserDetailsByID(int IdUser)
        {
            db = new DBLib();
            try
            {
                db.AddParameter("@IdUser", IdUser);
                return db.ExecuteReader("sp_SelectUserDetailsByID", CommandType.StoredProcedure);
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Phương thức kiểm tra User
        public SqlDataReader CheckUser(string Username)
        {
            db = new DBLib();
            try
            {
                db.AddParameter("@Username", Username);
                return db.ExecuteReader("sp_CheckUser", CommandType.StoredProcedure);
            }
            catch (Exception)
            {

                throw;
            }
        }

        //Phương thức cập nhật dữ liệu bảng 
        public bool UpdateUser(UsersDTO dto)
        {
            int count = 0;
            try
            {
                db = new DBLib();
                db.AddParameter("@IdUser", dto.Id);
                db.AddParameter("@Fullname", dto.Fullname);
                db.AddParameter("@Password", func.pHash(dto.Password));
                db.AddParameter("@IdPermission", dto.IdPermission);
                count = db.ExecuteNonQuery("sp_UpdateUser", CommandType.StoredProcedure);
            }
            catch (Exception)
            {

                throw;
            }
            return count > 0;
        }

        //Phương thức xóa dữ liệu bảng 
        public bool DeleteUser(int IdUser)
        {
            int count = 0;
            try
            {
                db = new DBLib();
                db.AddParameter("@IdUser", IdUser);
                count = db.ExecuteNonQuery("sp_DeleteUser", CommandType.StoredProcedure);
            }
            catch (Exception)
            {

                throw;
            }
            return count > 0;
        }

    }
}
