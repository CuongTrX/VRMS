using System;
using System.Data;
using VRMS.App_Code.DTO;

namespace VRMS.App_Code.DAL
{
    public class HoSoDAL
    {
        DBLib db;
        public HoSoDAL() { }

        //Create
        public object insertHoSo(HoSoDTO dtoHoSo)
        {
            db = new DBLib();
            try
            {
                db.AddParameter("@MaPT", dtoHoSo.MaPT);
                db.AddParameter("@MaChuPT", dtoHoSo.MaChuPT);
                db.AddParameter("@MaChuCuPT", dtoHoSo.MaChuCuPT);
                db.AddParameter("@GhiChu", dtoHoSo.GhiChu);
                return db.ExecuteScalar("sp_InsertHoSo", CommandType.StoredProcedure);
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Read
        //Update
        //Delete
    }
}
