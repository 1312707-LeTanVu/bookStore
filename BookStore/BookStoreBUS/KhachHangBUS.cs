using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using BookStoreDAO;

namespace BookStoreBUS
{
    public class KhachHangBUS
    {
        private KhachHangDAO data = new KhachHangDAO();
        public List<KhachHang> GetList()
        {
            return data.GetList();
        }

        public void Insert(KhachHang info)
        {
            data.Insert(info);
        }

        public void Delete(string code)
        {
            data.Delete(code);
        }

        public void Update(KhachHang info)
        {
            data.Update(info);
        }
    }
}
