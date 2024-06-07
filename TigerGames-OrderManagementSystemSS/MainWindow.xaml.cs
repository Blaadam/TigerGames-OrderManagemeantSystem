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

using TigerGames_OrderManagementSystemSS.MainViews;

namespace TigerGames_OrderManagementSystemSS
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int LastPageIndex = -1;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void LoadPage(string TableName)
        {
            DatagridView page = new DatagridView(TableName);

            var Content = page.Content;

            page.Content = null;

            if (LastPageIndex != -1)
            {
                MainContentFrame.Children.RemoveAt(LastPageIndex);
            }

            LastPageIndex = MainContentFrame.Children.Add(Content as UIElement);
        }

        private void HomeBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void CategoriesBtn_Click(object sender, RoutedEventArgs e)
        {
            LoadPage("Category");
        }

        private void ProductsBtn_Click(object sender, RoutedEventArgs e)
        {
            LoadPage("Product");

        }

        private void OrdersBtn_Click(object sender, RoutedEventArgs e)
        {
            LoadPage("Order");
        }

        private void CustomersBtn_Click(object sender, RoutedEventArgs e)
        {
            LoadPage("Customer");
        }

        private void LogoutButton_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to logout?", "Tiger Games v1.0", MessageBoxButton.YesNo) != MessageBoxResult.Yes)
            {
                return;
            }

            LoginScreen window = new LoginScreen();
            window.Show();
            this.Close();
        }
    }
}
