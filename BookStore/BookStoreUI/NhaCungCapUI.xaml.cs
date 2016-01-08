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
    /// Interaction logic for NhaCungCapUI.xaml
    /// </summary>
    public partial class NhaCungCapUI : Window
    {
        public NhaCungCapUI()
        {
            InitializeComponent();
        }

        int id;

        void LoadData()
        {
            List<NhaCungCap> nhaCungCap = new List<NhaCungCap>();
            NhaCungCapBUS busNhaCungCap = new NhaCungCapBUS();

            nhaCungCap = busNhaCungCap.GetList();

            dataGrid.Items.Clear();

            id = 1;
            foreach (NhaCungCap i in nhaCungCap)
            {
                ThongTinNhaCungCap thongTinNhaCungCap = new ThongTinNhaCungCap();
                thongTinNhaCungCap.MaNhaCungCap = i.MaNCC;
                thongTinNhaCungCap.TenNhaCungCap = i.TenNCC;
                thongTinNhaCungCap.DiaChi = i.DiaChiNCC;
                thongTinNhaCungCap.SoDienThoai = i.DienThoai;

                dataGrid.IsReadOnly = true;
                dataGrid.Items.Add(thongTinNhaCungCap);

                if (id < int.Parse(i.MaNCC))
                {
                    id = int.Parse(i.MaNCC);
                }
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadData();
        }

        private void btThem_Click(object sender, RoutedEventArgs e)
        {
            NhaCungCap nhaCungCap = new NhaCungCap() { MaNCC = (++id).ToString(), TenNCC = tbTenNhaCungCap.Text, DiaChiNCC = tbDiaChi.Text, DienThoai = tbSoDienThoai.Text };

            NhaCungCapBUS bus = new NhaCungCapBUS();

            try
            {
                bus.Insert(nhaCungCap);

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
            NhaCungCap nhaCungCap = new NhaCungCap() { MaNCC = tbMaNhaCungCap.Text, TenNCC = tbTenNhaCungCap.Text, DiaChiNCC = tbDiaChi.Text, DienThoai = tbSoDienThoai.Text };

            NhaCungCapBUS bus = new NhaCungCapBUS();

            try
            {
                bus.Update(nhaCungCap);

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
            NhaCungCapBUS bus = new NhaCungCapBUS();

            try
            {
                bus.Delete(tbMaNhaCungCap.Text);

                MessageBox.Show("Xóa thành công !");
            }
            catch (Exception)
            {
                MessageBox.Show("Xóa thất bại !");
            }

            LoadData();
        }
    }

    public class ThongTinNhaCungCap
    {
        public string MaNhaCungCap { get; set; }
        public string TenNhaCungCap { get; set; }
        public string DiaChi { get; set; }
        public string SoDienThoai { get; set; }
    }
}
