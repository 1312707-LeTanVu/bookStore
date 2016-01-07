using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using BookStoreDAO;

namespace BookStoreBUS
{
    public class CongNoBUS
    {
        private CongNoDAO data = new CongNoDAO();
        public List<CongNo> GetList()
        {
            return data.GetList();
        }

        public void Insert(CongNo info)
        {
            data.Insert(info);
        }

        public void Delete(string code)
        {
            data.Delete(code);
        }

        public void Update(CongNo info)
        {
            data.Update(info);
        }
    }
}
