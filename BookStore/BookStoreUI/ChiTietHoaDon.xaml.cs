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
    /// Interaction logic for ChiTietHoaDon.xaml
    /// </summary>
    public partial class ChiTietHoaDon : Window
    {
        private string tenKH;
        private string maHD;
        private DateTime ngayLapHD;

        public ChiTietHoaDon(string tenKH, DateTime ngayLapHD,string maHD)
        {
            this.tenKH = tenKH;
            this.maHD = maHD;
            this.ngayLapHD = ngayLapHD;
            InitializeComponent();
        }


        private void ResetForm()
        {
            tbTeSach.Text = "";           
        }

        public class ThongTinChiTietHoaDon
        {
            public string MaCTHD { get; set; }
            public string TenSach { get; set; }
            public string TheLoai { get; set; }
            public string SoLuong { get; set; }
            public string DonGia { get; set; }
        }

        private void btThem_Click(object sender, RoutedEventArgs e)
        {
            dsChiTietHoaDon = chiTietHoaDonBus.GetList();

            Entity.ChiTietHoaDon chiTietHoaDon = new Entity.ChiTietHoaDon();
            chiTietHoaDon.MaHD = maHD;
            chiTietHoaDon.SoLuong = int.Parse(tbSoLuong.Text);

            ThongTinChiTietHoaDon info = new ThongTinChiTietHoaDon();
            int id = int.Parse(dsChiTietHoaDon[dsChiTietHoaDon.Count - 1].MaCTHD);

            chiTietHoaDon.MaCTHD = (++id).ToString();

            info.MaCTHD = id.ToString();

            info.TenSach = tbTeSach.Text;
            info.SoLuong = tbSoLuong.Text.ToString();

            foreach (Sach item in dsSach)
            {
                if(item.TenSach==tbTeSach.Text)
                {
                    chiTietHoaDon.MaSach = item.MaSach;
                    info.DonGia = item.GiaBan.ToString();
                    foreach (TheLoai theloai in dsTheLoai)
                    {
                        if(item.TheLoai==theloai.MaTheLoai)
                        {
                            info.TheLoai = theloai.TenTheLoai;
                            break;
                        }
                    }
                    break;
                }
            }

            chiTietHoaDonBus.Insert(chiTietHoaDon);

            dataGrid.Items.Add(info);
        }

        private TheLoaiBUS theLoaiBus = new TheLoaiBUS();
        private static List<TheLoai> dsTheLoai = new List<TheLoai>();

        private SachBUS sachBus = new SachBUS();
        private static List<Entity.Sach> dsSach = new List<Entity.Sach>();

        private ChiTietHoaDonBUS chiTietHoaDonBus = new ChiTietHoaDonBUS();
        private List<Entity.ChiTietHoaDon> dsChiTietHoaDon = new List<Entity.ChiTietHoaDon>();
             
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            dsTheLoai = theLoaiBus.GetList();   
            dsSach = sachBus.GetList();

            tclMaHoaDon.Text = maHD;
            tclNgayNhap.Text = ngayLapHD.ToShortDateString();
            tclTenKH.Text = tenKH;
        }

        private void btSua_Click(object sender, RoutedEventArgs e)
        {
            dsChiTietHoaDon = chiTietHoaDonBus.GetList();

            Entity.ChiTietHoaDon chiTietHoaDon = new Entity.ChiTietHoaDon();
            chiTietHoaDon.MaHD = maHD;
            chiTietHoaDon.SoLuong = int.Parse(tbSoLuong.Text);
            chiTietHoaDon.MaCTHD = tbMaCTHD.Text;        

            foreach (Sach item in dsSach)
            {
                if (item.TenSach == tbTeSach.Text)
                {
                    chiTietHoaDon.MaSach = item.MaSach;                                     
                    break;
                }
            }

            chiTietHoaDonBus.Update(chiTietHoaDon);

            
        }

        private void btXoa_Click(object sender, RoutedEventArgs e)
        {
            chiTietHoaDonBus.Delete(tbMaCTHD.Text);

            foreach (ThongTinChiTietHoaDon item in dataGrid.Items)
            {
                if (item.MaCTHD == tbMaCTHD.Text)
                {
                    dataGrid.Items.Remove(item);
                    break;
                }
            }
        }
    }
}
