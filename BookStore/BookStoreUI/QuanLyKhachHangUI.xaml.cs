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
    /// Interaction logic for QuanLyKhachHangUI.xaml
    /// </summary>
    public partial class QuanLyKhachHangUI : UserControl
    {
        public QuanLyKhachHangUI()
        {
            InitializeComponent();
        }

        int id;
        void LoadData()
        {
            List<KhachHang> khachHang = new List<KhachHang>();
            KhachHangBUS busKhachHang = new KhachHangBUS();

            khachHang = busKhachHang.GetList();

            dataGrid.Items.Clear();

            tbMaKhachHang.Clear();
            tbTenKhachHang.Clear();
            tbDiaChi.Clear();
            tbSoDienThoai.Clear();
            tbEmail.Clear();

            id = 1;
            foreach (KhachHang i in khachHang)
            {
                ThongTinKhachHang thongTinKhachHang = new ThongTinKhachHang();

                thongTinKhachHang.MaKhachHang = int.Parse(i.MaKH);
                thongTinKhachHang.TenKhachHang = i.TenKH;
                thongTinKhachHang.DiaChi = i.DiaChiKH;
                thongTinKhachHang.SoDienThoai = i.SoDienThoai;
                thongTinKhachHang.Email = i.Email;

                dataGrid.IsReadOnly = true;
                dataGrid.Items.Add(thongTinKhachHang);

                if (id < int.Parse(i.MaKH))
                {
                    id = int.Parse(i.MaKH);
                }
            }
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            LoadData();
        }


        private void btThem_Click(object sender, RoutedEventArgs e)
        {
            KhachHang khachHang = new KhachHang() { MaKH = (++id).ToString(), TenKH = tbTenKhachHang.Text, DiaChiKH = tbDiaChi.Text, SoDienThoai = tbSoDienThoai.Text, Email = tbEmail.Text };

            KhachHangBUS bus = new KhachHangBUS();

            try
            {
                bus.Insert(khachHang);

                MessageBox.Show("Thêm thành công !");
            }
            catch (Exception)
            {
                MessageBox.Show("Thêm thất bại !");
            }

            LoadData();
        }

        private void btSua_Click(object sender, RoutedEventArgs e)
        {
            KhachHang khachHang = new KhachHang() { MaKH = tbMaKhachHang.Text, TenKH = tbTenKhachHang.Text, DiaChiKH = tbDiaChi.Text, SoDienThoai = tbSoDienThoai.Text, Email = tbEmail.Text };

            KhachHangBUS bus = new KhachHangBUS();

            try
            {
                bus.Update(khachHang);

                MessageBox.Show("Sửa thành công !");
            }
            catch (Exception)
            {
                MessageBox.Show("Sửa thất bại !");
            }

            LoadData();
        }

        private void btXoa_Click(object sender, RoutedEventArgs e)
        {
            KhachHangBUS bus = new KhachHangBUS();

            try
            {
                bus.Delete(tbMaKhachHang.Text);

                MessageBox.Show("Xóa thành công !");
            }
            catch (Exception)
            {
                MessageBox.Show("Xóa thất bại !");
            }


            LoadData();
        }
    }
}
