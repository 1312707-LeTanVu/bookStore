using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;

namespace BookStoreDAO
{
    public class TacGiaDAO:DataProvider
    {
        public List<TacGia> GetList()
        {
            List<TacGia> list = new List<TacGia>();

            string sqlQuery = "select * from TacGia";

            reader = ExecuteReader(sqlQuery);

            while (reader.Read())
            {
                TacGia tacGia = new TacGia();

                tacGia.MaTG = reader["MaTG"].ToString();
                tacGia.TenTG = reader["TenTG"].ToString();
     
                list.Add(tacGia);
            }

            return list;
        }

        public void Insert(TacGia info)
        {
            string sqlQuery = "insert into TacGia values ('" +
                info.MaTG + "','" +
                info.TenTG + "')";

            ExecuteNonQuery(sqlQuery);
        }

        public void Delete(string code)
        {
            string sqlQuery = "delete from TacGia where MaTG= '" + code + "'";
            ExecuteNonQuery(sqlQuery);
        }

        public void Update(TacGia info)
        {
            string sqlQuery = "update TacGia" +
                              " set TenTG='" + info.TenTG + "'" +
                              "where MaTG='" + info.MaTG + "'";

            ExecuteNonQuery(sqlQuery);
        }
    }
}
