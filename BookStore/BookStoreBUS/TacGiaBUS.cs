using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using BookStoreDAO;

namespace BookStoreBUS
{
    public class TacGiaBUS
    {
        private TacGiaDAO data = new TacGiaDAO();
        public List<TacGia> GetList()
        {
            return data.GetList();
        }

        public void Insert(TacGia info)
        {
            data.Insert(info);
        }

        public void Delete(string code)
        {
            data.Delete(code);
        }

        public void Update(TacGia info)
        {
            data.Update(info);
        }
    }
}
