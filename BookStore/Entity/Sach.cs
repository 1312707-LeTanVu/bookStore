using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Sach
    {
        private string maSach;

        public string MaSach
        {
            get { return maSach; }
            set { maSach = value; }
        }
        private string tenSach;

        public string TenSach
        {
            get { return tenSach; }
            set { tenSach = value; }
        }
        private string theLoai;

        public string TheLoai
        {
            get { return theLoai; }
            set { theLoai = value; }
        }
        private string tacGia;

        public string TacGia
        {
            get { return tacGia; }
            set { tacGia = value; }
        }
        private string nhaXuatBan;

        public string NhaXuatBan
        {
            get { return nhaXuatBan; }
            set { nhaXuatBan = value; }
        }
        private int namXuatBan;

        public int NamXuatBan
        {
            get { return namXuatBan; }
            set { namXuatBan = value; }
        }
        private double giaBan;//  trong database la kieu money

        public double GiaBan
        {
            get { return giaBan; }
            set { giaBan = value; }
        }

        private int soLuong;

        public int SoLuong
        {
            get { return soLuong; }
            set { soLuong = value; }
        }

    }
}
