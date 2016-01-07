using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;

namespace BookStoreDAO
{
    public class NhanVienDAO:DataProvider
    {
        public List<NhanVien> GetList()
        {
            List<NhanVien> list = new List<NhanVien>();

            string sqlQuery = "select * from NhanVien";

            reader = ExecuteReader(sqlQuery);

            while (reader.Read())
            {
                NhanVien nhanVien = new NhanVien();

                nhanVien.MaNV = reader["MaNV"].ToString();
                nhanVien.HoTen = reader["HoTen"].ToString();
                nhanVien.GioiTinh = reader["GioiTinh"].ToString();
                nhanVien.CMND = reader["CMND"].ToString();
                nhanVien.NgaySinh = (DateTime)reader["NgaySinh"];
                nhanVien.DiaChi = reader["DiaChi"].ToString();
                nhanVien.SDT = reader["SDT"].ToString();
                nhanVien.TaiKhoan = reader["TaiKhoan"].ToString();
          
                list.Add(nhanVien);
            }

            return list;
        }

        public void Insert(NhanVien info)
        {
            string sqlQuery = "insert into NhanVien values ('" +
                info.MaNV + "',N'" +
                info.HoTen + "',N'" +
                info.GioiTinh + "','" +
                info.CMND + "','" +
                info.NgaySinh.ToShortDateString() + "',N'" +
                info.DiaChi + "','" +
                info.SDT + "','" +
                info.TaiKhoan + "')";

            ExecuteNonQuery(sqlQuery);
        }

        public void Delete(string code)
        {
            string sqlQuery = "delete from NhanVien where MaNV= '" + code + "'";
            ExecuteNonQuery(sqlQuery);
        }

        public void Update(NhanVien info)
        {
            string sqlQuery = "update NhanVien" +
                              " set HoTen='" + info.HoTen + "'," +
                              "GioiTinh='" + info.GioiTinh + "'" +
                              "CMND='" + info.CMND + "'" +
                              "NgaySinh='" + info.NgaySinh.ToShortDateString() + "'" +
                              "DiaChi='" + info.DiaChi + "'" +
                              "SDT='" + info.SDT + "'" +
                              "TaiKhoan='" + info.TaiKhoan + "'" +
                              "where MaNV='" + info.MaNV + "'";

            ExecuteNonQuery(sqlQuery);
        }
    }
}
