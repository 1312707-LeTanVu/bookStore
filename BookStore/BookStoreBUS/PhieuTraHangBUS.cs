using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using BookStoreDAO;

namespace BookStoreBUS
{
    public class PhieuTraHangBUS
    {
        private PhieuTraHangDAO data = new PhieuTraHangDAO();
        public List<PhieuTraHang> GetList()
        {
            return data.GetList();
        }

        public void Insert(PhieuTraHang info)
        {
            data.Insert(info);
        }

        public void Delete(string code)
        {
            data.Delete(code);
        }

        public void Update(PhieuTraHang info)
        {
            data.Update(info);
        }
    }
}
