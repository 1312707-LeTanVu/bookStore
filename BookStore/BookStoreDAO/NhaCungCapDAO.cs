using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;

namespace BookStoreDAO
{
    public class NhaCungCapDAO:DataProvider
    {
        public List<NhaCungCap> GetList()
        {
            List<NhaCungCap> list = new List<NhaCungCap>();

            string sqlQuery = "select * from NhaCungCap";

            reader = ExecuteReader(sqlQuery);

            while (reader.Read())
            {
                NhaCungCap nhaCungCap = new NhaCungCap();

                nhaCungCap.MaNCC = reader["MaNCC"].ToString();
                nhaCungCap.TenNCC = reader["TenNCC"].ToString();
                nhaCungCap.DiaChiNCC = reader["DiaChiNCC"].ToString();
                nhaCungCap.DienThoai = reader["DienThoai"].ToString();

                list.Add(nhaCungCap);
            }

            return list;
        }

        public void Insert(NhaCungCap info)
        {
            string sqlQuery = "insert into NhaCungCap values ('" +
                info.MaNCC + "',N'" +
                info.TenNCC + "',N'" +
                info.DiaChiNCC + "'," +
                info.DienThoai + ")";

            ExecuteNonQuery(sqlQuery);
        }

        public void Delete(string code)
        {
            string sqlQuery = "delete from NhaCungCap where MaNCC= '" + code + "'";
            ExecuteNonQuery(sqlQuery);
        }

        public void Update(NhaCungCap info)
        {
            string sqlQuery = "update NhaCungCap" +
                              " set TenNCC=N'" + info.TenNCC + "'," +
                              "DiaChiNCC=N'" + info.DiaChiNCC + "'," +
                              "DienThoai='"+info.DienThoai+"'"+
                              "where MaNCC='" + info.MaNCC + "'";

            ExecuteNonQuery(sqlQuery);
        }
    }
}
