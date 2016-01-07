using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using BookStoreDAO;

namespace BookStoreBUS
{
    public class NhanVienBUS
    {
        private NhanVienDAO data = new NhanVienDAO();
        public List<NhanVien> GetList()
        {
            return data.GetList();
        }

        public void Insert(NhanVien info)
        {
            data.Insert(info);
        }

        public void Delete(string code)
        {
            data.Delete(code);
        }

        public void Update(NhanVien info)
        {
            data.Update(info);
        }
    }
}
