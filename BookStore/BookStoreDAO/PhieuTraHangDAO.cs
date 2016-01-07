using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;

namespace BookStoreDAO
{
    public class PhieuTraHangDAO:DataProvider
    {
        public List<PhieuTraHang> GetList()
        {
            List<PhieuTraHang> list = new List<PhieuTraHang>();

            string sqlQuery = "select * from PhieuTraHang";

            reader = ExecuteReader(sqlQuery);
           
            while (reader.Read())
            {
                PhieuTraHang phieuTraHang = new PhieuTraHang();

                phieuTraHang.MaTH = reader["MaTH"].ToString();
                phieuTraHang.MaSach = reader["MaSach"].ToString();
                phieuTraHang.MaKH = reader["MaKH"].ToString();
                phieuTraHang.LyDoTra = reader["LyDoTra"].ToString();
            
                list.Add(phieuTraHang);
            }

            return list;
        }

        public void Insert(PhieuTraHang info)
        {
            string sqlQuery = "insert into PhieuTraHang values ('" +
                info.MaKH + "','" +
                info.MaSach + "','" +
                info.MaKH + "',N'" +
                info.LyDoTra + "')";

            ExecuteNonQuery(sqlQuery);
        }

        public void Delete(string code)
        {
            string sqlQuery = "delete from PhieuTraHang where MaTH= '" + code + "'";
            ExecuteNonQuery(sqlQuery);
        }

        public void Update(PhieuTraHang info)
        {
            string sqlQuery = "update PhieuTraHang" +
                              " set MaSach='" + info.MaSach + "'," +
                              "MaKH='" + info.MaKH + "'" +
                              "LyDoTra='" + info.LyDoTra + "'" +
                              "where MaTH='" + info.MaTH + "'";

            ExecuteNonQuery(sqlQuery);
        }
    }
}
