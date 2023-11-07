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

namespace Cinema_system.Views.Admin.Showtimemanagement
{
    /// <summary>
    /// Interaction logic for ShowtimeManagement.xaml
    /// </summary>
    public partial class ShowtimeManagement : Page
    {
        public ShowtimeManagement()
        {
            InitializeComponent();
        }

        private bool Filter(object item)
        {
            if (String.IsNullOrEmpty(_FilterBox.Text))
                return true;
            else
                //return ((item as MovieDTO).DisplayName.IndexOf(_FilterBox.Text, StringComparison.OrdinalIgnoreCase) >= 0);
                return true;
        }

        private void FilterBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(ShowtimeListview.ItemsSource);
            view.Filter = Filter;
            result.Content = ShowtimeListview.Items.Count;
            CollectionViewSource.GetDefaultView(ShowtimeListview.ItemsSource).Refresh();
        }

        private void all_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            _FilterBox.Text = "";
        }

        private void _FilterBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
