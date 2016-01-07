using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;

namespace BookStoreDAO
{
    public class TaiKhoanDAO:DataProvider
    {
        public List<TaiKhoan> GetList()
        {
            List<TaiKhoan> list = new List<TaiKhoan>();

            string sqlQuery = "select * from TaiKhoan";

            reader = ExecuteReader(sqlQuery);

            while (reader.Read())
            {
                TaiKhoan tacGia = new TaiKhoan();

                tacGia.MatKhau = reader["MatKhau"].ToString();
                tacGia.TenDangNhap = reader["TenDangNhap"].ToString();

                list.Add(tacGia);
            }

            return list;
        }

        public void Insert(TaiKhoan info)
        {
            string sqlQuery = "insert into TaiKhoan values ('" +
                info.TenDangNhap + "','" +             
                info.MatKhau + "')";

            ExecuteNonQuery(sqlQuery);
        }

        public void Delete(string code)
        {
            string sqlQuery = "delete from TaiKhoan where TenDangNhap= '" + code + "'";
            ExecuteNonQuery(sqlQuery);
        }

        public void Update(TaiKhoan info)
        {
            string sqlQuery = "update TaiKhoan" +
                              " set MatKhau='" + info.MatKhau + "'" +
                              "where TenDangNhap='" + info.TenDangNhap + "'";

            ExecuteNonQuery(sqlQuery);
        }
    }
}
