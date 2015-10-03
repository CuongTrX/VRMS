using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VRMS.App_Code.DAL;
using VRMS.App_Code.DTO;

namespace VRMS.App_Code.BLL
{
    public class HoSoBLL
    {
        public HoSoBLL() { }

        HoSoDAL dalHoSo;
        //Create
        public object insertHoSo(HoSoDTO dtoHoSo)
        {
            dalHoSo = new HoSoDAL();
            try
            {
                return dalHoSo.insertHoSo(dtoHoSo);
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
