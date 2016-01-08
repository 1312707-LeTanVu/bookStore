using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
using System.Configuration;

namespace BookStoreUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Fluent.RibbonWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }

     
        Window currentWindow;
        MessageBoxResult msResult;

        public static string _tenDangNhap;
        public static string _matKhau;

        private string currentUser;

        private void RibbonWindow_Loaded(object sender, RoutedEventArgs e)
        {
            DataProvider.ConnectionString = ConfigurationManager.ConnectionStrings["QuanLyNhaSach"].ConnectionString;
            DisabledControl();
        }

        private void DisabledControl()
        {
            btThongTin.IsEnabled = false;
            btDangXuat.IsEnabled = false;
            btXem.IsEnabled = false;
            btThayDoi.IsEnabled = false;
            btTraCuuKhachHang.IsEnabled = false;

            tabBaoCao.IsEnabled = false;
            tabQuanLy.IsEnabled = false;

            grTaiKhoan.IsEnabled = false;
        }

        private void EnabledControlAdmin()
        {
            btThongTin.IsEnabled = true;
            btDangXuat.IsEnabled = true;
            btXem.IsEnabled = true;
            btThayDoi.IsEnabled = true;
            btTraCuuKhachHang.IsEnabled = true;

            tabBaoCao.IsEnabled = true;
            tabQuanLy.IsEnabled = true;

            grTaiKhoan.IsEnabled = true;
        }

        private void EnabledControlUser()
        {
            btThongTin.IsEnabled = true;
            btDangXuat.IsEnabled = true;
            btXem.IsEnabled = true;
            btTraCuuKhachHang.IsEnabled = true;

            tabBaoCao.IsEnabled = true;
            tabQuanLy.IsEnabled = true;

        }

        private void tabHeThong_btThoat_Click(object sender, RoutedEventArgs e)
        {
            
            msResult = Xceed.Wpf.Toolkit.MessageBox.Show("Bạn có muốn thoát không ?", "Quản Lý Nhà Sách", MessageBoxButton.YesNo, MessageBoxImage.Warning);

            if (msResult == MessageBoxResult.Yes)
            {
                Application.Current.Shutdown();
            }
        }

        private void btDangNhap_Click(object sender, RoutedEventArgs e)
        {
            
            while (true)
            {
                currentWindow = new DangNhap();
                currentWindow.ShowDialog();

                if (currentWindow.DialogResult == true)
                {
                    List<TaiKhoan> _taiKhoan = new List<TaiKhoan>();
                    TaiKhoanBUS _busTaiKhoan = new TaiKhoanBUS();
                    _taiKhoan = _busTaiKhoan.GetList();
                    foreach(TaiKhoan i in _taiKhoan)
                    {
                        if (_tenDangNhap == i.TenDangNhap && _matKhau == i.MatKhau && i.TenDangNhap == "admin")
                        {
                            EnabledControlAdmin();
                            currentUser = i.TenDangNhap;
                            return;
                        }
                        else if (_tenDangNhap == i.TenDangNhap && _matKhau == i.MatKhau)
                        {
                            EnabledControlUser();
                            currentUser = i.TenDangNhap;
                            return;
                        }
                    }
                    MessageBox.Show("Tên đăng nhập hoặc mật khẩu không đúng, vui lòng nhập lại !", "CÓ LỖI",
                                MessageBoxButton.OK, MessageBoxImage.Warning);
                }
                else
                {
                    return;
                }
            }
        }

        private void btDangXuat_Click(object sender, RoutedEventArgs e)
        {
            grid.Children.RemoveAt(grid.Children.Count - 1);
            DisabledControl();
        }

        private void main_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            msResult = Xceed.Wpf.Toolkit.MessageBox.Show("Bạn có muốn thoát không ?", "Quản Lý Nhà Sách", MessageBoxButton.YesNo, MessageBoxImage.Warning);

            if (msResult == MessageBoxResult.Yes)
            {
                Application.Current.Shutdown();
            }

            e.Cancel = true;
        }

        private void btThongTin_Click(object sender, RoutedEventArgs e)
        {
            if (grid.Children.Count > 0)
                grid.Children.RemoveAt(grid.Children.Count - 1);

            ThongTin thongTin = new ThongTin();

            List<NhanVien> _nhanVien = new List<NhanVien>();
            NhanVienBUS _busNhanVien = new NhanVienBUS();

            _nhanVien = _busNhanVien.GetList();

            foreach(NhanVien i in _nhanVien)
            {
                if (i.TaiKhoan == currentUser)
                {
                    thongTin.SetInformation(currentUser, i.HoTen, i.DiaChi, i.NgaySinh.ToShortDateString(), i.CMND, i.SDT);
                    grid.Children.Add(thongTin);
                    return;
                }
                else
                {
                    grid.Children.Add(thongTin);
                    return;
                }
            }  
        }

        private void btTraCuuSach_Click(object sender, RoutedEventArgs e)
        {
            if (grid.Children.Count > 0)
                 grid.Children.RemoveAt(grid.Children.Count - 1);

            DanhSachSach danhSachSach = new DanhSachSach();

            grid.Children.Add(danhSachSach);
        }

        private void btQLTaiKhoan_Click(object sender, RoutedEventArgs e)
        {
            if (grid.Children.Count > 0)
                grid.Children.RemoveAt(grid.Children.Count - 1);

            TaiKhoanUI taiKhoan = new TaiKhoanUI();

            grid.Children.Add(taiKhoan);
        }


        private void btTacGia_Click(object sender, RoutedEventArgs e)
        {
            if (grid.Children.Count > 0)
                grid.Children.RemoveAt(grid.Children.Count - 1);

            TacGiaUI tacGia = new TacGiaUI();
            tacGia.WindowStartupLocation = WindowStartupLocation.CenterScreen;

            tacGia.ShowDialog();
        }

        private void btTheLoai_Click(object sender, RoutedEventArgs e)
        {
            if (grid.Children.Count > 0)
                grid.Children.RemoveAt(grid.Children.Count - 1);

            TheLoaiUI theLoai = new TheLoaiUI();
            theLoai.WindowStartupLocation = WindowStartupLocation.CenterScreen;

            theLoai.ShowDialog();
        }

        int thangBaoCao;
        private void btLapBaoCaoThang_Click(object sender, RoutedEventArgs e)
        {
            if (grid.Children.Count > 0)
                grid.Children.RemoveAt(grid.Children.Count - 1);

            LapBaoCaoThang lapBaoCaoThang = new LapBaoCaoThang();

            if (lapBaoCaoThang.ShowDialog() == true)
            {
                thangBaoCao = lapBaoCaoThang.Month;
            }
        }

        private void btNhaXuatBan_Click(object sender, RoutedEventArgs e)
        {
            if (grid.Children.Count > 0)
                grid.Children.RemoveAt(grid.Children.Count - 1);

            NhaXuatBanUI nhaXuatBan = new NhaXuatBanUI();
            nhaXuatBan.WindowStartupLocation = WindowStartupLocation.CenterScreen;

            nhaXuatBan.ShowDialog();
        }

        private void btNhaCungCap_Click(object sender, RoutedEventArgs e)
        {
            if (grid.Children.Count > 0)
                grid.Children.RemoveAt(grid.Children.Count - 1);

            NhaCungCapUI nhaCungCap = new NhaCungCapUI();
            nhaCungCap.WindowStartupLocation = WindowStartupLocation.CenterScreen;

            nhaCungCap.ShowDialog();
        }

        private void btTraCuuKhachHang_Click(object sender, RoutedEventArgs e)
        {
            if (grid.Children.Count > 0)
                grid.Children.RemoveAt(grid.Children.Count - 1);

            KhachHangUI nhaCungCap = new KhachHangUI();

            grid.Children.Add(nhaCungCap);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (grid.Children.Count > 0)
                grid.Children.RemoveAt(grid.Children.Count - 1);

            QuanLyKhachHangUI quanLyKhachHang = new QuanLyKhachHangUI();

            grid.Children.Add(quanLyKhachHang);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (grid.Children.Count > 0)
                grid.Children.RemoveAt(grid.Children.Count - 1);

            QuanLySachUI quanLySach = new QuanLySachUI();

            grid.Children.Add(quanLySach);
        }
    }
}
