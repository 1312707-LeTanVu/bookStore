using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class NhaXuatBan
    {
        private string maNXB;

        public string MaNXB
        {
            get { return maNXB; }
            set { maNXB = value; }
        }
        private string tenNXB;

        public string TenNXB
        {
            get { return tenNXB; }
            set { tenNXB = value; }
        }
        private string diaChiNXB;

        public string DiaChiNXB
        {
            get { return diaChiNXB; }
            set { diaChiNXB = value; }
        }
        private string soDienThoai;

        public string SoDienThoai
        {
            get { return soDienThoai; }
            set { soDienThoai = value; }
        }
    }
}
