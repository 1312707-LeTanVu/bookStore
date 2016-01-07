using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;

namespace BookStoreDAO
{
    public class SachDAO:DataProvider
    {
        public List<Sach> GetList()
        {
            List<Sach> list = new List<Sach>();

            string sqlQuery = "select * from Sach";

            reader = ExecuteReader(sqlQuery);

            while (reader.Read())
            {
                Sach sach = new Sach();

                sach.MaSach = reader["MaSach"].ToString();
                sach.TenSach = reader["TenSach"].ToString();
                sach.TheLoai = reader["TheLoai"].ToString();
                sach.TacGia = reader["TacGia"].ToString();
                sach.NhaXuatBan = reader["NhaXuatBan"].ToString();
                sach.NamXuatBan = (int)reader["NamXuatBan"];
                sach.GiaBan = (double)reader["GiaBan"];
                sach.SoLuong = (int)reader["SoLuong"];
                list.Add(sach);
            }

            return list;
        }

        public void Insert(Sach info)
        {
            string sqlQuery = "insert into Sach values ('" +
                info.MaSach + "',N'" +
                info.TenSach + "','" +
                info.TheLoai + "','" +
                info.TacGia + "','" +
                info.NhaXuatBan + "'," +
                info.NamXuatBan + "," +
                info.GiaBan + "," +
                info.SoLuong + ")";

            ExecuteNonQuery(sqlQuery);
        }

        public void Delete(string code)
        {
            string sqlQuery = "delete from Sach where MaSach= '" + code + "'";
            ExecuteNonQuery(sqlQuery);
        }

        public void Update(Sach info)
        {
            string sqlQuery = "update Sach" +
                              " set TenSach='" + info.TenSach + "'," +
                              "TheLoai='" + info.TheLoai + "'" +
                              "TacGia='" + info.TacGia + "'" +
                              "NhaXuatBan='" + info.NhaXuatBan + "'" +
                              "NamXuatBan=" + info.NamXuatBan +
                              "GiaBan=" + info.GiaBan +
                              "SoLuong=" + info.SoLuong +
                              "where MaSach='" + info.MaSach + "'";

            ExecuteNonQuery(sqlQuery);
        }
    }
}
