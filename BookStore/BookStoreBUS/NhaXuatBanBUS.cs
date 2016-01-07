using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using BookStoreDAO;

namespace BookStoreBUS
{
    public class NhaXuatBanBUS
    {
        private NhaXuatBanDAO data = new NhaXuatBanDAO();
        public List<NhaXuatBan> GetList()
        {
            return data.GetList();
        }

        public void Insert(NhaXuatBan info)
        {
            data.Insert(info);
        }

        public void Delete(string code)
        {
            data.Delete(code);
        }

        public void Update(NhaXuatBan info)
        {
            data.Update(info);
        }
    }
}
