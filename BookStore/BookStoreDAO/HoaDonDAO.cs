using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;

namespace BookStoreDAO
{
    public class HoaDonDAO:DataProvider
    {
        public List<HoaDon> GetList()
        {
            List<HoaDon> list = new List<HoaDon>();

            string sqlQuery = "select * from HoaDon";

            reader = ExecuteReader(sqlQuery);

            while (reader.Read())
            {
                HoaDon hoaDon = new HoaDon();

                hoaDon.MaHD = reader["MaHD"].ToString();
                hoaDon.MaKH = reader["MaKH"].ToString();
                hoaDon.MaNV = reader["MaNV"].ToString();
                hoaDon.NgayLapHD = (DateTime)reader["NgayLapHD"];

                list.Add(hoaDon);
            }

            return list;
        }

        public void Insert(HoaDon info)
        {
            string sqlQuery = "insert into HoaDon values ('" +
                info.MaHD + "','" +
                info.MaKH + "','" +
                info.MaNV + "','" +
                info.NgayLapHD.ToShortDateString() + "')";

            ExecuteNonQuery(sqlQuery);
        }

        public void Delete(string code)
        {
            string sqlQuery = "delete from HoaDon where MaHD= '" + code + "'";
            ExecuteNonQuery(sqlQuery);
        }

        public void Update(HoaDon info)
        {
            string sqlQuery = "update HoaDon" +
                              " set MaKH='" + info.MaKH + "'," +
                              "MaNV='" + info.MaNV + "'" +
                              "NgayLapHD='"+info.NgayLapHD.ToShortDateString()+"'"+
                              "where MaHD='" + info.MaHD + "'";

            ExecuteNonQuery(sqlQuery);
        }
    }
}
