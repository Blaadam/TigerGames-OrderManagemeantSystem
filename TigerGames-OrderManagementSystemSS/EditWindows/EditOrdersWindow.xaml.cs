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
    /// Interaction logic for EditOrdersWindow.xaml
    /// </summary>
    public partial class EditOrdersWindow : Window
    {
        private int SelectedID;
        public EditOrdersWindow(int EntryID)
        {
            InitializeComponent();
            SelectedID = EntryID;

            Edit_LabelID.Content = "Product ID: " + SelectedID.ToString();

            var context = new AW_Tiger_GamesEntities();
            var existingData = context.tblOrders.Where(c => c.OrderID == SelectedID).FirstOrDefault();
            Edit_OrderCustomerID.Text = existingData.CustomerID.ToString();
            Edit_OrderCustomerSurname.Text = existingData.CustomerSurname;
            Edit_OrderHouseNumber.Text = existingData.CustomerHouseNumber.ToString();
            Edit_OrderEditress.Text = existingData.CustomerAddress;
            Edit_OrderPostCode.Text = existingData.CustomerPostcode;
            Edit_OrderCity.Text = existingData.CustomerCity;
            Edit_OrderCountry.Text = existingData.CustomerCountry;
            Edit_OrderProductID.Text = existingData.ProductID.ToString();
            Edit_OrderProductName.Text = existingData.ProductName;
            Edit_OrderQuantity.Text = existingData.ProductQty.ToString();
            Edit_OrderCost.Text = existingData.OrderCost.ToString();
            Edit_OrderShippingCost.Text = existingData.OrderShippingCost.ToString();
            Edit_OrderFinalTotal.Text = existingData.OrderFinalTotal.ToString();
            Edit_OrderStatus.Text = existingData.OrderStatus;
        }

        private void Edit_Order_ClearBtn_Click(object sender, RoutedEventArgs e)
        {
            Edit_OrderCustomerID.Text = string.Empty;
            Edit_OrderCustomerSurname.Text = string.Empty;
            Edit_OrderHouseNumber.Text = string.Empty;
            Edit_OrderEditress.Text = string.Empty;
            Edit_OrderPostCode.Text = string.Empty;
            Edit_OrderCity.Text = string.Empty;
            Edit_OrderCountry.Text = string.Empty;
            Edit_OrderProductID.Text = string.Empty;
            Edit_OrderProductName.Text = string.Empty;
            Edit_OrderQuantity.Text = string.Empty;
            Edit_OrderCost.Text = string.Empty;
            Edit_OrderShippingCost.Text = string.Empty;
            Edit_OrderFinalTotal.Text = string.Empty;
            Edit_OrderStatus.Text = string.Empty;
        }

        private void Edit_Order_EditBtn_Click(object sender, RoutedEventArgs e)
        {
            var context = new AW_Tiger_GamesEntities();

            string inputCustomerID = Edit_OrderCustomerID.Text.Trim();
            string inputCustomerSurname = Edit_OrderCustomerSurname.Text.Trim();
            string inputHouseNumber = Edit_OrderHouseNumber.Text.Trim();
            string inputEditress = Edit_OrderEditress.Text.Trim();
            string inputPostCode = Edit_OrderPostCode.Text.Trim();
            string inputCity = Edit_OrderCity.Text.Trim();
            string inputCountry = Edit_OrderCountry.Text.Trim();
            string inputProductID = Edit_OrderProductID.Text.Trim();
            string inputProductName = Edit_OrderProductName.Text.Trim();
            string inputQuantity = Edit_OrderQuantity.Text.Trim();
            string inputCost = Edit_OrderCost.Text.Trim();
            string inputShippingCost = Edit_OrderShippingCost.Text.Trim();
            string inputFinalTotal = Edit_OrderFinalTotal.Text.Trim();
            string inputStatus = Edit_OrderStatus.Text.Trim();

            if (string.IsNullOrEmpty(inputCustomerID) || string.IsNullOrEmpty(inputCustomerSurname) || string.IsNullOrEmpty(inputHouseNumber) || string.IsNullOrEmpty(inputEditress) || string.IsNullOrEmpty(inputPostCode) || string.IsNullOrEmpty(inputCity) || string.IsNullOrEmpty(inputCountry) || string.IsNullOrEmpty(inputProductID) || string.IsNullOrEmpty(inputProductName) || string.IsNullOrEmpty(inputQuantity) || string.IsNullOrEmpty(inputCost) || string.IsNullOrEmpty(inputShippingCost) || string.IsNullOrEmpty(inputFinalTotal) || string.IsNullOrEmpty(inputStatus))
            {
                MessageBox.Show("One or more field(s) are empty.", "Tiger Games v1.0", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            var existingData = context.tblOrders.Where(c => c.OrderID == SelectedID).FirstOrDefault();
            existingData.CustomerID = Convert.ToInt32(inputCustomerID);
            existingData.CustomerSurname = inputCustomerSurname;
            existingData.CustomerHouseNumber = Convert.ToInt32(inputHouseNumber);
            existingData.CustomerAddress = inputEditress;
            existingData.CustomerPostcode = inputPostCode;
            existingData.CustomerCity = inputCity;
            existingData.CustomerCountry = inputCountry;
            existingData.ProductID = Convert.ToInt32(inputProductID);
            existingData.ProductName = inputProductName;
            existingData.ProductQty = Convert.ToInt32(inputQuantity);
            existingData.OrderCost = Convert.ToDecimal(inputCost);
            existingData.OrderShippingCost = Convert.ToDecimal(inputShippingCost);
            existingData.OrderFinalTotal = Convert.ToDecimal(inputFinalTotal);
            existingData.OrderStatus = inputStatus;
        }
    }
}
