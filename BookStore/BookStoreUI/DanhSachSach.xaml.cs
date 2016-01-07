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
    /// Interaction logic for DanhSachSach.xaml
    /// </summary>
    public partial class DanhSachSach : UserControl
    {
        public DanhSachSach()
        {
            InitializeComponent();
        }

        List<TheLoai> _theLoai = new List<TheLoai>();
        TheLoaiBUS _busTheLoai = new TheLoaiBUS();

        struct ThongTinSach
        {
            public int Stt { get; set; }
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
            foreach(TacGia i in list)
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

        private void btTim_Click(object sender, RoutedEventArgs e)
        {
            List<Sach> _sach = new List<Sach>();
            SachBUS _busSach = new SachBUS();

            dataGrid.Items.Clear();

            _sach = _busSach.GetList();

            string _maTheLoai = "";
            foreach(TheLoai i in _theLoai)
            {
                if (i.TenTheLoai == cbbTheLoai.Text)
                {
                    _maTheLoai = i.MaTheLoai;
                    break;
                }
            }

            List<TacGia> _tacGia = new List<TacGia>();
            TacGiaBUS _busTacGia = new TacGiaBUS();
            _tacGia = _busTacGia.GetList();

            List<NhaXuatBan> _nhaXuatBan = new List<NhaXuatBan>();
            NhaXuatBanBUS _busNhaXuatBan = new NhaXuatBanBUS();
            _nhaXuatBan = _busNhaXuatBan.GetList();

            int stt = 1;

            if (tbTenSach.Text == "")
            {
                foreach (Sach i in _sach)
                {
                    if (i.TheLoai == _maTheLoai)
                    {
                        ThongTinSach _thongTinSach = new ThongTinSach();
                        _thongTinSach.Stt = stt++;
                        _thongTinSach.TenSach = i.TenSach;
                        _thongTinSach.TheLoai = cbbTheLoai.Text;
                        _thongTinSach.TacGia = LayTenTacGia(_tacGia, i.TacGia);
                        _thongTinSach.NhaXuatBan = LayTenNhaXuatBan(_nhaXuatBan, i.NhaXuatBan);
                        _thongTinSach.NamXuatBan = i.NamXuatBan;
                        _thongTinSach.GiaBan = i.GiaBan.ToString();
                        _thongTinSach.SoLuong = i.SoLuong;

                        dataGrid.Items.Add(_thongTinSach);
                    }
                }
            }
            else if (tbTenSach.Text != "" && cbbTheLoai.Text != "")
            {
                foreach (Sach i in _sach)
                {
                    if (i.TenSach == tbTenSach.Text && i.TheLoai==_maTheLoai)
                    {
                        ThongTinSach _thongTinSach = new ThongTinSach();
                        _thongTinSach.Stt = stt++;
                        _thongTinSach.TenSach = i.TenSach;
                        _thongTinSach.TheLoai = cbbTheLoai.Text;
                        _thongTinSach.TacGia = LayTenTacGia(_tacGia, i.TacGia);
                        _thongTinSach.NhaXuatBan = LayTenNhaXuatBan(_nhaXuatBan, i.NhaXuatBan);
                        _thongTinSach.NamXuatBan = i.NamXuatBan;
                        _thongTinSach.GiaBan = i.GiaBan.ToString();
                        _thongTinSach.SoLuong = i.SoLuong;

                        dataGrid.Items.Add(_thongTinSach);
                    }
                }
            }
            else if(tbTenSach.Text!="")
            {
                foreach (Sach i in _sach)
                {
                    if (i.TenSach == tbTenSach.Text)
                    {
                        ThongTinSach _thongTinSach = new ThongTinSach();
                        _thongTinSach.Stt = stt++;
                        _thongTinSach.TenSach = i.TenSach;
                        _thongTinSach.TheLoai = LayTenTheLoai(_theLoai,i.TheLoai);
                        _thongTinSach.TacGia = LayTenTacGia(_tacGia, i.TacGia);
                        _thongTinSach.NhaXuatBan = LayTenNhaXuatBan(_nhaXuatBan, i.NhaXuatBan);
                        _thongTinSach.NamXuatBan = i.NamXuatBan;
                        _thongTinSach.GiaBan = i.GiaBan.ToString();
                        _thongTinSach.SoLuong = i.SoLuong;

                        dataGrid.Items.Add(_thongTinSach);
                    }
                }
            }
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            _theLoai = _busTheLoai.GetList();

            cbbTheLoai.ItemsSource = _theLoai;
            cbbTheLoai.DisplayMemberPath = "TenTheLoai";         
        }
    }
}
