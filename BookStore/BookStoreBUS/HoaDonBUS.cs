using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using BookStoreDAO;

namespace BookStoreBUS
{
    public class HoaDonBUS
    {
        private HoaDonDAO data = new HoaDonDAO();
        public List<HoaDon> GetList()
        {
            return data.GetList();
        }

        public void Insert(HoaDon info)
        {
            data.Insert(info);
        }

        public void Delete(string code)
        {
            data.Delete(code);
        }

        public void Update(HoaDon info)
        {
            data.Update(info);
        }
    }
}
