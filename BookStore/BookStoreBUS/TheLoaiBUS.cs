using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using BookStoreDAO;

namespace BookStoreBUS
{
    public class TheLoaiBUS
    {
        private TheLoaiDAO data = new TheLoaiDAO();
        public List<TheLoai> GetList()
        {
            return data.GetList();
        }

        public void Insert(TheLoai info)
        {
            data.Insert(info);
        }

        public void Delete(string code)
        {
            data.Delete(code);
        }

        public void Update(TheLoai info)
        {
            data.Update(info);
        }
    }
}
