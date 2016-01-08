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
    /// Interaction logic for PhieuThuTien.xaml
    /// </summary>
    /// 
    public class ThongTinPhieuThu
    {
        public string MaPhieuThuTien { get; set; }
        public string NgayNhap { get; set; }
        public string HoTenKhachHang { get; set; }
        public string DiaChi { get; set; }
        public string SoDienThoai { get; set; }
        public string Email { get; set; }
        public string SoTienThu { get; set; }
    }

    public partial class PhieuThuTien : UserControl
    {
        public PhieuThuTien()
        {
            InitializeComponent();
        }


        static KhachHangBUS busKhachHang = new KhachHangBUS();
        static List<KhachHang> dsKhachHang = new List<KhachHang>();
        static HoaDonBUS busHoaDon = new HoaDonBUS();
        static List<Entity.HoaDon> dsHoaDon;

        private void Load()
        {
            PhieuThuTienBUS bus = new PhieuThuTienBUS();
            List<Entity.PhieuThuTien> dsPhieuThu = bus.GetList();

            dsKhachHang = busKhachHang.GetList();
            dsHoaDon = busHoaDon.GetList();

            foreach (Entity.PhieuThuTien ptt in dsPhieuThu)
            {
                ThongTinPhieuThu info = new ThongTinPhieuThu();
                info.SoTienThu = ptt.SoTienThu.ToString();
                info.MaPhieuThuTien = ptt.MaPTT;
                info.NgayNhap = ptt.NgayThuTien.ToString();

                foreach (var hd in dsHoaDon)
                {
                    if(hd.MaHD==ptt.MaHD)
                    {
                        foreach (KhachHang kh in dsKhachHang)
                        {
                            if (kh.MaKH == hd.TenKH)
                            {
                                info.HoTenKhachHang = kh.TenKH;
                                info.SoDienThoai = kh.SoDienThoai;
                                info.DiaChi = kh.DiaChiKH;
                                info.Email = kh.Email;
                                break;
                            }
                        }
                        break;
                    }
                }
                
                dataGrid.Items.Add(info);
            }       
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            Load();
        }

        private void btThem_Click(object sender, RoutedEventArgs e)
        {
            // them thong tin khach hang
            int idKhachHang = int.Parse(dsKhachHang[dsKhachHang.Count - 1].MaKH);

            KhachHang kh = new KhachHang()
            { MaKH = (idKhachHang++).ToString(), DiaChiKH = tbDiaChi.Text, Email = tbEmail.Text, SoDienThoai = tbSoTienThu.Text, TenKH = tbHoTenKhachHang.Text };

            busKhachHang.Insert(kh);

            // them thong tin phieu thu tien

            PhieuThuTien ptt = new PhieuThuTien()
            { };

        }
    }
}
