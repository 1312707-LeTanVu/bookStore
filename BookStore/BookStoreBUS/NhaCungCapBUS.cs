using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using BookStoreDAO;

namespace BookStoreBUS
{
    public class NhaCungCapBUS
    {
        private NhaCungCapDAO data = new NhaCungCapDAO();
        public List<NhaCungCap> GetList()
        {
            return data.GetList();
        }

        public void Insert(NhaCungCap info)
        {
            data.Insert(info);
        }

        public void Delete(string code)
        {
            data.Delete(code);
        }

        public void Update(NhaCungCap info)
        {
            data.Update(info);
        }
    }
}
