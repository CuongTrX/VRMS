using System;
using System.Data;
using VRMS.App_Code.DTO;

namespace VRMS.App_Code.DAL
{
    public class ChuPhuongTienDAL
    {
        DBLib db;
        public ChuPhuongTienDAL() { }

        //Create
        public object insertChuPhuongTien(ChuPhuongTienDTO dtoChuPhuongTien)
        {
            db = new DBLib();
            try
            {
                db.AddParameter("@HoDem", dtoChuPhuongTien.HoDem);
                db.AddParameter("@Ten", dtoChuPhuongTien.Ten);
                db.AddParameter("@NoiThuongTru", dtoChuPhuongTien.NoiThuongTru);
                db.AddParameter("@DienThoai", dtoChuPhuongTien.DienThoai);
                db.AddParameter("@SoCMND", dtoChuPhuongTien.SoCMND);
                db.AddParameter("@NgayCap", dtoChuPhuongTien.NgayCap);
                return db.ExecuteScalar("sp_InsertChuPhuongTien", CommandType.StoredProcedure);
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Read
        //Update
        //Delete
        public bool deleteChuPhuongTien(int MaChuPT)
        {
            db = new DBLib();
            try
            {
                db.AddParameter("@MaChuPT", MaChuPT);
                return db.ExecuteNonQuery("sp_DeleteChuPhuongTien", CommandType.StoredProcedure) > 0;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
