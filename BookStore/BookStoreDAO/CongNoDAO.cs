using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;

namespace BookStoreDAO
{
    public class CongNoDAO:DataProvider
    {
        public List<CongNo> GetList()
        {
            List<CongNo> list = new List<CongNo>();

            string sqlQuery = "select * from CongNo";

            reader = ExecuteReader(sqlQuery);

            while (reader.Read())
            {
                CongNo congNo = new CongNo();

                congNo.MaCN = reader["MaCN"].ToString();
                congNo.MaKH = reader["MaKH"].ToString();
                congNo.ThoiGian = (DateTime)reader["ThoiGian"];
                congNo.SoTien = (double)reader["SoTien"];
                congNo.DaTra = (double)reader["DaTra"];

                list.Add(congNo);
            }

            return list;
        }

        public void Insert(CongNo info)
        {
            string sqlQuery = "insert into CongNo values ('" +
                info.MaCN + "','" +
                info.MaKH + "','" +
                info.ThoiGian.ToShortDateString() + "',"+
                info.SoTien+","+
                info.DaTra + ")";
              
            ExecuteNonQuery(sqlQuery);
        }

        public void Delete(string code)
        {
            string sqlQuery = "delete from CongNo where MaCN= '" + code + "'";
            ExecuteNonQuery(sqlQuery);
        }

        public void Update(CongNo info)
        {
            string sqlQuery = "update CongNo" +
                              " set MaKH='" + info.MaKH + "'," +
                              "ThoiGian='" + info.ThoiGian.ToShortDateString() + "'" +
                              "SoTien="+info.SoTien+
                              "DaTra="+info.DaTra+
                              "where MaCN='" + info.MaCN + "'";

            ExecuteNonQuery(sqlQuery);
        }
    }
}
