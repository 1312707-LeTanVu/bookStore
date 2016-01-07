using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStoreDAO;
using Entity;

namespace BookStoreBUS
{
    public class ChiTietHoaDonBUS
    {
        private ChiTietHoaDonDAO data = new ChiTietHoaDonDAO();

        public List<ChiTietHoaDon> GetList()
        {
            return data.GetList();
        }

        public void Insert(ChiTietHoaDon info)
        {
            data.Insert(info);
        }

        public void Delete(string code)
        {
            data.Delete(code);
        }

        public void Update(ChiTietHoaDon info)
        {
            data.Update(info);
        }
    }
}
