using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;

namespace BookStoreDAO
{
    public class PhieuNhapSachDAO:DataProvider
    {
        public List<PhieuNhapSach> GetList()
        {
            List<PhieuNhapSach> list = new List<PhieuNhapSach>();

            string sqlQuery = "select * from PhieuNhapSach";

            reader = ExecuteReader(sqlQuery);

            while (reader.Read())
            {
                PhieuNhapSach phieuNhapSach = new PhieuNhapSach();

                phieuNhapSach.MaPN = reader["MaPN"].ToString();
                phieuNhapSach.MaSach = reader["MaSach"].ToString();
                phieuNhapSach.MaNCC = reader["MaNCC"].ToString();
                phieuNhapSach.SoLuong = (int)reader["SoLuong"];
                phieuNhapSach.NgayNhap = (DateTime)reader["NgayNhap"];
                list.Add(phieuNhapSach);
            }

            return list;
        }

        public void Insert(PhieuNhapSach info)
        {
            string sqlQuery = "insert into PhieuNhapSach values ('" +
                info.MaPN + "','" +
                info.MaSach + "','" +
                info.MaNCC + "'," +
                info.SoLuong + ",'" +
                info.NgayNhap.ToShortDateString() + "')";

            ExecuteNonQuery(sqlQuery);
        }

        public void Delete(string code)
        {
            string sqlQuery = "delete from PhieuNhapSach where MaPN= '" + code + "'";
            ExecuteNonQuery(sqlQuery);
        }

        public void Update(PhieuNhapSach info)
        {
            string sqlQuery = "update PhieuNhapSach" +
                              " set MaSach='" + info.MaSach + "'," +
                              "MaNCC='" + info.MaNCC + "'" +
                              "SoLuong=" + info.SoLuong +
                              "NgayNhap='" + info.NgayNhap.ToShortDateString() + "'"+
                              "where MaPN='" + info.MaPN + "'";

            ExecuteNonQuery(sqlQuery);
        }
    }
}
