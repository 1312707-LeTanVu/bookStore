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
using Entity;
using BookStoreBUS;

namespace BookStoreUI
{
    /// <summary>
    /// Interaction logic for TheLoaiUI.xaml
    /// </summary>
    public partial class TheLoaiUI : Window
    {
        public TheLoaiUI()
        {
            InitializeComponent();
        }

        private int id;

        void LoadData()
        {
            List<TheLoai> _theLoai = new List<TheLoai>();
            TheLoaiBUS _busTheLoai = new TheLoaiBUS();

            _theLoai = _busTheLoai.GetList();

            dataGrid.Items.Clear();

            id = 1;
            foreach (TheLoai i in _theLoai)
            {
                ThongTinTheLoai _thongTinTheLoai = new ThongTinTheLoai();
                _thongTinTheLoai.MaTheLoai = i.MaTheLoai;
                _thongTinTheLoai.TenTheLoai = i.TenTheLoai;
                _thongTinTheLoai.GhiChu = i.GhiChu;

                dataGrid.IsReadOnly = true;
                dataGrid.Items.Add(_thongTinTheLoai);

                if (id < int.Parse(i.MaTheLoai))
                {
                    id = int.Parse(i.MaTheLoai);
                }
            }
        }

        private void btThem_Click(object sender, RoutedEventArgs e)
        {
            TheLoai theLoai = new TheLoai() { MaTheLoai = (++id).ToString(), TenTheLoai = tbTenTheLoai.Text, GhiChu = tbGhiChu.Text };
          
            TheLoaiBUS bus = new TheLoaiBUS();

            bus.Insert(theLoai);

            LoadData();
        }

        private void btSua_Click(object sender, RoutedEventArgs e)
        {
            TheLoai theLoai = new TheLoai() { MaTheLoai = tbMaTheLoai.Text, TenTheLoai = tbTenTheLoai.Text, GhiChu = tbGhiChu.Text };

            TheLoaiBUS bus = new TheLoaiBUS();

            bus.Update(theLoai);

            LoadData();
        }

        private void btXoa_Click(object sender, RoutedEventArgs e)
        {
            TheLoaiBUS bus = new TheLoaiBUS();

            bus.Delete(tbMaTheLoai.Text);

            LoadData();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadData();
        }
    }

    public class ThongTinTheLoai
    {
        public string MaTheLoai { get; set; }
        public string TenTheLoai { get; set; }
        public string GhiChu { get; set; }
    }
}
