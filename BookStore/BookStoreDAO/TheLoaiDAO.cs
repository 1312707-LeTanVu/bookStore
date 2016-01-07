using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;

namespace BookStoreDAO
{
    public class TheLoaiDAO:DataProvider
    {
        public List<TheLoai> GetList()
        {
            List<TheLoai> list = new List<TheLoai>();

            string sqlQuery = "select * from TheLoai";

            reader = ExecuteReader(sqlQuery);

            while (reader.Read())
            {
                TheLoai tacGia = new TheLoai();

                tacGia.MaTheLoai = reader["MaTheLoai"].ToString();
                tacGia.TenTheLoai = reader["TenTheLoai"].ToString();
                tacGia.GhiChu = reader["GhiChu"].ToString();

                list.Add(tacGia);
            }

            return list;
        }

        public void Insert(TheLoai info)
        {
            string sqlQuery = "insert into TheLoai values ('" +
                info.MaTheLoai + "','" +
                info.TenTheLoai + "','" +
                info.GhiChu + "')";

            ExecuteNonQuery(sqlQuery);
        }

        public void Delete(string code)
        {
            string sqlQuery = "delete from TheLoai where MaTheLoai= '" + code + "'";
            ExecuteNonQuery(sqlQuery);
        }

        public void Update(TheLoai info)
        {
            string sqlQuery = "update TheLoai" +
                              " set TenTheLoai='" + info.TenTheLoai + "', " +
                              "GhiChu='" + info.GhiChu + "' " +
                              "where MaTheLoai='" + info.MaTheLoai + "'";

            ExecuteNonQuery(sqlQuery);
        }
    }
}
