using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VRMS.App_Code.DTO
{
    public class PhuongTienDTO
    {
        public PhuongTienDTO()
        {

        }
        
        public int MaPT { get; set; }
        public int MaChuPT { get; set; }
        public string BienSo { get; set; }
        public DateTime NgayDangKyLanDau { get; set; }
        public string NhanHieu { get; set; }
        public string LoaiXe { get; set; }
        public string MauSon { get; set; }
        public string SoKhung { get; set; }
        public string SoMay { get; set; }
        public int DungTichXiLanh { get; set; }
        public int SoChoNgoi { get; set; }
    }
}
