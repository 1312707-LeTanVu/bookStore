using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;

namespace BookStoreDAO
{
    public class ChiTietHoaDonDAO : DataProvider
    {
        public List<ChiTietHoaDon> GetList()
        {
            List<ChiTietHoaDon> list = new List<ChiTietHoaDon>();

            string sqlQuery = "select * from ChiTietHoaDon";

            reader = ExecuteReader(sqlQuery);

            while(reader.Read())
            {
                ChiTietHoaDon chiTietHoaDon = new ChiTietHoaDon();

                chiTietHoaDon.MaHD = reader["MaHD"].ToString();
                chiTietHoaDon.MaSach = reader["MaSach"].ToString();
                chiTietHoaDon.SoLuong = (int) reader["SoLuong"];
                chiTietHoaDon.MaCTHD = reader["MaCTHD"].ToString();
                list.Add(chiTietHoaDon);
            }

            return list;
        }

        public void Insert(ChiTietHoaDon info)
        {
            string sqlQuery = "insert into ChiTietHoaDon values('" +
                info.MaHD + "', '" +
                info.MaSach + "' , '" +
                info.SoLuong + "','" +
                info.MaCTHD + "')";

            ExecuteNonQuery(sqlQuery);
        }

        public void Delete(string code)
        {
            string sqlQuery = "delete from ChiTietHoaDon where MaCTHD='" + code + "'";
            ExecuteNonQuery(sqlQuery);
        }

        public void Update(ChiTietHoaDon info)
        {
            string sqlQuery = "update ChiTietHoaDon" +
                              " set MaSach='" + info.MaSach + "'," +
                              "SoLuong=" + info.SoLuong +
                              "where MaCTHD='" + info.MaCTHD + "'";

            ExecuteNonQuery(sqlQuery);
        }
    }
}
