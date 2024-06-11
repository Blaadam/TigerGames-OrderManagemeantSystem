using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
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

namespace TigerGames_OrderManagementSystemSS.EditWindows
{
    /// <summary>
    /// Interaction logic for EditProductsWindow.xaml
    /// </summary>
    public partial class EditProductsWindow : Window
    {
        private int SelectedID;
        public EditProductsWindow(int EntryID)
        {
            InitializeComponent();
            SelectedID = EntryID;

            Edit_LabelID.Content = "Product ID: " + SelectedID.ToString();

            var context = new AW_Tiger_GamesEntities();
            var existingData = context.tblProducts.Where(c => c.ProductID == SelectedID).FirstOrDefault();
            Edit_Productname.Text = existingData.ProductName;
            Edit_ProductDescription.Text = existingData.ProductDescription;
            Edit_ProductCategory.Text = existingData.ProductCategory;
            Edit_ProductSize.Text = existingData.ProductSize;
            Edit_ProductRetailCost.Text = existingData.ProductRetailCost.ToString();
            Edit_ProductWholesaleCost.Text = existingData.ProductWholesaleCost.ToString();
            Edit_ProductQuantity.Text = existingData.ProductQuantity.ToString();
            Edit_ProductSerialNumber.Text = existingData.ProductSerialNumber;
        }
        private void Edit_Product_ClearBtn_Click(object sender, RoutedEventArgs e)
        {
            Edit_Productname.Text = string.Empty;
            Edit_ProductDescription.Text = string.Empty;
            Edit_ProductCategory.Text = string.Empty;
            Edit_ProductSize.Text = string.Empty;
            Edit_ProductRetailCost.Text = string.Empty;
            Edit_ProductWholesaleCost.Text = string.Empty;
            Edit_ProductQuantity.Text = string.Empty;
            Edit_ProductSerialNumber.Text = string.Empty;
        }

        private void Edit_Category_EditBtn_Click(object sender, RoutedEventArgs e)
        {
            var context = new AW_Tiger_GamesEntities();

            string inputProductName = Edit_Productname.Text.Trim();
            string inputProductDesc = Edit_ProductDescription.Text.Trim();
            string inputCategory = Edit_ProductCategory.Text.Trim();
            string inputProductSize = Edit_ProductSize.Text.Trim();
            string inputRetailCost = Edit_ProductRetailCost.Text.Trim();
            string inputWholesaleCost = Edit_ProductWholesaleCost.Text.Trim();
            //Edit_ProductInStock.Content
            string inputProductQuantity = Edit_ProductQuantity.Text.Trim();
            string inputSerialNumber = Edit_ProductSerialNumber.Text.Trim();

            if (string.IsNullOrEmpty(inputProductName) || string.IsNullOrEmpty(inputProductDesc) || string.IsNullOrEmpty(inputCategory) || string.IsNullOrEmpty(inputProductSize) || string.IsNullOrEmpty(inputRetailCost) || string.IsNullOrEmpty(inputWholesaleCost) || string.IsNullOrEmpty(inputProductQuantity) || string.IsNullOrEmpty(inputSerialNumber))
            {
                MessageBox.Show("One or more field(s) are empty.", "Tiger Games v1.0 - Edit Product", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            var existingData = context.tblProducts.Where(c => c.ProductID == SelectedID).FirstOrDefault();
            if (existingData == null)
            {
                MessageBox.Show("This customer does not exist.", "Tiger Games v1.0 - Edit Product", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
             
            existingData.ProductName = inputProductName;
            existingData.ProductDescription = inputProductDesc;
            existingData.ProductCategory = inputCategory;
            existingData.ProductSize = inputProductSize;
            existingData.ProductRetailCost = Convert.ToDecimal(inputRetailCost);
            existingData.ProductWholesaleCost = Convert.ToDecimal(inputWholesaleCost);
            existingData.ProductQuantity = Convert.ToInt32(inputProductQuantity);
            //existingData.InStock = Edit_ProductInStock.IsChecked.Value ? true : false;
            existingData.InStock = Convert.ToBoolean(Edit_ProductInStock.IsChecked.Value);
            existingData.ProductSerialNumber = inputSerialNumber;

            context.SaveChanges();

            MessageBox.Show($"Product \"{inputProductName}\" has been updated.", "Tiger Games v1.0 - Edit Product", MessageBoxButton.OK, MessageBoxImage.Information);

            this.Close();
        }
    }
}
