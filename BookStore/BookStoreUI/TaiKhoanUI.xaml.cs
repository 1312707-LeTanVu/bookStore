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
    /// Interaction logic for TaiKhoan.xaml
    /// </summary>
    public partial class TaiKhoanUI : UserControl
    {
        public TaiKhoanUI()
        {
            InitializeComponent();
        }

        private void LoadData()
        {

            List<TaiKhoan> _taiKhoan = new List<TaiKhoan>();
            TaiKhoanBUS _busTaiKhoan = new TaiKhoanBUS();

            _taiKhoan = _busTaiKhoan.GetList();

            dataGrid.Items.Clear();

            foreach (TaiKhoan i in _taiKhoan)
            {
                ThongTinTaiKhoan _thongTinTaiKhoan = new ThongTinTaiKhoan();
                _thongTinTaiKhoan.TenDangNhap = i.TenDangNhap;
                _thongTinTaiKhoan.MatKhau = i.MatKhau;

                dataGrid.IsReadOnly = true;
                dataGrid.Items.Add(_thongTinTaiKhoan);
            }
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            LoadData();
        }

        public class ThongTinTaiKhoan
        {
            public string TenDangNhap { get; set; }
            public string MatKhau { get; set; }
        }   

        private void btThem_Click(object sender, RoutedEventArgs e)
        {
            TaiKhoan taiKhoan = new TaiKhoan() { TenDangNhap = tbTaiKhoan.Text, MatKhau = tbMatKhau.Text };

            TaiKhoanBUS bus = new TaiKhoanBUS();

            bus.Insert(taiKhoan);

            LoadData();
        }

        private void btXoa_Click(object sender, RoutedEventArgs e)
        {
            TaiKhoanBUS bus = new TaiKhoanBUS();

            bus.Delete(tbTaiKhoan.Text);
            
            LoadData();
        }

        private void btSua_Click(object sender, RoutedEventArgs e)
        {
            TaiKhoan taiKhoan = new TaiKhoan() { TenDangNhap = tbTaiKhoan.Text, MatKhau = tbMatKhau.Text };

            TaiKhoanBUS bus = new TaiKhoanBUS();

            bus.Update(taiKhoan);

            LoadData();
        }
    }
}
