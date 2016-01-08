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
    /// Interaction logic for NhaXuatBanUI.xaml
    /// </summary>
    public partial class NhaXuatBanUI : Window
    {
        public NhaXuatBanUI()
        {
            InitializeComponent();
        }

        private int id;

        void LoadData()
        {
            List<NhaXuatBan> nhaXuatBan = new List<NhaXuatBan>();
            NhaXuatBanBUS busNhaXuatBan = new NhaXuatBanBUS();

            nhaXuatBan = busNhaXuatBan.GetList();

            dataGrid.Items.Clear();

            id = 1;
            foreach (NhaXuatBan i in nhaXuatBan)
            {
                ThongTinNhaXuatBan thongTinNhaXuatBan = new ThongTinNhaXuatBan();
                thongTinNhaXuatBan.MaNhaXuatBan = i.MaNXB;
                thongTinNhaXuatBan.TenNhaXuatBan = i.TenNXB;
                thongTinNhaXuatBan.DiaChi = i.DiaChiNXB;
                thongTinNhaXuatBan.SoDienThoai = i.SoDienThoai;

                dataGrid.IsReadOnly = true;
                dataGrid.Items.Add(thongTinNhaXuatBan);

                if (id < int.Parse(i.MaNXB))
                {
                    id = int.Parse(i.MaNXB);
                }
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadData();
        }

        private void btThem_Click(object sender, RoutedEventArgs e)
        {
            NhaXuatBan nhaXuatBan = new NhaXuatBan() { MaNXB = (++id).ToString(), TenNXB = tbTenTacGia.Text, DiaChiNXB = tbDiaChi.Text, SoDienThoai=tbSoDienThoai.Text };

            NhaXuatBanBUS bus = new NhaXuatBanBUS();

            try
            {
                bus.Insert(nhaXuatBan);

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
            NhaXuatBan nhaXuatBan = new NhaXuatBan() { MaNXB = tbMaNhaXuatBan.Text, TenNXB = tbTenTacGia.Text, DiaChiNXB = tbDiaChi.Text, SoDienThoai = tbSoDienThoai.Text };

            NhaXuatBanBUS bus = new NhaXuatBanBUS();

            try
            {
                bus.Update(nhaXuatBan);

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
            NhaXuatBanBUS bus = new NhaXuatBanBUS();

            try
            {
                bus.Delete(tbMaNhaXuatBan.Text);

                MessageBox.Show("Xóa thành công !");
            }
            catch (Exception)
            {
                MessageBox.Show("Xóa thất bại !");
            }
            

            LoadData();
        }
    }

    public class ThongTinNhaXuatBan
    {
        public string MaNhaXuatBan { get; set; }
        public string TenNhaXuatBan { get; set; }
        public string DiaChi { get; set; }
        public string SoDienThoai { get; set; }
    }
}
