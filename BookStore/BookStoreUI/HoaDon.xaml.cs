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
    /// Interaction logic for HoaDon.xaml
    /// </summary>
    public partial class HoaDon : UserControl
    {
        public HoaDon()
        {
            InitializeComponent();
        }

        public static string tenKhachHang = "";

        private HoaDonBUS hoaDonBus =new HoaDonBUS();

        private int id;
        private void LoadData()
        {
            List<Entity.HoaDon> dsHoaDon = new List<Entity.HoaDon>();
            dsHoaDon = hoaDonBus.GetList();
            id = int.Parse(dsHoaDon[dsHoaDon.Count - 1].MaHD);
            dataGrid.ItemsSource = dsHoaDon;
        }
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            LoadData();
        }

        private void btXoa_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                hoaDonBus.Delete(tbMaHoaDon.Text);
                LoadData();
                MessageBox.Show("Xóa thành công !");
            }
            catch (Exception)
            {
                MessageBox.Show("Xóa thất bại !");
            }     
        }

        private void btThem_Click(object sender, RoutedEventArgs e)
        {
            Entity.HoaDon info = new Entity.HoaDon() {MaHD=(++id).ToString(), TenKH=tbTenKhachHang.Text, NgayLapHD=(DateTime)datePicker.SelectedDate};
            tenKhachHang = tbTenKhachHang.Text;       
         //   try           
            {
                hoaDonBus.Insert(info);

                MessageBox.Show("Thêm thành công !");
                LoadData();

                ChiTietHoaDon chiTietHoaDon = new ChiTietHoaDon(tenKhachHang, (DateTime)datePicker.SelectedDate,id.ToString());
                chiTietHoaDon.WindowStartupLocation = WindowStartupLocation.CenterScreen;

                chiTietHoaDon.ShowDialog();
            }
            //catch (Exception)
            //{
            //    MessageBox.Show("Thêm thất bại !");
            //}                                 
        }

        private void btSua_Click(object sender, RoutedEventArgs e)
        {
            Entity.HoaDon info = new Entity.HoaDon() { MaHD = tbMaHoaDon.Text, TenKH = tbTenKhachHang.Text, NgayLapHD = (DateTime)datePicker.SelectedDate };

            try
            {
                hoaDonBus.Update(info);

                MessageBox.Show("Sửa thành công !");
            }
            catch (Exception)
            {
                MessageBox.Show("Sửa thất bại !");
            }

            LoadData();
        }
    }
}
