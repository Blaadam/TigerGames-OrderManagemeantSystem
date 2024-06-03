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

namespace TigerGames_OrderManagementSystemSS.AddWindows
{
    /// <summary>
    /// Interaction logic for AddProductsWindow.xaml
    /// </summary>
    public partial class AddProductsWindow : Window
    {
        public AddProductsWindow()
        {
            InitializeComponent();
        }

        private void Add_Product_ClearBtn_Click(object sender, RoutedEventArgs e)
        {
            Add_Productname.Text = string.Empty;
            Add_ProductDescription.Text = string.Empty;
            Add_ProductCategory.Text = string.Empty;
            Add_ProductSize.Text = string.Empty;
            Add_ProductWholesaleCost.Text = string.Empty;
            Add_ProductInStock.IsChecked = false;
            Add_ProductQuantity.Text = string.Empty;
            Add_ProductSerialNumber.Text = string.Empty;
        }

        private void Add_Order_AddBtn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
