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

namespace BookStoreUI
{
    /// <summary>
    /// Interaction logic for LapBaoCaoThang.xaml
    /// </summary>
    public partial class LapBaoCaoThang : Window
    {
        public LapBaoCaoThang()
        {
            InitializeComponent();
        }

        public int Month { get; set; }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            for(int i = 1; i < 13; i++)
            {
                cbbThang.Items.Add(i);
            }

            cbbThang.SelectedIndex = 0;
        }

        private void btXuatBaoCao_Click(object sender, RoutedEventArgs e)
        {
            Month = int.Parse(cbbThang.Text);

            DialogResult = true;
        }
    }
}
