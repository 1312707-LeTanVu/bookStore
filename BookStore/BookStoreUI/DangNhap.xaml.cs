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
using System.Windows.Shapes;

namespace BookStoreUI
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class DangNhap : Window
    {
        public DangNhap()
        {
            InitializeComponent();
            txtTenDangNhap.Text = "admin";
            txtMatKhau.Text = "admin";
        }

        private void btDangNhap_Click(object sender, RoutedEventArgs e)
        {
            MainWindow._tenDangNhap = txtTenDangNhap.Text;
            MainWindow._matKhau = txtMatKhau.Text;
            this.DialogResult = true;
        }

        private void btThoat_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }
    }
}
