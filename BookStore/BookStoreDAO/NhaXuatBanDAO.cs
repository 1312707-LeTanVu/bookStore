using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;

namespace BookStoreDAO
{
    public class NhaXuatBanDAO:DataProvider
    {
        public List<NhaXuatBan> GetList()
        {
            List<NhaXuatBan> list = new List<NhaXuatBan>();

            string sqlQuery = "select * from NhaXuatBan";

            reader = ExecuteReader(sqlQuery);

            while (reader.Read())
            {
                NhaXuatBan nhaXuatBan = new NhaXuatBan();

                nhaXuatBan.MaNXB = reader["MaNXB"].ToString();
                nhaXuatBan.TenNXB = reader["TenNXB"].ToString();
                nhaXuatBan.DiaChiNXB = reader["DiaChiNXB"].ToString();
                nhaXuatBan.SoDienThoai = reader["SoDienThoai"].ToString();
              
                list.Add(nhaXuatBan);
            }

            return list;
        }

        public void Insert(NhaXuatBan info)
        {
            string sqlQuery = "insert into NhaXuatBan values ('" +
                info.MaNXB + "',N'" +
                info.TenNXB + "',N'" +
                info.DiaChiNXB + "','" +
                info.SoDienThoai + "')";

            ExecuteNonQuery(sqlQuery);
        }

        public void Delete(string code)
        {
            string sqlQuery = "delete from NhaXuatBan where MaNXB= '" + code + "'";
            ExecuteNonQuery(sqlQuery);
        }

        public void Update(NhaXuatBan info)
        {
            string sqlQuery = "update NhaXuatBan" +
                              " set TenNXB=N'" + info.TenNXB + "'," +
                              "DiaChiNXB=N'" + info.DiaChiNXB + "'," +
                              "SoDienThoai='" + info.SoDienThoai + "'" +
                              "where MaNXB='" + info.MaNXB + "'";

            ExecuteNonQuery(sqlQuery);
        }
    }
}
