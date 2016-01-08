using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class HoaDon
    {
        private string maHD;

        public string MaHD
        {
            get { return maHD; }
            set { maHD = value; }
        }
        private string tenKH;

        public string TenKH
        {
            get { return tenKH; }
            set { tenKH = value; }
        }

        private DateTime ngayLapHD;

        public DateTime NgayLapHD
        {
            get { return ngayLapHD; }
            set { ngayLapHD = value; }
        }
    }
}
