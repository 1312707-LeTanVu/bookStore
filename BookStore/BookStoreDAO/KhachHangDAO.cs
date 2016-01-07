using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;

namespace BookStoreDAO
{
    public class KhachHangDAO:DataProvider
    {
        public List<KhachHang> GetList()
        {
            List<KhachHang> list = new List<KhachHang>();

            string sqlQuery = "select * from KhachHang";

            reader = ExecuteReader(sqlQuery);

            while (reader.Read())
            {
                KhachHang khachHang = new KhachHang();

                khachHang.MaKH = reader["MaKH"].ToString();
                khachHang.TenKH = reader["TenKH"].ToString();
                khachHang.DiaChiKH = reader["DiaChiKH"].ToString();
                khachHang.SoDienThoai = reader["SoDienThoai"].ToString();
                khachHang.Email = reader["Email"].ToString();

                list.Add(khachHang);
            }

            return list;
        }

        public void Insert(KhachHang info)
        {
            string sqlQuery = "insert into KhachHang values ('" +
                info.MaKH + "','" +
                info.TenKH + "','" +
                info.DiaChiKH + "','" +
                info.SoDienThoai + "','" +
                info.Email + "')";

            ExecuteNonQuery(sqlQuery);
        }

        public void Delete(string code)
        {
            string sqlQuery = "delete from KhachHang where MaKH= '" + code + "'";
            ExecuteNonQuery(sqlQuery);
        }

        public void Update(KhachHang info)
        {
            string sqlQuery = "update KhachHang" +
                              " set TenKH='" + info.TenKH + "'," +
                              "DiaChiKH='" + info.DiaChiKH + "'" +
                              "SoDienThoai='"+info.SoDienThoai+"'"+
                              "Email='"+info.Email+"'"+
                              "where MaKH='" + info.MaKH + "'";

            ExecuteNonQuery(sqlQuery);
        }
    }
}
