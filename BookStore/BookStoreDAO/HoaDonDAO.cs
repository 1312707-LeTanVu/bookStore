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
                hoaDon.TenKH = reader["TenKH"].ToString();             
                hoaDon.NgayLapHD = (DateTime)reader["NgayLapHD"];

                list.Add(hoaDon);
            }

            return list;
        }

        public void Insert(HoaDon info)
        {
            string date = info.NgayLapHD.Month + "/" + info.NgayLapHD.Day + "/" + info.NgayLapHD.Year;
            string sqlQuery = "insert into HoaDon values ('" +
                info.MaHD + "',N'" +
                info.TenKH + "','" +            
                date + "')";
           
            ExecuteNonQuery(sqlQuery);
        }

        public void Delete(string code)
        {
            string sqlQuery = "delete from HoaDon where MaHD= '" + code + "'";
            ExecuteNonQuery(sqlQuery);
        }

        public void Update(HoaDon info)
        {
            string date = info.NgayLapHD.Month + "/" + info.NgayLapHD.Day + "/" + info.NgayLapHD.Year;
            string sqlQuery = "update HoaDon" +
                              " set TenKH=N'" + info.TenKH + "'," +                            
                              "NgayLapHD='"+date+"'"+
                              "where MaHD='" + info.MaHD + "'";

            ExecuteNonQuery(sqlQuery);
        }
    }
}
