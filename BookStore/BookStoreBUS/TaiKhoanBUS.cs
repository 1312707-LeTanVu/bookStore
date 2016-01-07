using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using BookStoreDAO;

namespace BookStoreBUS
{
    public class TaiKhoanBUS
    {
        private TaiKhoanDAO data = new TaiKhoanDAO();
        public List<TaiKhoan> GetList()
        {
            return data.GetList();
        }

        public void Insert(TaiKhoan info)
        {
            data.Insert(info);
        }

        public void Delete(string code)
        {
            data.Delete(code);
        }

        public void Update(TaiKhoan info)
        {
            data.Update(info);
        }
    }
}
