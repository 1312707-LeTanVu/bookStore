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
    /// Interaction logic for QuanLySachUI.xaml
    /// </summary>
    public partial class QuanLySachUI : UserControl
    {
        public QuanLySachUI()
        {
            InitializeComponent();
        }

        struct ThongTinSach
        {
            public string MaSach { get; set; }
            public string TenSach { get; set; }
            public string TheLoai { get; set; }
            public string TacGia { get; set; }
            public string NhaXuatBan { get; set; }
            public int NamXuatBan { get; set; }
            public string GiaBan { get; set; }
            public int SoLuong { get; set; }
        }


        private string LayTenTacGia(List<TacGia> list, string maTacGia)
        {
            string tenTG = "";
            foreach (TacGia i in list)
            {
                if (i.MaTG == maTacGia)
                {
                    tenTG = i.TenTG;
                    break;
                }
            }
            return tenTG;
        }

        private string LayTenNhaXuatBan(List<NhaXuatBan> list, string maNhaXuatBan)
        {
            string tenNXB = "";
            foreach (NhaXuatBan i in list)
            {
                if (i.MaNXB == maNhaXuatBan)
                {
                    tenNXB = i.TenNXB;
                    break;
                }
            }
            return tenNXB;
        }

        private string LayTenTheLoai(List<TheLoai> list, string maTheLoai)
        {
            string tenTheLoai = "";
            foreach (TheLoai i in list)
            {
                if (i.MaTheLoai == maTheLoai)
                {
                    tenTheLoai = i.TenTheLoai;
                    break;
                }
            }
            return tenTheLoai;
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            List<Sach> _sach = new List<Sach>();
            SachBUS _busSach = new SachBUS();

            dataGrid.Items.Clear();

            _sach = _busSach.GetList();

            List<TacGia> _tacGia = new List<TacGia>();
            TacGiaBUS _busTacGia = new TacGiaBUS();
            _tacGia = _busTacGia.GetList();

            List<NhaXuatBan> _nhaXuatBan = new List<NhaXuatBan>();
            NhaXuatBanBUS _busNhaXuatBan = new NhaXuatBanBUS();
            _nhaXuatBan = _busNhaXuatBan.GetList();

            List<TheLoai> _theLoai = new List<TheLoai>();
            TheLoaiBUS _busTheLoai = new TheLoaiBUS();
            _theLoai = _busTheLoai.GetList();

            foreach (Sach i in _sach)
            {
                ThongTinSach _thongTinSach = new ThongTinSach();
                _thongTinSach.MaSach = i.MaSach;
                _thongTinSach.TenSach = i.TenSach;
                _thongTinSach.TheLoai = LayTenTheLoai(_theLoai, i.TheLoai);
                _thongTinSach.TacGia = LayTenTacGia(_tacGia, i.TacGia);
                _thongTinSach.NhaXuatBan = LayTenNhaXuatBan(_nhaXuatBan, i.NhaXuatBan);
                _thongTinSach.NamXuatBan = i.NamXuatBan;
                _thongTinSach.GiaBan = i.GiaBan.ToString();
                _thongTinSach.SoLuong = i.SoLuong;

                dataGrid.Items.Add(_thongTinSach);
            }
        }

        private void btSua_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btXoa_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
