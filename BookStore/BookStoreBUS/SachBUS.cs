using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using BookStoreDAO;

namespace BookStoreBUS
{
    public class SachBUS
    {
        private SachDAO data = new SachDAO();
        public List<Sach> GetList()
        {
            return data.GetList();
        }

        public void Insert(Sach info)
        {
            data.Insert(info);
        }

        public void Delete(string code)
        {
            data.Delete(code);
        }

        public void Update(Sach info)
        {
            data.Update(info);
        }
    }
}
