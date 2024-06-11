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
using TigerGames_OrderManagementSystemSS.AddWindows;

namespace TigerGames_OrderManagementSystemSS.EditWindows
{
    /// <summary>
    /// Interaction logic for EditCustomersWindow.xaml
    /// </summary>
    public partial class EditCustomersWindow : Window
    {
        private int SelectedID;
        public EditCustomersWindow(int EntryID)
        {
            InitializeComponent();
            SelectedID = EntryID;

            Edit_LabelID.Content = "Customer ID: " + SelectedID.ToString();

            var context = new AW_Tiger_GamesEntities();
            var existingData = context.tblCustomers.Where(c => c.CustomerID == SelectedID).FirstOrDefault();
            Edit_CustomerFirstName.Text = existingData.CustomerFirstName;
            Edit_CustomerSurname.Text = existingData.CustomerSurname;
            Edit_CustomerHouseNumber.Text = existingData.CustomerHouseNumber.ToString();
            Edit_CustomerAddress.Text = existingData.CustomerAddress;
            Edit_CustomerPostCode.Text = existingData.CustomerPostcode;
            Edit_CustomerCity.Text = existingData.CustomerCity;
            Edit_CustomerCountry.Text = existingData.CustomerCountry;
            Edit_CustomerHomeTel.Text = existingData.CustomerHomeTel.ToString();
            Edit_CustomerMobile.Text = existingData.CustomerMobile.ToString();
        }
        private void Edit_Customer_ClearBtn_Click(object sender, RoutedEventArgs e)
        {
            Edit_CustomerFirstName.Text = string.Empty;
            Edit_CustomerSurname.Text = string.Empty;
            Edit_CustomerHouseNumber.Text = string.Empty;
            Edit_CustomerAddress.Text = string.Empty;
            Edit_CustomerPostCode.Text = string.Empty;
            Edit_CustomerCity.Text = string.Empty;
            Edit_CustomerCountry.Text = string.Empty;
            Edit_CustomerHomeTel.Text = string.Empty;
            Edit_CustomerMobile.Text = string.Empty;
        }

        private void Edit_Customer_EditBtn_Click(object sender, RoutedEventArgs e)
        {
            var context = new AW_Tiger_GamesEntities();

            string inputFirstName = Edit_CustomerFirstName.Text.Trim();
            string inputSurname = Edit_CustomerSurname.Text.Trim();
            string inputHouseNumber = Edit_CustomerHouseNumber.Text.Trim();
            string inputStreetName = Edit_CustomerAddress.Text.Trim();
            string inputPostCode = Edit_CustomerPostCode.Text.Trim();
            string inputCity = Edit_CustomerCity.Text.Trim();
            string inputCountry = Edit_CustomerCountry.Text.Trim();
            string inputHomeTel = Edit_CustomerHomeTel.Text.Trim();
            string inputMobileNo = Edit_CustomerMobile.Text.Trim();

            if (string.IsNullOrEmpty(inputFirstName) || string.IsNullOrEmpty(inputSurname) || string.IsNullOrEmpty(inputHouseNumber) || string.IsNullOrEmpty(inputStreetName) || string.IsNullOrEmpty(inputPostCode) || string.IsNullOrEmpty(inputCity) || string.IsNullOrEmpty(inputCountry) || string.IsNullOrEmpty(inputHomeTel) || string.IsNullOrEmpty(inputMobileNo) || string.IsNullOrEmpty(inputStreetName))
            {
                MessageBox.Show("One or more field(s) are empty.", "Tiger Games v1.0", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            var existingData = context.tblCustomers.Where(c => c.CustomerID == SelectedID).FirstOrDefault();

            if (existingData == null)
            {
                MessageBox.Show("This customer does not exist.", "Tiger Games v1.0", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            existingData.CustomerFirstName = inputFirstName;
            existingData.CustomerSurname = inputSurname;
            existingData.CustomerHouseNumber = Convert.ToInt32(inputHouseNumber);
            existingData.CustomerAddress = inputStreetName;
            existingData.CustomerPostcode = inputPostCode;
            existingData.CustomerCity = inputCity;
            existingData.CustomerCountry = inputCountry;
            existingData.CustomerHomeTel = Convert.ToInt32(inputHomeTel);
            existingData.CustomerMobile = Convert.ToInt32(inputMobileNo);

            context.SaveChanges();

            MessageBox.Show($"Customer \"{inputFirstName + " " + inputSurname}\" has been updated.", "Tiger Games v1.0", MessageBoxButton.OK, MessageBoxImage.Information);

            this.Close();
        }
    }
}
