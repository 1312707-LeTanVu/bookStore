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
using Entity;
using BookStoreBUS;

namespace BookStoreUI
{
    /// <summary>
    /// Interaction logic for KhachHangUI.xaml
    /// </summary>
    public partial class KhachHangUI : UserControl
    {
        public KhachHangUI()
        {
            InitializeComponent();
        }

        private void btTim_Click(object sender, RoutedEventArgs e)
        {
            List<KhachHang> khachHang = new List<KhachHang>();
            KhachHangBUS busKhachHang = new KhachHangBUS();

            khachHang = busKhachHang.GetList();

            dataGrid.Items.Clear();

            foreach(KhachHang i in khachHang)
            {
                if (String.Compare(tbTenKhachHang.Text, i.TenKH, true) == 0)
                {
                    ThongTinKhachHang thongTinKhachHang = new ThongTinKhachHang();

                    thongTinKhachHang.MaKhachHang = int.Parse(i.MaKH);
                    thongTinKhachHang.TenKhachHang = i.TenKH;
                    thongTinKhachHang.DiaChi = i.DiaChiKH;
                    thongTinKhachHang.SoDienThoai = i.SoDienThoai;
                    thongTinKhachHang.Email = i.Email;

                    dataGrid.IsReadOnly = true;
                    dataGrid.Items.Add(thongTinKhachHang);
                }
            }
        }
    }

    class ThongTinKhachHang
    {
        public int MaKhachHang { get; set; }
        public string TenKhachHang { get; set; }
        public string DiaChi { get; set; }
        public string SoDienThoai { get; set; }
        public string Email { get; set; }
    }
}
