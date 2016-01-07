using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
namespace BookStoreDAO
{
    public class PhieuThuTienDAO:DataProvider
    {
        public List<PhieuThuTien> GetList()
        {
            List<PhieuThuTien> list = new List<PhieuThuTien>();

            string sqlQuery = "select * from PhieuThuTien";

            reader = ExecuteReader(sqlQuery);

            while (reader.Read())
            {
                PhieuThuTien phieuThuTien = new PhieuThuTien();

                phieuThuTien.MaPTT = reader["MaPTT"].ToString();              
                phieuThuTien.MaHD = reader["MaHD"].ToString();
                phieuThuTien.NgayThuTien = (DateTime)reader["NgayThuTien"];
                phieuThuTien.SoTienThu = (double)reader["SoTienThu"];
                
                list.Add(phieuThuTien);
            }

            return list;
        }

        public void Insert(PhieuThuTien info)
        {
            string sqlQuery = "insert into PhieuThuTien values ('" +
                info.MaPTT + "','" +               
                info.MaHD + "','" +
                info.NgayThuTien.ToShortDateString() + "'," +
                info.SoTienThu + ")";

            ExecuteNonQuery(sqlQuery);
        }

        public void Delete(string code)
        {
            string sqlQuery = "delete from PhieuThuTien where MaPTT= '" + code + "'";
            ExecuteNonQuery(sqlQuery);
        }

        public void Update(PhieuThuTien info)
        {
            string sqlQuery = "update PhieuThuTien" +
                              " set MaPTT='" + info.MaPTT+ "'," +
                              "MaHD='" + info.MaHD + "'" +
                              "NgayThuTien='" + info.NgayThuTien + "'" +
                              "SoTienThu="+info.SoTienThu+
                              "where MaPTT='" + info.MaPTT + "'";

            ExecuteNonQuery(sqlQuery);
        }
    }
}
