using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using BookStoreDAO;

namespace BookStoreBUS
{
    public class PhieuThuTienBUS
    {
        private PhieuThuTienDAO data = new PhieuThuTienDAO();
        public List<PhieuThuTien> GetList()
        {
            return data.GetList();
        }

        public void Insert(PhieuThuTien info)
        {
            data.Insert(info);
        }

        public void Delete(string code)
        {
            data.Delete(code);
        }

        public void Update(PhieuThuTien info)
        {
            data.Update(info);
        }
    }
}
