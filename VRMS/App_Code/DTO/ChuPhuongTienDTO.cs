using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VRMS.App_Code.DTO
{
    public class ChuPhuongTienDTO
    {
        public ChuPhuongTienDTO() { }
        public int MaChuPT { get; set; }
        public string HoDem { get; set; }
        public string Ten { get; set; }
        public string NoiThuongTru { get; set; }
        public string DienThoai { get; set; }
        public string SoCMND { get; set; }
        public DateTime NgayCap { get; set; }
    }
}
