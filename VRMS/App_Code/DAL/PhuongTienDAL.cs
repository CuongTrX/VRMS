using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using VRMS.App_Code.DTO;

namespace VRMS.App_Code.DAL
{
    public class PhuongTienDAL
    {
        public PhuongTienDAL() { }

        DBLib db;
        //Create
        public object insertPhuongTien(PhuongTienDTO dtoPhuongTien)
        {
            db = new DBLib();
            try
            {
                db.AddParameter("@MaChuPT", dtoPhuongTien.MaChuPT);
                db.AddParameter("@BienSo", dtoPhuongTien.BienSo);
                db.AddParameter("@NgayDangKyLanDau", dtoPhuongTien.NgayDangKyLanDau);
                db.AddParameter("@NhanHieu", dtoPhuongTien.NhanHieu);
                db.AddParameter("@LoaiXe", dtoPhuongTien.LoaiXe);
                db.AddParameter("@MauSon", dtoPhuongTien.MauSon);
                db.AddParameter("@SoKhung", dtoPhuongTien.SoKhung);
                db.AddParameter("@SoMay", dtoPhuongTien.SoMay);
                db.AddParameter("@DungTichXiLanh", dtoPhuongTien.DungTichXiLanh);
                db.AddParameter("@SoChoNgoi", dtoPhuongTien.SoChoNgoi);
                return db.ExecuteScalar("sp_InsertPhuongTien", CommandType.StoredProcedure);
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Read
        //Update
        //Delete
        public bool deletePhuongTien(int MaPT)
        {
            db = new DBLib();
            try
            {
                db.AddParameter("@MaPT", MaPT);
                return db.ExecuteNonQuery("sp_DeletePhuongTien", CommandType.StoredProcedure) > 0;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
