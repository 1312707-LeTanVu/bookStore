using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BookStoreUI
{
    /// <summary>
    /// Interaction logic for ThongTin.xaml
    /// </summary>
    public partial class ThongTin : UserControl
    {
        public ThongTin()
        {
            InitializeComponent();
        }

        public void SetInformation(string tenTaiKhoan, string tenNguoiDung, string diaChi, string ngaySinh, string CMDN, string soDienThoai)
        {
            lbTenTaiKhoan.Content = tenTaiKhoan;
            lbTenNguoiDung.Content = tenNguoiDung;
            lbDiaChi.Content = diaChi;
            lbNgaySinh.Content = ngaySinh;
            lbCMDN.Content = CMDN;
            lbSoDienThoai.Content = soDienThoai;
        }
    }
}
