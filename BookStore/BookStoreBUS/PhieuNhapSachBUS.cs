using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using BookStoreDAO;

namespace BookStoreBUS
{
    public class PhieuNhapSachBUS
    {
        private PhieuNhapSachDAO data = new PhieuNhapSachDAO();
        public List<PhieuNhapSach> GetList()
        {
            return data.GetList();
        }

        public void Insert(PhieuNhapSach info)
        {
            data.Insert(info);
        }

        public void Delete(string code)
        {
            data.Delete(code);
        }

        public void Update(PhieuNhapSach info)
        {
            data.Update(info);
        }
    }
}
