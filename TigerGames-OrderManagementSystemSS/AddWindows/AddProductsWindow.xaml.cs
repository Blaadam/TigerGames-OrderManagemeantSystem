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
            var context = new AW_Tiger_GamesEntities();

            string inputProductName = Add_ProductSerialNumber.Text.Trim();
            string inputProductDesc = Add_ProductDescription.Text.Trim();
            string inputCategory = Add_ProductCategory.Text.Trim();
            string inputProductSize = Add_ProductSize.Text.Trim();
            string inputRetailCost = Add_ProductRetailCost.Text.Trim();
            string inputWholesaleCost = Add_ProductWholesaleCost.Text.Trim();
            //Edit_ProductInStock.Content
            string inputProductQuantity = Add_ProductQuantity.Text.Trim();
            string inputSerialNumber = Add_ProductSerialNumber.Text.Trim();

            if (string.IsNullOrEmpty(inputProductName) || string.IsNullOrEmpty(inputProductDesc) || string.IsNullOrEmpty(inputCategory) || string.IsNullOrEmpty(inputProductSize) || string.IsNullOrEmpty(inputRetailCost) || string.IsNullOrEmpty(inputWholesaleCost) || string.IsNullOrEmpty(inputProductQuantity) || string.IsNullOrEmpty(inputSerialNumber))
            {
                MessageBox.Show("One or more field(s) are empty.", "Tiger Games v1.0 - Add Product", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            var existingData = context.tblProducts.Where(c => c.ProductName == inputProductName).FirstOrDefault();
            if (existingData != null)
            {
                MessageBox.Show("This product already exists!", "Tiger Games v1.0 - Add Product", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            
            tblProduct newProduct = new tblProduct();
            newProduct.ProductName = inputProductName;
            newProduct.ProductDescription = inputProductDesc;
            newProduct.ProductCategory = inputCategory;
            newProduct.ProductSize = inputProductSize;
            newProduct.ProductRetailCost = Convert.ToDecimal(inputRetailCost);
            newProduct.ProductWholesaleCost = Convert.ToDecimal(inputWholesaleCost);
            newProduct.ProductQuantity = Convert.ToInt32(inputProductQuantity);
            newProduct.InStock = Convert.ToBoolean(Add_ProductInStock.IsChecked.Value);
            newProduct.ProductSerialNumber = inputSerialNumber;

            context.tblProducts.Add(newProduct);
            context.SaveChanges();

            MessageBox.Show($"Product \"{inputProductName}\" has been created!", "Tiger Games v1.0 - Add Product", MessageBoxButton.OK, MessageBoxImage.Information);

            this.Close();
        }
    }
}
