using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class PhieuThuTien
    {
        private string maPTT;

        public string MaPTT
        {
            get { return maPTT; }
            set { maPTT = value; }
        }
       
        private string maHD;

        public string MaHD
        {
            get { return maHD; }
            set { maHD = value; }
        }
        private DateTime ngayThuTien;

        public DateTime NgayThuTien
        {
            get { return ngayThuTien; }
            set { ngayThuTien = value; }
        }
        private double soTienThu;// database kieu money

        public double SoTienThu
        {
            get { return soTienThu; }
            set { soTienThu = value; }
        }
    }
}
