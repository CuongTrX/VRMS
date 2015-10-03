using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VRMS.App_Code.DAL;
using VRMS.App_Code.DTO;

namespace VRMS.App_Code.BLL
{
    public class PhuongTienBLL
    {
        public PhuongTienBLL() { }

        PhuongTienDAL dalPhuongTien;
        //Create
        public object insertPhuongTien(PhuongTienDTO dtoPhuongTien)
        {
            dalPhuongTien = new PhuongTienDAL();
            try
            {
                return dalPhuongTien.insertPhuongTien(dtoPhuongTien);
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
            dalPhuongTien = new PhuongTienDAL();
            try
            {
                return dalPhuongTien.deletePhuongTien(MaPT);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
