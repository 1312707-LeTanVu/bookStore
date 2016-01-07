using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class CongNo
    {
        private string maCN;

        public string MaCN
        {
            get { return maCN; }
            set { maCN = value; }
        }
        private string maKH;

        public string MaKH
        {
            get { return maKH; }
            set { maKH = value; }
        }
        private DateTime thoiGian;

        public DateTime ThoiGian
        {
            get { return thoiGian; }
            set { thoiGian = value; }
        }
        private double soTien;

        public double SoTien
        {
            get { return soTien; }
            set { soTien = value; }
        }
        private double daTra;

        public double DaTra
        {
            get { return daTra; }
            set { daTra = value; }
        }
    }
}
