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
    /// Interaction logic for TacGiaUI.xaml
    /// </summary>
    public partial class TacGiaUI : Window
    {
        public TacGiaUI()
        {
            InitializeComponent();
        }

        private int id;

        void LoadData()
        {
            List<TacGia> _tacGia = new List<TacGia>();
            TacGiaBUS _busTacGia = new TacGiaBUS();

            _tacGia = _busTacGia.GetList();

            dataGrid.Items.Clear();

            id = 1;
            foreach (TacGia i in _tacGia)
            {
                ThongTinTacGia _thongTinTacGia = new ThongTinTacGia();
                _thongTinTacGia.MaTacGia = i.MaTG;
                _thongTinTacGia.TenTacGia = i.TenTG;

                dataGrid.IsReadOnly = true;
                dataGrid.Items.Add(_thongTinTacGia);

                if (id < int.Parse(i.MaTG))
                {
                    id = int.Parse(i.MaTG);
                }
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadData();
        }

        private void btThem_Click(object sender, RoutedEventArgs e)
        {
            TacGia tacGia = new TacGia() { MaTG = (++id).ToString(), TenTG = tbTenTacGia.Text };

            TacGiaBUS bus = new TacGiaBUS();

            try
            {
                bus.Insert(tacGia);

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
            TacGia tacGia = new TacGia() { MaTG = tbMaTacGia.Text, TenTG = tbTenTacGia.Text };

            TacGiaBUS bus = new TacGiaBUS();

            try
            {
                bus.Update(tacGia);

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
            TacGiaBUS bus = new TacGiaBUS();

            try
            {
                bus.Delete(tbMaTacGia.Text);

                MessageBox.Show("Xóa thành công !");
            }
            catch (Exception)
            {
                MessageBox.Show("Xóa thất bại !");
            }
            

            LoadData();
        }
    }

    public class ThongTinTacGia
    {
        public string MaTacGia { get; set; }
        public string TenTacGia { get; set; }
    }
}
