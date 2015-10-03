using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VRMS.App_Code.DTO
{
    public class HoSoDTO
    {
        public HoSoDTO()
        {

        }

        public int MaHoSo { get; set; }
        public int MaPT { get; set; }
        public int MaChuPT { get; set; }
        public int MaChuCuPT { get; set; }
        public string GhiChu { get; set; }
    }
}
