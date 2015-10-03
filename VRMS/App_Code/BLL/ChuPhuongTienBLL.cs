using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using VRMS.App_Code.DAL;
using VRMS.App_Code.DTO;

namespace VRMS.App_Code.BLL
{
    public class ChuPhuongTienBLL
    {
        public ChuPhuongTienBLL() { }

        ChuPhuongTienDAL dalChuPhuongTien;
        //Create
        public object insertChuPhuongTien(ChuPhuongTienDTO dtoChuPhuongTien)
        {
            dalChuPhuongTien = new ChuPhuongTienDAL();
            try
            {
                return dalChuPhuongTien.insertChuPhuongTien(dtoChuPhuongTien);
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
            dalChuPhuongTien = new ChuPhuongTienDAL();
            try
            {
                return dalChuPhuongTien.deleteChuPhuongTien(MaChuPT);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
